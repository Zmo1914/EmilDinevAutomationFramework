using Dotax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodax.Sections.MainHeader
{
    public partial class MainHeaderSection
    {
        public void Search(string productName, Categories categories)
        {
            string categrie = categories.ToString();

            HeaderSearchBarSelect.SelectByText(categrie);
            HeaderSearchBarInput.SendKeys(productName);

            HeaderSearchBarButton.Click();
        }
    }
}
