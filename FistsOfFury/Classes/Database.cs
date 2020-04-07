using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace FistsOfFury.Classes
{
    public class Database
    {
        private MongoClient _client { get; }
        private IMongoDatabase _database { get; }
        private IMongoCollection<BsonDocument> _leaderboard { get; set; }

        public Database()
        {
            _client = new MongoClient("mongodb+srv://admin:admin@cluster-suzyschema-f4pio.azure.mongodb.net/test?retryWrites=true&w=majority");
            _database = _client.GetDatabase("Fists-Of-Fury");
            _leaderboard = _database.GetCollection<BsonDocument>("Leaderboard");
        }
         
        public async void LogMatch(Match match)
        {
            foreach (FightStats stat in match.Stats)
            {
                await _leaderboard.InsertOneAsync(BsonDocument.Parse(JsonConvert.SerializeObject(stat)));
            }
        }
    }
}
