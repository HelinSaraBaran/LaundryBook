using LaundryLibrary.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LaundryLibrary.Repository
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly string _connectionString; 
        private readonly List<Apartment> _apartmentList; 
        private readonly List<Resident> _residentList;   

        // Constructor 
        public ResidentRepository(string connectionString)
        {
            _connectionString = connectionString;
            _apartmentList = new List<Apartment>();
            _residentList = new List<Resident>();
        }

        // Henter alle lejligheder fra databasen
        public List<Apartment> GetAllApartments()
        {
            List<Apartment> apartmentsFromDatabase = new List<Apartment>();

            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(
                "SELECT adress, streetnumber, postalcode, apartmentnumber, apartmentfloor FROM residents",
                sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    string street = sqlReader["adress"].ToString();
                    string streetNumber = sqlReader["streetnumber"].ToString();
                    string postalCode = sqlReader["postalcode"].ToString();
                    string apartmentLetter = sqlReader["apartmentnumber"].ToString();
                    int floor = Convert.ToInt32(sqlReader["apartmentfloor"]);

                    Apartment apartment = new Apartment("Roskilde", floor, streetNumber, postalCode, apartmentLetter, street);
                    apartmentsFromDatabase.Add(apartment);
                }

                sqlReader.Close();
            }
            catch (SqlException sqlError)
            {
                throw new Exception("Databasefejl i ResidentRepository.GetAllApartments(): " + sqlError.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return apartmentsFromDatabase;
        }

        // Tilføjer en ny lejlighed til databasen
        public void AddApartment(Apartment apartment)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(
                "INSERT INTO residents (adress, streetnumber, postalcode, apartmentnumber, apartmentfloor) " +
                "VALUES (@adress, @streetnumber, @postalcode, @apartmentnumber, @apartmentfloor)",
                sqlConnection);

            sqlCommand.Parameters.AddWithValue("@adress", apartment.AddressLine);
            sqlCommand.Parameters.AddWithValue("@streetnumber", apartment.StreetAndNumber);
            sqlCommand.Parameters.AddWithValue("@postalcode", apartment.PostalCode);
            sqlCommand.Parameters.AddWithValue("@apartmentnumber", apartment.ApartmentLetter);
            sqlCommand.Parameters.AddWithValue("@apartmentfloor", apartment.Floor);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlError)
            {
                throw new Exception("Databasefejl i ResidentRepository.AddApartment(): " + sqlError.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            _apartmentList.Add(apartment);
        }

        // Sletter en lejlighed fra databasen
        public void DeleteApartment(Apartment apartment)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(
                "DELETE FROM residents WHERE apartmentnumber = @apartmentnumber", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@apartmentnumber", apartment.ApartmentLetter);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlError)
            {
                throw new Exception("Databasefejl i ResidentRepository.DeleteApartment(): " + sqlError.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            _apartmentList.Remove(apartment);
        }

        // Henter alle beboere fra databasen
        public List<Resident> GetAllResidents()
        {
            List<Resident> residentsFromDatabase = new List<Resident>();

            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(
                "SELECT firstname, lastname, mobile, email, apartmentnumber, adress, streetnumber, postalcode, apartmentfloor FROM residents",
                sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                int idCounter = 1;
                while (sqlReader.Read())
                {
                    string firstName = sqlReader["firstname"].ToString();
                    string lastName = sqlReader["lastname"].ToString();
                    string mobile = sqlReader["mobile"].ToString();
                    string email = sqlReader["email"].ToString();
                    string apartmentLetter = sqlReader["apartmentnumber"].ToString();
                    string street = sqlReader["adress"].ToString();
                    string streetNumber = sqlReader["streetnumber"].ToString();
                    string postal = sqlReader["postalcode"].ToString();
                    int floor = Convert.ToInt32(sqlReader["apartmentfloor"]);

                    Apartment apartment = new Apartment("Roskilde", floor, streetNumber, postal, apartmentLetter, street);
                    Resident resident = new Resident(idCounter, firstName, lastName, mobile, email, apartment);

                    residentsFromDatabase.Add(resident);
                    idCounter++;
                }

                sqlReader.Close();
            }
            catch (SqlException sqlError)
            {
                throw new Exception("Databasefejl i ResidentRepository.GetAllResidents(): " + sqlError.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return residentsFromDatabase;
        }

        // Tilføjer en ny beboer til databasen
        public void AddResident(Resident resident)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(
                "INSERT INTO residents (firstname, lastname, mobile, email, apartmentnumber, adress, streetnumber, postalcode, apartmentfloor) " +
                "VALUES (@firstname, @lastname, @mobile, @email, @apartmentnumber, @adress, @streetnumber, @postalcode, @apartmentfloor)",
                sqlConnection);

            sqlCommand.Parameters.AddWithValue("@firstname", resident.FirstName);
            sqlCommand.Parameters.AddWithValue("@lastname", resident.LastName);
            sqlCommand.Parameters.AddWithValue("@mobile", resident.Mobile);
            sqlCommand.Parameters.AddWithValue("@email", resident.Email);
            sqlCommand.Parameters.AddWithValue("@apartmentnumber", resident.Apartment.ApartmentLetter);
            sqlCommand.Parameters.AddWithValue("@adress", resident.Apartment.AddressLine);
            sqlCommand.Parameters.AddWithValue("@streetnumber", resident.Apartment.StreetAndNumber);
            sqlCommand.Parameters.AddWithValue("@postalcode", resident.Apartment.PostalCode);
            sqlCommand.Parameters.AddWithValue("@apartmentfloor", resident.Apartment.Floor);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlError)
            {
                throw new Exception("Databasefejl i ResidentRepository.AddResident(): " + sqlError.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            _residentList.Add(resident);
        }

        // Sletter en beboer fra databasen
        public void DeleteResident(Resident resident)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM residents WHERE mobile = @mobile", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@mobile", resident.Mobile);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlError)
            {
                throw new Exception("Databasefejl i ResidentRepository.DeleteResident(): " + sqlError.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            _residentList.Remove(resident);
        }
    }
}
