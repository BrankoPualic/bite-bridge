namespace BiteBridge.Persistence.Configurations.Seeds.Interfaces;

public interface ISeedData<T>
    where T : class
{
    IEnumerable<T> SeedData();
}