namespace MinhaFloresta.Repository.DatabaseSettings
{
    public class MinhaFlorestaMongoDbSettings : IDatabaseSettings
    {
        public string MinhaFlorestaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
