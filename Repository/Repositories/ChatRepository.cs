using MongoDB.Driver;
using Repository.Models;
using Send.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ChatRepository
    {
        private IMongoDatabase _db;
        public ChatRepository()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            _db = client.GetDatabase("UserDB");
        }

        public Task StoreChatMessage(Message message)
        {
            try
            {
                _db.GetCollection<Message>("Messages").InsertOne(message);
                return Task.FromResult<object>(message);
            }
            catch
            {
                Console.WriteLine("Exception caught");
                return Task.FromResult<object>(null);
            }
        }
        public List<ChatThread> getMyActiveThreads(Users userInfo)
        {
            return _db.GetCollection<ChatThread>("ChatThread").Find(c => c.Active == true && c.ReceipientsId.Contains(userInfo.Id)).ToList();
        }
    }
}
