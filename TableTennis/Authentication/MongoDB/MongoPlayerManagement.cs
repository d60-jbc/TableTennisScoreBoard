﻿using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TableTennis.Models;

namespace TableTennis.Authentication.MongoDB
{
    public class MongoPlayerManagement : IMongoPlayerManagement
    {
        private readonly string _connStr;
        private readonly MongoClient _mongoClient;
        private readonly MongoServer _mongoServer;
        private readonly MongoDatabase _mongoDatabase;

        public MongoPlayerManagement()
        {
            _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString;
            _mongoClient = new MongoClient(_connStr);
            _mongoServer = _mongoClient.GetServer();
            _mongoDatabase = _mongoServer.GetDatabase("tabletennis");
        }

        public bool CreatePlayer(Player player)
        {
            var collection = _mongoDatabase.GetCollection<Player>("Player");
            var foundPlayer = collection.FindOne(Query<Player>.Where(s => s.Username == player.Username));
            
            if (foundPlayer != null)
            {
                return false;
            }

            collection.Insert(player);
            return true;
        }

        public List<Player> GetAllPlayers()
        {
            var collection = _mongoDatabase.GetCollection<Player>("Player");
            return collection.FindAll().ToList();
        }
    }
}