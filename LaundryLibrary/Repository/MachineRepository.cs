using LaundryLibrary.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LaundryLibrary.Repository
{
    public class MachineRepository : IMachineRepository
    {
        private readonly string _connectionString;              
        private readonly Dictionary<int, Machine> _machineList; 

        // Constructor 
        public MachineRepository(string connectionString)
        {
            _connectionString = connectionString;
            _machineList = new Dictionary<int, Machine>();
        }

        // Henter alle maskiner fra databasen
        public Dictionary<int, Machine> GetAll()
        {
            Dictionary<int, Machine> machinesFromDatabase = new Dictionary<int, Machine>();

            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand("SELECT machine_ID, machine_type FROM machines", sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    
                    int machineId = Convert.ToInt32(sqlReader["machine_ID"]);
                    string machineTypeText = sqlReader["machine_type"].ToString();

                    // Bestemmer maskinetype
                    MachineType machineType = MachineType.Washer;
                    if (machineTypeText == "Tørretumbler") { machineType = MachineType.Dryer; }
                    else if (machineTypeText == "Rullemaskine") { machineType = MachineType.Ironer; }

                  

                    // Opretter objekt og tilføjer til dictionary
                    Machine machine = new Machine(machineId, machineType);
                    machinesFromDatabase.Add(machineId, machine);
                }

                sqlReader.Close();
            }
            catch (SqlException sqlError)
            {
                throw new Exception("Databasefejl i MachineRepository.GetAll(): " + sqlError.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return machinesFromDatabase;
        }

        // Tilføjer ny maskine til databasen
        public void Add(Machine machine)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(
                "INSERT INTO machines (machine_ID, machine_type) VALUES (@machine_ID, @machine_type)",
                sqlConnection);

            sqlCommand.Parameters.AddWithValue("@machine_ID", machine.Id);
            sqlCommand.Parameters.AddWithValue("@machine_type", machine.Type.ToString());

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlError)
            {
                throw new Exception("Databasefejl i MachineRepository.Add(): " + sqlError.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            // Gem også i lokal liste
            if (!_machineList.ContainsKey(machine.Id))
            {
                _machineList.Add(machine.Id, machine);
            }
        }

        // Sletter maskine ud fra ID
        public void Delete(int machineId)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM machines WHERE machine_ID = @Id", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", machineId);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlError)
            {
                throw new Exception("Databasefejl i MachineRepository.Delete(): " + sqlError.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            if (_machineList.ContainsKey(machineId))
            {
                _machineList.Remove(machineId);
            }
        }

        // Finder maskine ud fra nøgle
        public Machine FindKey(int key)
        {
            if (_machineList.ContainsKey(key))
            {
                return _machineList[key];
            }
            else
            {
                return null;
            }
        }
    }
}

