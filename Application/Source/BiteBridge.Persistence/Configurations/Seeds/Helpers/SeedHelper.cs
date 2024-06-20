using BiteBridge.Persistence.Configurations.Seeds.Interfaces;

namespace BiteBridge.Persistence.Configurations.Seeds.Helpers;

public static class SeedHelper
{
    public static IEnumerable<T> GetSeedData<T, TSeeder>()
        where T : class
        where TSeeder : ISeedData<T>, new()
    {
        return new TSeeder().SeedData();
    }
}