using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Pages.AmazonPages.ShoppingBasket
{
    public partial class ShoppingBasketPage
    {   
        public bool CheckItem(string item)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                if (ItemsList[i].Text.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
