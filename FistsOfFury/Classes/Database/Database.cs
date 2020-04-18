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
            return (_leaderboard.Find(new BsonDocument()).Sort(sort)).ToList();

        }

        public List<BsonDocument> GetUserHistory(string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("FighterName", name.ToLower());
            return _leaderboard.Find(filter).ToList();
        }

        public FightStats Deserialize(BsonDocument d)
        {
            return new FightStats(d.GetValue("FighterName").ToString(), d.GetValue("Score").ToInt32(), d.GetValue("PunchesThrown").ToInt32(), d.GetValue("HighKicksThrown").ToInt32(), d.GetValue("LowKicksThrown").ToInt32(), d.GetValue("PunchesLanded").ToInt32(), d.GetValue("HighKicksLanded").ToInt32(), d.GetValue("LowKicksLanded").ToInt32());
        }
    }
}
