using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Windows.UI.Popups;


namespace FistsOfFury.Classes
{
    public class Database
    {
        private MongoClient _client { get; }
        private IMongoDatabase _db { get; }
        private IMongoCollection<BsonDocument> _leaderboard { get; set; }
        public Database()
        {
            _client = new MongoClient("mongodb+srv://admin:admin@cluster-suzyschema-f4pio.azure.mongodb.net/test?retryWrites=true&w=majority");
            _db = _client.GetDatabase("Fists-Of-Fury");
            _leaderboard = _db.GetCollection<BsonDocument>("Leaderboard");
        }
         
        public async void LogMatch(Match match)
        {
            foreach (FightStats stat in match.Stats)
            {
                await _leaderboard.InsertOneAsync(BsonDocument.Parse(JsonConvert.SerializeObject(stat)));
            }
        }

        public List<BsonDocument> GetLeaderboard()
        {
            var sort = Builders<BsonDocument>.Sort.Descending("Score");
            return _leaderboard.Find(new BsonDocument()).Sort(sort).ToList();
        }

        public List<BsonDocument> GetUserHistory(string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", name.ToLower());
            return _leaderboard.Find(filter).ToList();
        }

        public void testit()
        {
            var x = new FightStats() 
            {
                Name="Joe",
                PunchesThrown=100,
                LowKicksLanded=50,
                HighKicksLanded=100,
                HighKicksThrown=50,
                LowKicksThrown=100,
                PunchesLanded=50
            };
            _leaderboard.InsertOneAsync(BsonDocument.Parse(JsonConvert.SerializeObject(x)));


        }
    }
}
