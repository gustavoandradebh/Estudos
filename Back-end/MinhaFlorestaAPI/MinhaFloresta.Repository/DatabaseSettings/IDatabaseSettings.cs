namespace MinhaFloresta.Repository.DatabaseSettings
{
    public interface IDatabaseSettings
    {
        string PlantsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
