using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Repository.Models;

namespace Repository.Repositories
{
    public class UserRepository
    {
        private IMongoDatabase _db;
        public UserRepository()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            _db = client.GetDatabase("UserDB");

        }
        public List<Users> GetLoggedInUsers()
        {
            return _db.GetCollection<Users>("Users").Find(u => u.isLoggedin == true).ToList();
        }
        public Users IsValidUser(string userEmail)
        {
            return _db.GetCollection<Users>("Users").Find(u => u.Username == userEmail).FirstOrDefault();
        }
        public bool InsertThread(ChatThread chatThread)
        {
            try
            {
                _db.GetCollection<ChatThread>("ChatThread").InsertOne(chatThread);
                return true;
            }
            catch
            {
                Console.WriteLine("Exception caught");
                return false;
            }
        }
    }
}
