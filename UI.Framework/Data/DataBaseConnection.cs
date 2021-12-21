using Newtonsoft.Json;
using Npgsql;
using System.IO;
using System.Text.Json;

namespace UI.Framework.Data
{

    public class DataBaseConnection
    {
        private string Connection { get; set; }
        private string Table { get; set; }

    public DataBaseConnection()
        {
            var configData = JsonConvert.DeserializeObject<FrameworkData>(File.ReadAllText("Data\\Framework.json"));
            Connection = $"Host={configData.PostgreHost};Username={configData.PostgreUsername};Password={configData.PostgrePassword};Database={configData.PostgreDatabase}";
            Table = configData.PostgreTable;
        }

        public string GetLocatorByName(string locatorName)
        {
            using var connection = new NpgsqlConnection(Connection);
            connection.Open();
            using var script = new NpgsqlCommand($"SELECT element_locator FROM {Table} WHERE element_name='{locatorName}'", connection);
            string elementLocator = script.ExecuteScalar().ToString();
            connection.Close();

            return elementLocator;
        }







    }
}
