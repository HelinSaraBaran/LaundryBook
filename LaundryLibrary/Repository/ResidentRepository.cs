using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace LaundryLibrary.Repository
{
    public class ResidentRepository:IResidentRepository
    {
        private string _connectionString;
        public ResidentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        List<Apartment> apartments;
        List<Resident> residents;
        public ResidentRepository()
        {
            apartments = new List<Apartment>();
            residents = new List<Resident>();
        }
        public List<Apartment> GetAllApartments()
        {
            var residents = new List<Apartment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select Resident from residents", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var apartment = new Apartment((string)reader["city"], (int)reader["floor"], (string)reader["streetAndNumber"], (string)reader["postalCode"], (string)reader["appartmentLetter"], (string)reader["addressLine"]);
                    }
                }
                return apartments;
            } }
        public void AddApartment(Apartment item)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("Insert into residents(city, floor, streetAndNumber, postalCode, appartmentLetter, addressLine) Values (@city, @floor, @streetAndNumber, @postalCode, @appartmentLetter, @addressLine)", connection);
                command.Parameters.AddWithValue("@city", item.City);
                command.Parameters.AddWithValue("@floor", item.Floor);
                command.Parameters.AddWithValue("@streetAndNumber", item.StreetAndNumber);
                command.Parameters.AddWithValue("@postalCode", item.PostalCode);
                command.Parameters.AddWithValue("@appartmentLetter", item.ApartmentLetter);
                command.Parameters.AddWithValue("@addressLine", item.AddressLine);

                connection.Open();
                command.ExecuteNonQuery();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) ;
                }

            }
        }
        public void DeleteApartment(Apartment apartment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("Delete from residents Where apartmentnumber, adress = @apartmentnumber ,@adress", connection);
                command.Parameters.AddWithValue("@apartmentnumber", apartment.ApartmentLetter);
            }
            

        }
        public List<Resident> GetAllResidents()
        {
            return residents;
        }

        public void AddResident(Resident item)
        {

            residents.Add(item);
        }
        public void DeleteResident(Resident id)
        {
            Resident residentToRemove = null; // initialiserer "DocLogToRemove" som "null"

            foreach (Resident d in residents)  //løber igennem hver "DocJournal" objekt i "_docJournal" listen. det valgte objekt bliver forløbeligt navngivet "d"
            {
                if (d == id) //tjekker om det valgte id matcher med det i parametren
                {
                    residentToRemove = d; //hvis det gør 
                    break; //stopper den med at løbe igennem
                }
            }

            if (residentToRemove != null) //hvis en matching DocJournal blev fundet
            {
               residents.Remove(residentToRemove); //bliver den slettet fra listen
            }

        }
    }
}
