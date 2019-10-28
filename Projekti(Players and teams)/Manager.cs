using System;
using System.Collections.Generic;
using System.Text;

namespace Projekti_Players_and_teams_
{
    class Manager : Person
    {
        private int _managerId;

        public Manager(string firstName, string lastName, string team) : base(firstName, lastName, team)
        {
        }
    }
}
