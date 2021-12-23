using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodax.Sections.ShoppingCartMini
{
    public partial class ShoppingCartMiniSection
    {
        public float GetTotalAmount()
        {
            MainHeaderSection.OpenShoppingCart();
            if (MainHeaderSection.GetShoppingCartCounter() > 0)
            {
                return float.Parse(TotalAmountLabel.GetAttribute("data-qa-total"), CultureInfo.InvariantCulture);
            }
            return 0;
        }
    }
}
