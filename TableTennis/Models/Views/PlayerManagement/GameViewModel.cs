﻿using System;

namespace TableTennis.Models.Views.PlayerManagement
{
    public class GameViewModel
    {
        public string Opponent { get; set; }
        public bool Won { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Rating { get; set; }
    }
}