using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Core.CrossCuttingConcerns.Caching.Redis.RedisServer
{
    public class RedisServerConnection                // REDİS SUNUCU AYARLARI
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;
        private string ConfigurationString;
        private readonly int _currentDataBaseId = 0;

        public RedisServerConnection(IConfiguration configuration)
        {
            CreateRedisConnection(configuration);
            _connectionMultiplexer = ConnectionMultiplexer.Connect(ConfigurationString);
            _database = _connectionMultiplexer.GetDatabase(_currentDataBaseId);
        }

        public IDatabase Database => _database;

        public void FlushDatabase() => _connectionMultiplexer.GetServer(ConfigurationString).FlushDatabase(_currentDataBaseId);
        private void CreateRedisConnection(IConfiguration configuration)
        {
            string host = configuration.GetSection("RedisConfiguration:Host").Value;
            string port = configuration.GetSection("RedisConfiguration:Port").Value;

            ConfigurationString = $"{host}:{port}";
        }
    }
}
