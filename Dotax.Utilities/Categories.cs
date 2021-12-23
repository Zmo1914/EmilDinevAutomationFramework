using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotax.Utilities
{
    public sealed class Categories:SmartEnum<Categories>
    {
        public static readonly Categories Books = new("Books & Audiobooks", 1);

        public Categories(string name, int value):base(name,value)
        {

        }

    }

}
