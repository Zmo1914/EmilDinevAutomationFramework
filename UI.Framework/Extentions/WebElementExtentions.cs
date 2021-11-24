using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Framework.Extentions
{
    public static class WebElementExtentions
    {

        public static void SelectValueByText(this SelectElement selectElement, string valueByText)
        {
            string valueByTextNoSpaces = String.Concat(valueByText.Where(c => !Char.IsWhiteSpace(c)));

            for (int i = 0; i < selectElement.Options.Count; i++)
            {
                string text = String.Concat(selectElement.Options[i].Text.Where(c => !Char.IsWhiteSpace(c)));

                if (valueByTextNoSpaces.Equals(text))
                {
                    selectElement.SelectByIndex(i);
                    break;
                }
            }
        }
    }
}
