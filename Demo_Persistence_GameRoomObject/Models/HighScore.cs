﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Persistence_GameRoomObject
{
    public class HighScore
    {
        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }

        public HighScore()
        {

        }

        public HighScore(string playerName, int playerScore)
        {
            this.PlayerName = playerName;
            this.PlayerScore = playerScore;
        }
    }
}
