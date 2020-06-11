namespace MinhaFloresta.Repository.DatabaseSettings
{
    public interface IDatabaseSettings
    {
        string MinhaFlorestaCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
