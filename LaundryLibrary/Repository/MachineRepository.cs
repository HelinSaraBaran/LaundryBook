using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace LaundryLibrary.Repository
{
    
    public class MachineRepository : IMachineRepository
    {
       
        private readonly string _connectionString;

  
        private readonly Dictionary<int, Machine> _machines;

       
        public MachineRepository(string connectionString)
        {
            _connectionString = connectionString;
            _machines = new Dictionary<int, Machine>();

            Console.WriteLine("🔍 MachineRepository connectionString = " + connectionString);
        }

      
        public Dictionary<int, Machine> GetAll()
        {
            Dictionary<int, Machine> machinesFromDatabase = new Dictionary<int, Machine>();

            
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("SELECT machine_ID, machine_type FROM machines", connection);

            try
            {
                
                connection.Open();

               
                SqlDataReader reader = command.ExecuteReader();

              
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["machine_ID"]);

                
                    string typeText = reader["machine_type"].ToString();
                    MachineType type;

                 
                    if (int.TryParse(typeText, out int numericType))
                    {
                        type = (MachineType)numericType;
                    }
                    else
                    {
                        type = (MachineType)Enum.Parse(typeof(MachineType), typeText, true);
                    }

                    Machine machine = new Machine(id, type);
                    machinesFromDatabase.Add(id, machine);
                }

              
                reader.Close();
            }
            catch (SqlException ex)
            {
              
                throw new Exception("Database error in MachineRepository.GetAll(): " + ex.Message);
            }
            finally
            {
              
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return machinesFromDatabase;
        }

        public void Add(Machine item)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(
                "INSERT INTO machines (machine_ID, machine_type) VALUES (@machine_ID, @machine_type)", connection);

      
            command.Parameters.AddWithValue("@machine_ID", item.Id);
            command.Parameters.AddWithValue("@machine_type", item.Type.ToString());

            try
            {
                connection.Open();
                command.ExecuteNonQuery();     
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in MachineRepository.Add(): " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            if (!_machines.ContainsKey(item.Id))
            {
                _machines.Add(item.Id, item);
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("DELETE FROM machines WHERE machine_ID = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();    
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in MachineRepository.Delete(): " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            if (_machines.ContainsKey(id))
            {
                _machines.Remove(id);
            }
        }

        public Machine FindKey(int key)
        {
            if (_machines.ContainsKey(key))
            {
                return _machines[key];
            }
            else
            {
                return null;
            }
        }
    }
}

