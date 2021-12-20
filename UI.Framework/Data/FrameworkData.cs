using Newtonsoft.Json;
using System.IO;

namespace UI.Framework.Data
{
    public sealed class FrameworkData
    {
        private static readonly FrameworkData instance = new FrameworkData();

        public string PostgreHost { get; set; }
        public string PostgreUsername { get; set; }
        public string PostgrePassword { get; set; }
        public string PostgreDatabase { get; set; }
        public string PostgreTable { get; set; }


        public static FrameworkData Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
