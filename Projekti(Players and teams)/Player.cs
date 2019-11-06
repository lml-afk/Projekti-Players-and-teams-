using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Projekti_Players_and_teams_
{
    class Player : Person
    {              
        private static int _playerId;
        private int _playerScore;
        private bool _isCaptain;
        private string _position;
        private int playerId;
        public Player(int playerId, string firstName, string lastName, string team, int playerScore) : base(firstName, lastName, team)
        {
            _playerScore = playerScore;

        }        
        public static int GetPlayerId()
        {
            _playerId = IdGetting()+1;  //ID Tietokannasta uuden ID:n luomista varten, lisätään 1.
            return _playerId;
        }

        public static int IdGetting()

        {

            var connStringplayersort = "Host=localhost;Username=postgres;Password=postgres;Database=PlayersTeams";
            using (var conn = new NpgsqlConnection(connStringplayersort))
            {
                conn.Open();                        //Haetaan isoin arvo kentälle ID tietokannasta
                using (var cmd = new NpgsqlCommand("SELECT MAX(player_id) FROM player", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int idFromDatabase = 0;

                        //Jos haettu arvo NULL (tyhjä tietokanta) asetetaan arvoksi 0.
                    var resultObject = reader.GetValue(0);
                    if (resultObject != DBNull.Value)
                    {
                        idFromDatabase = Convert.ToInt32(resultObject);
                        return idFromDatabase;
                    }
                    else
                    {
                        idFromDatabase = 0;
                        return idFromDatabase;
                    } 
                }
            }
        }
    }
}
