using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Core.CrossCuttingConcerns.Caching.Redis.RedisServer
{
    public class RedisServerConnection : IRedisServerConnection           // REDİS SUNUCU AYARLARI
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        public  IDatabase Database { get; set; }
        private string ConfigurationString;
        private readonly int _currentDataBaseId = 0;

        public RedisServerConnection()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            CreateRedisConnection(configuration);
            _connectionMultiplexer = ConnectionMultiplexer.Connect(ConfigurationString);
            Database = _connectionMultiplexer.GetDatabase(_currentDataBaseId);
        }


        public void FlushDatabase() => _connectionMultiplexer.GetServer(ConfigurationString).FlushDatabase(_currentDataBaseId);
        private void CreateRedisConnection(IConfiguration configuration)
        {
            string host = configuration.GetSection("RedisConfiguration:Host").Value;
            string port = configuration.GetSection("RedisConfiguration:Port").Value;
            ConfigurationString = $"{host}:{port}";
        }
    }
}
