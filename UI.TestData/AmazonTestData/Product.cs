using System.Collections;
using System.IO;

namespace UI.TestData.AmazonTestData
{
    public class Product
    {
        public string Type { get; set; }
        public string SearchName { get; set; }
        public string ExpectedName { get; set; }
        public string Badge { get; set; }
        public string Price { get; set; }

        public static IEnumerable SetValues_AssertFirstShowedSearchProductAvailability
        {
            get
            {
                string inputLine;

                using FileStream inputStream =
                    new("AmazonTestData\\SourceFiles\\AssertFirstShowedSearchProductAvailability.csv",
                        FileMode.Open,
                        FileAccess.Read);

                StreamReader streamReader = new(inputStream);

                while ((inputLine = streamReader.ReadLine()) != null)
                {
                    var data = inputLine.Split(';');
                    yield return new Product
                    {
                        Type = data[0],
                        SearchName = data[1],
                        ExpectedName = data[2]
                    };
                }

                streamReader.Close();
                inputStream.Close();
            }
        }

        public static IEnumerable SetValues_AssertSearchProductHasBadge
        {
            get
            {
                string inputLine;

                using FileStream inputStream =
                    new("AmazonTestData\\SourceFiles\\AssertSearchProductHasBadge.csv",
                        FileMode.Open,
                        FileAccess.Read);

                StreamReader streamReader = new(inputStream);

                while ((inputLine = streamReader.ReadLine()) != null)
                {
                    var data = inputLine.Split(';');
                    yield return new Product
                    {
                        Type = data[0],
                        SearchName = data[1],
                        Badge = data[2]
                    };
                }

                streamReader.Close();
                inputStream.Close();
            }
        }

        public static IEnumerable SetValues_AssertSearchProductPrice
        {
            get
            {
                string inputLine;

                using FileStream inputStream =
                    new("AmazonTestData\\SourceFiles\\AssertSearchProductPrice.csv",
                        FileMode.Open,
                        FileAccess.Read);

                StreamReader streamReader = new(inputStream);

                while ((inputLine = streamReader.ReadLine()) != null)
                {
                    var data = inputLine.Split(';');
                    yield return new Product
                    {
                        Type = data[0],
                        SearchName = data[1],
                        Price = data[2].Replace(@"\n", "\n").Replace(@"\r", "\r")
                    };
                }

                streamReader.Close();
                inputStream.Close();
            }
        }
    }
}
