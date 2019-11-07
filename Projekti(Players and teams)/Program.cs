using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Npgsql;

namespace Projekti_Players_and_teams_
{
    class Program
    {
        static void Menu()  

        {
            Console.WriteLine("");
            Console.WriteLine(" 1 - Add new player");
            Console.WriteLine(" 2 - Add new manager");
            Console.WriteLine(" 3 - Print list of players");
            Console.WriteLine(" 4 - Print list of managers");
            Console.WriteLine(" 5 - Sort players by score");
            Console.WriteLine(" 6 - Print list of players and managers created this session");
            Console.WriteLine(" 7 - Quit");
            Console.WriteLine("");
        }
        static void TeamMenu() 
        {
            Console.WriteLine("");
            Console.WriteLine("Choose team 1-4");
            Console.WriteLine(" 1 - Jumoon Pallo");
            Console.WriteLine(" 2 - Juvan Veto");
            Console.WriteLine(" 3 - Nurmon Näppi");
            Console.WriteLine(" 4 - Iisalmen Kisailijat");
            Console.WriteLine(""); 
        }

        static void Main(string[] args)
        {
           
            int input = 0;                                    
            List<Manager> managerList = new List<Manager>();    
            List<Player> playerList = new List<Player>();      
            do
            {
                Menu();  //Tulostetaan valikko
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine($"Error, please A insert number between 1 and 7");
                }
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Insert first name");  //Luodaan olio oliolistaan, käyttäjän tiedoilla
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Insert last name");
                        string lastName = Console.ReadLine();
                        TeamMenu(); //Tulostetaan joukkuevalikko
                        int menuinput = int.Parse(Console.ReadLine());
                        string team = "";

                        if (menuinput == 1)
                        {
                            team = "Jumoon Pallo";
                        }
                        else if (menuinput == 2)
                        {
                            team = "Juvan Veto";
                        }
                        else if (menuinput == 3)
                        {
                            team = "Nurmon Näppi";
                        }
                        else if (menuinput == 4)
                        {
                            team = "Iisalmen Kisailijat";
                        }

                        Random rnd = new Random();
                        int score = rnd.Next(1, 30);

                        int playerId = Player.GetPlayerId();
         
                        Player newPlayer = new Player(playerId,firstName, lastName, team,score);
                        playerList.Add(newPlayer);                                                      //ID tieto oliosta
                        Console.WriteLine($"New Player {newPlayer.GetNameAndTeam()} added with ID: {Player.GetPlayerId()}");
                                    //Lisätään oliodata tietokantaan
                        var connStringplayer = "Host=localhost;Username=postgres;Password=postgres;Database=PlayersTeams";
                        using (var conn = new NpgsqlConnection(connStringplayer))                         
                        using (var cmd = new NpgsqlCommand("INSERT INTO player VALUES (@playerid,@firstname,@lastname,@team,@score)", conn))
                        {
                                conn.Open();
                                cmd.Parameters.AddWithValue("playerid", playerId);
                                cmd.Parameters.AddWithValue("firstname", firstName);
                                cmd.Parameters.AddWithValue("lastname", lastName);
                                cmd.Parameters.AddWithValue("team", team);
                                cmd.Parameters.AddWithValue("score", score);
                                cmd.ExecuteNonQueryAsync();
                        }
                  
                        break;

                    case 2:
                        Console.WriteLine("Insert first name"); //Luodaan manager olio käyttäjän tiedoilla
                        string managerFirstName = Console.ReadLine();
                        Console.WriteLine("Insert last name");
                        string managerLastName = Console.ReadLine();
                        TeamMenu(); //Valikkotulostus
                        int menuinput2 = int.Parse(Console.ReadLine());
                        string managerTeam = "";

                        if (menuinput2 == 1)
                        {
                            managerTeam = "jumoon pallo";
                        }
                        else if (menuinput2 == 2)
                        {
                            managerTeam = "juvan veto";
                        }
                        else if (menuinput2 == 3)
                        {
                            managerTeam = "nurmon näppi";
                        }
                        else if (menuinput2 == 4)
                        {
                            managerTeam = "iisalmen kisailijat";
                        }

                        int managerId = Manager.GetManagerId();

                        Manager newManager = new Manager(managerId,managerFirstName, managerLastName, managerTeam);
                        managerList.Add(newManager);
                        Console.WriteLine($"New Manager {newManager.GetNameAndTeam()} added with ID: {Manager.GetManagerId()}");

                        var connStringmanager = "Host=localhost;Username=postgres;Password=postgres;Database=PlayersTeams";
                        using (var conn = new NpgsqlConnection(connStringmanager))
                        using (var cmd = new NpgsqlCommand("INSERT INTO manager VALUES (@managerid,@managerfirstname,@managerlastname,@team)", conn))
                        {
                            conn.Open();
                            cmd.Parameters.AddWithValue("managerid", managerId);
                            cmd.Parameters.AddWithValue("managerfirstname", managerFirstName);
                            cmd.Parameters.AddWithValue("managerlastname", managerLastName);
                            cmd.Parameters.AddWithValue("team", managerTeam);
                            cmd.ExecuteNonQueryAsync();
                        }
                        break;

                    case 3:
                                                    //luetaan ja tulostetaan player list tietokannasta
                         Console.WriteLine("");
                         var connStringplayerlist = "Host=localhost;Username=postgres;Password=postgres;Database=PlayersTeams";
                         using (var conn = new NpgsqlConnection(connStringplayerlist))
                         {
                                 conn.Open();
                                 using (var cmd = new NpgsqlCommand("SELECT * FROM player", conn))
                                 using (var reader = cmd.ExecuteReader())
                                 while (reader.Read())
                                                             //playerid             //firstname         //lastname              //team          //score
                                 Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)} {reader.GetInt32(4)} ");
                         }
                        Console.WriteLine("");
                        break;

                                                    //luetaan ja tulostetaan manager list tietokannasta
                    case 4:
                        Console.WriteLine("");
                        var connStringmanagerlist = "Host=localhost;Username=postgres;Password=postgres;Database=PlayersTeams";
                        using (var conn = new NpgsqlConnection(connStringmanagerlist))
                        {
                            conn.Open();
                            using (var cmd = new NpgsqlCommand("SELECT * FROM manager", conn))
                            using (var reader = cmd.ExecuteReader())
                                while (reader.Read())
                                                                //managerid         //firstname           //lastname            //team
                                    Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)} ");
                        }
                        Console.WriteLine("");
                        break;

                    case 5:
                        
                        Console.WriteLine("");
                   
                        var connStringplayersort = "Host=localhost;Username=postgres;Password=postgres;Database=PlayersTeams";
                        using (var conn = new NpgsqlConnection(connStringplayersort))
                        {
                            conn.Open();
                            using (var cmd = new NpgsqlCommand("SELECT * FROM player ORDER BY score ASC", conn))
                            using (var reader = cmd.ExecuteReader())
                                while (reader.Read())
                                                                 //playerid             //firstname         //lastname              //team          //score
                                    Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)} {reader.GetInt32(4)} ");
                        }
                        Console.WriteLine("");

                        break;
                        
                    case 6:
                                    //Tulostaa tässä sessiossa luodut oliot
                        foreach (Player player in playerList)
                        {
                            Console.WriteLine($"Player :{player.GetNameAndTeam()}");
                        }

                        foreach (Manager manager in managerList)
                        {
                            Console.WriteLine($"Manager: {manager.GetNameAndTeam()}");
                        }

                        break;


                    default:
                        break;
                }
            } while (input > 0 && input < 7);

            
            

        }
    }
}
