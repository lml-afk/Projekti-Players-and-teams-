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
        
       


        public Player(int playerId, string firstName, string lastName, string team, int playerScore) : base(firstName, lastName, team)
        {
            _playerScore = playerScore;
            _playerId++;
            _playerId = playerId;
        }

        
        public int GetPlayerId(int playerId)
        {
            _playerId = playerId;
            return playerId;
        }
    }
}
