using System;
using System.Collections.Generic;
using System.Text;

namespace Projekti_Players_and_teams_
{
    class Player : Person 
    {
        private int _playerId;
        private int _playerScore;
        private bool _isCaptain;
        private string _position;

        public Player(string firstName, string lastName, string team) : base(firstName, lastName, team)
        {
        }
    }
}
