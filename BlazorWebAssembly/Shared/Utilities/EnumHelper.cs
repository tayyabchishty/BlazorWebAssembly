using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Shared.Utilities
{
    public class EnumHelper
    {
        public static List<DropDownListItems> ConvertEnumtoDropDownSource<T>(string initialText,string initialValue)
        {
            List<DropDownListItems> ret = new List<DropDownListItems>();
            var values = Enum.GetValues(typeof(T)).Cast<T>().ToList();

            if (!string.IsNullOrEmpty(initialText) || !string.IsNullOrEmpty(initialValue))
            {
                DropDownListItems ddlInitialItem = new DropDownListItems
                {
                    Text=initialText,
                    Value=initialValue
                };
                ret.Add(ddlInitialItem);
            }

            for (int i = 0; i < Enum.GetNames(typeof(T)).Length; i++)
            {
                DropDownListItems ddlItems = new DropDownListItems();
                ddlItems.Text = Enum.GetNames(typeof(T))[i];
                ddlItems.Value = values[i].ToString();

                ret.Add(ddlItems);
            }

            return ret;
        }
    }
}
