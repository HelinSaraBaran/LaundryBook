using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Microsoft.Identity.Client;


namespace LaundryLibrary.Repository
{
    public class MachineRepository:IMachineRepository
    {

        private string _connectionString;
        public MachineRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        Dictionary<int,Machine> machines;
        public MachineRepository()
        {
            machines = new Dictionary<int,Machine>();
        }
        public Dictionary<int,Machine> GetAll()
        {
            var Machine = new Dictionary<int,Machine>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("Select machine_Id,machine_Type from machines", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var machine = new Machine((int)reader["machine_ID"], (MachineType) reader["type"]);
                    }
                }
            }
            return machines;
        }

        public void Add(Machine item)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("insert into machines(machine_ID, machine_type) values (@machine_ID, @machine_type)", connection);
                command.Parameters.AddWithValue("@machine_ID", item.Id);
                command.Parameters.AddWithValue("@machine_type", item.Type);
                connection.Open();
                command.ExecuteNonQuery();

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    { }
                }
                int count = 0;
                foreach (KeyValuePair<int, Machine> m in machines)
                {
                    count++;
                    Debug.WriteLine($"count is {count}");
                }
                machines.Add(count, item);

            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("delete from machines Where Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }

                if (FindKey(id) != null)
                {
                    machines.Remove(id);
                    
                }
            
        }
        public Machine FindKey(int key)
        {
            if (machines.ContainsKey(key))
            {
                return machines[key];
            }
            else
            {
                return null;
            }
                
        }
       

    }

}
