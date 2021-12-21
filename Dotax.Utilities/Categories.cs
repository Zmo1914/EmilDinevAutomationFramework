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
        public static readonly Categories MoviesMusicMedia = new("Movies, Music & Gaming", 1);
        public static readonly Categories Books = new("Books & Audiobooks", 2);

        public Categories(string name, int value):base(name,value)
        {

        }

    }

}
