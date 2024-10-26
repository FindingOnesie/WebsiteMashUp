using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteModels.MongoModels;

namespace WebsiteModels.MongoRepos {
    public class UserRepository {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings) {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _users = database.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetUsersAsync() => await _users.Find(_ => true).ToListAsync();

        public async Task<User> GetUserByIdAsync(string id) =>
            await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

        public async Task CreateUserAsync(User user) => await _users.InsertOneAsync(user);

        public async Task UpdateUserAsync(string id, User updatedUser) =>
            await _users.ReplaceOneAsync(user => user.Id == id, updatedUser);

        public async Task DeleteUserAsync(string id) =>
            await _users.DeleteOneAsync(user => user.Id == id);
    }
}
