using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Projekti_Players_and_teams_
{
    class Manager : Person
    {
        private static int _managerId;
       
        public Manager(int managerId, string firstName, string lastName, string team) : base(firstName, lastName, team)
        {
        }

        public static int GetManagerId()

        {
            _managerId= ManagerIdGet() + 1;
            return _managerId;
        }

        public static int ManagerIdGet()

        {
            var connStringplayersort = "Host=localhost;Username=postgres;Password=postgres;Database=PlayersTeams";
            using (var conn = new NpgsqlConnection(connStringplayersort))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT MAX(managerid) FROM manager", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int managerIdFromDatabase = 0;
                    var resultObject = reader.GetValue(0);
                    if (resultObject != DBNull.Value)
                    {
                        managerIdFromDatabase = Convert.ToInt32(resultObject);
                        return managerIdFromDatabase;
                    }
                    else
                    {
                        managerIdFromDatabase = 0;
                        return managerIdFromDatabase;
                    }

                }
            }
        }
    }
}
