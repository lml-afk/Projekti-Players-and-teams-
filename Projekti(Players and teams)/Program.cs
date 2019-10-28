using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projekti_Players_and_teams_
{
    class Program
    {
        static void Menu()

        {
            //Konsolitulostus, valitaan toiminto

            Console.WriteLine(" 1 - Add new player");
            Console.WriteLine(" 2 - Add new manager");
            Console.WriteLine(" 3 - Print list of players");
            Console.WriteLine(" 4 - Print list of managers");
            Console.WriteLine(" 5 - Quit");
        }

        static void Main(string[] args)
        {
            int input = 0;                                      //Valikon valinta muuttuja
            List<Manager> managerList = new List<Manager>();    //Luodaan Manager lista
            List<Player> playerList = new List<Player>();       //Luodaan Player lista
            do
            {
                Menu();
                input = int.Parse(Console.ReadLine());
                switch (input)
                
                {
                    case 1:
                        Console.WriteLine("Insert first name");  //Luodaan pelaaja playerList:iin, kysytään etunimi, sukunimi ja joukkue
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Insert last name");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Insert team name");
                        string team = Console.ReadLine();
                        Player newPlayer = new Player(firstName, lastName, team);
                        playerList.Add(newPlayer);
                        Console.WriteLine($"New Player {newPlayer.GetNameAndTeam()} added.");
                        break;

                    case 2:
                        Console.WriteLine("Insert first name"); //Luodaan manageri managerList:iin, kysytään etunimi, sukunimi ja joukkue
                        string managerFirstName = Console.ReadLine();
                        Console.WriteLine("Insert last name");
                        string managerLastName = Console.ReadLine();
                        Console.WriteLine("Insert team name");
                        string managerTeam = Console.ReadLine();
                        Manager newManager = new Manager(managerFirstName, managerLastName, managerTeam);
                        managerList.Add(newManager);
                        Console.WriteLine($"New Manager {newManager.GetNameAndTeam()} added.");
                        break;

                    case 3:

                        foreach (Player player in playerList)  //Tulostetaan playerList
                        {
                            Console.WriteLine($"{player.GetNameAndTeam()}");
                        }
                        break;

                    case 4:
                        foreach (Manager manager in managerList)  //Tulostetaan managerList
                        {
                            Console.WriteLine($"{manager.GetNameAndTeam()}");
                        }
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            } while (input > 0);

            

        }
    }
}












//Player firstPlayer = new Player("esa","matti","jumoon pallo");
//Console.WriteLine(firstPlayer.GetNameAndTeam());

// Manager firstManager = new Manager("jami", "matti","jumoon pallo");
//Console.WriteLine(firstManager.GetNameAndTeam());