namespace Xfx
{
    public struct ConnectionStringSettings
    {
        public ConnectionStringSettings(string name, string providerName, string connectionString)
        {
            Name = name;
            ProviderName = providerName;
            ConnectionString = connectionString;
        }

        public string Name { get; }
        public string ProviderName { get; }
        public string ConnectionString { get; }
    }
}