using System;
using System.Collections.Generic;
using System.Text;

namespace Projekti_Players_and_teams_
{
    class Manager : Person
    {
        private static int _managerId = 0;
        private int managerId;

        public Manager(string firstName, string lastName, string team) : base(firstName, lastName, team)
        {
            _managerId = managerId;
            _managerId++;
        }

        public int GetManagerId()

        {
            return managerId;
        }
    }
}
