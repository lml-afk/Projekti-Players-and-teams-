using System;
using System.Collections.Generic;
using System.Text;

namespace Projekti_Players_and_teams_
{
    class Player : Person 
    {
        private static int _playerId =0;
        private int _playerScore;
        private bool _isCaptain;
        private string _position;
        private int playerId;
       


        public Player(string firstName, string lastName, string team) : base(firstName, lastName, team)
        {
           
            _playerId++;
            _playerId = playerId;
        }

        
        public int GetPlayerId()
        {
            return playerId;
        }
    }
}
