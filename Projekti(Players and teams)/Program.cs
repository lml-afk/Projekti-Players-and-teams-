using System;
using System.Collections.Generic;
using System.Text;

namespace Projekti_Players_and_teams_
{
    class Program
    {
        static void Main(string[] args)
        {
            Player firstPlayer = new Player("esa","matti","jumoon pallo");
            Console.WriteLine(firstPlayer.GetNameAndTeam());

            Manager firstManager = new Manager("jami", "matti","jumoon pallo");
            Console.WriteLine(firstManager.GetNameAndTeam());
        }
    }
}
