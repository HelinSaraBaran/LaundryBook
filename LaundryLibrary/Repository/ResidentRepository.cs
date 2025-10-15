using LaundryLibrary.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace LaundryLibrary.Repository
{
    public class ResidentRepository : IResidentRepository
    {
        
        private readonly string _connectionString;

        
        private readonly List<Apartment> _apartments;
        private readonly List<Resident> _residents;

       
        public ResidentRepository(string connectionString)
        {
            _connectionString = connectionString;
            _apartments = new List<Apartment>();
            _residents = new List<Resident>();
        }

    
        public List<Apartment> GetAllApartments()
        {
            List<Apartment> result = new List<Apartment>();

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(
                "SELECT adress, streetnumber, postalcode, apartmentnumber, apartmentfloor FROM residents",
                connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string street = reader["adress"].ToString();
                    string streetNumber = reader["streetnumber"].ToString();
                    string postalCode = reader["postalcode"].ToString();
                    string apartmentLetter = reader["apartmentnumber"].ToString();
                    int floor = Convert.ToInt32(reader["apartmentfloor"]);

                    Apartment apartment = new Apartment("Roskilde", floor, streetNumber, postalCode, apartmentLetter, street);
                    result.Add(apartment);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in ResidentRepository.GetAllApartments(): " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return result;
        }

        
        public void AddApartment(Apartment item)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(
                "INSERT INTO residents (adress, streetnumber, postalcode, apartmentnumber, apartmentfloor) " +
                "VALUES (@adress, @streetnumber, @postalcode, @apartmentnumber, @apartmentfloor)",
                connection);

            command.Parameters.AddWithValue("@adress", item.AddressLine);
            command.Parameters.AddWithValue("@streetnumber", item.StreetAndNumber);
            command.Parameters.AddWithValue("@postalcode", item.PostalCode);
            command.Parameters.AddWithValue("@apartmentnumber", item.ApartmentLetter);
            command.Parameters.AddWithValue("@apartmentfloor", item.Floor);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in ResidentRepository.AddApartment(): " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            _apartments.Add(item);
        }

        
        public void DeleteApartment(Apartment apartment)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("DELETE FROM residents WHERE apartmentnumber = @apartmentnumber", connection);
            command.Parameters.AddWithValue("@apartmentnumber", apartment.ApartmentLetter);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in ResidentRepository.DeleteApartment(): " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            _apartments.Remove(apartment);
        }

 
        public List<Resident> GetAllResidents()
        {
            List<Resident> result = new List<Resident>();

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(
                "SELECT firstname, lastname, mobile, email, apartmentnumber, adress, streetnumber, postalcode, apartmentfloor FROM residents",
                connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int idCounter = 1;
                while (reader.Read())
                {
                    string firstName = reader["firstname"].ToString();
                    string lastName = reader["lastname"].ToString();
                    string mobile = reader["mobile"].ToString();
                    string email = reader["email"].ToString();
                    string apartmentLetter = reader["apartmentnumber"].ToString();
                    string street = reader["adress"].ToString();
                    string streetNumber = reader["streetnumber"].ToString();
                    string postal = reader["postalcode"].ToString();
                    int floor = Convert.ToInt32(reader["apartmentfloor"]);

                    Apartment apartment = new Apartment("Roskilde", floor, streetNumber, postal, apartmentLetter, street);
                    Resident resident = new Resident(idCounter, firstName, lastName, mobile, email, apartment);
                    result.Add(resident);
                    idCounter++;
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in ResidentRepository.GetAllResidents(): " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return result;
        }

    
        public void AddResident(Resident item)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(
                "INSERT INTO residents (firstname, lastname, mobile, email, apartmentnumber, adress, streetnumber, postalcode, apartmentfloor) " +
                "VALUES (@firstname, @lastname, @mobile, @email, @apartmentnumber, @adress, @streetnumber, @postalcode, @apartmentfloor)",
                connection);

            command.Parameters.AddWithValue("@firstname", item.FirstName);
            command.Parameters.AddWithValue("@lastname", item.LastName);
            command.Parameters.AddWithValue("@mobile", item.Mobile);
            command.Parameters.AddWithValue("@email", item.Email);
            command.Parameters.AddWithValue("@apartmentnumber", item.Apartment.ApartmentLetter);
            command.Parameters.AddWithValue("@adress", item.Apartment.AddressLine);
            command.Parameters.AddWithValue("@streetnumber", item.Apartment.StreetAndNumber);
            command.Parameters.AddWithValue("@postalcode", item.Apartment.PostalCode);
            command.Parameters.AddWithValue("@apartmentfloor", item.Apartment.Floor);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in ResidentRepository.AddResident(): " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            _residents.Add(item);
        }

        public void DeleteResident(Resident resident)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("DELETE FROM residents WHERE mobile = @mobile", connection);
            command.Parameters.AddWithValue("@mobile", resident.Mobile);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in ResidentRepository.DeleteResident(): " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            _residents.Remove(resident);
        }
    }
}
