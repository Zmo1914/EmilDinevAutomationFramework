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
            var con = JsonConvert.DeserializeObject<FrameworkData>(File.ReadAllText("Data\\Framework.json"));
            Connection = $"Host={con.PostgreHost};Username={con.PostgreUsername};Password={con.PostgrePassword};Database={con.PostgreDatabase}";
            Table = con.PostgreTable;
        }

        public string GetLocatorByName(string locatorName)
        {
            using var con = new NpgsqlConnection(Connection);
            con.Open();
            using var cmd = new NpgsqlCommand($"SELECT element_locator FROM {Table} WHERE element_name='{locatorName}'", con);
            string locator = cmd.ExecuteScalar().ToString();
            con.Close();

            return locator;
        }







    }
}
