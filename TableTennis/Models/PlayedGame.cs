﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TableTennis.Models
{
    [Bind(Exclude = "Id, GameSets")]
    public class PlayedGame
    {
        public PlayedGame()
        {
            PlayerIds = new List<Guid>();
            GameSets = new List<GameSet>();
        }

        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        public bool Ranked { get; set; }

        public DateTime TimeStamp { get; set; }

        public List<Guid> PlayerIds { get; set; }

        public Guid WinnerId { get; set; }

        public int EloPoints { get; set; }

        public List<GameSet> GameSets { get; set; } 
    }
}