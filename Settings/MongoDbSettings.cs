namespace Play.Common.Settings
{
    public class MongoDbSettings
    {

        public static string SettingName = "MongoDbSettings";

        public string Host { get; init; }

        public string Port { get; init; }

        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}