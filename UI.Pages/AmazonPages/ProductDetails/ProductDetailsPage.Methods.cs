using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Pages.AmazonPages.ProductDetails
{
    public partial class ProductDetailsPage
    {
        public string GetProducName()
        {
            return ProductTitleLabel.Text;
        }

        public bool HasBadge()
        {
            return IsElementExist(ProductBadge);
        }

        public string GetPrice()
        {
            return ProductPriceLabel.Text;
        }

        public string GetSelectedFormat()
        {
            return SelectedFormatButton.Text;
        }

        public void AddProductToBasket()
        {
            AddToBacketButton.Click();
        }

        public bool HasNewItemInBasketNotification()
        {
            return IsElementExist(NewItemInBasketNotification);
        }
    }
}
