using System;
using System.Collections.Generic;
using System.Text;

namespace Projekti_Players_and_teams_
{
     abstract class Person
     {
        private string _firstName;
        private string _lastName;
        private string _team;


        public Person(string firstName, string lastName, string team)
        {
            _firstName = firstName;
            _lastName = lastName;
            _team = team;
        }

        public string GetNameAndTeam()

        {
            return _firstName + " " + _lastName + " is playing for " + _team;
        }
     }  
}

