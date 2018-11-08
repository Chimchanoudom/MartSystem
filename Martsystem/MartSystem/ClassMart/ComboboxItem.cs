using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartSystem
{
    public class ComboboxItem
    {
        string Text { get; set; }
        public string Value { get; set; }

        public ComboboxItem()
        {

        }

        public ComboboxItem(string Text,string Value)
        {
            this.Text = Text;
            this.Value = Value;
        }

        public override string ToString()
        {
            return Text.ToString();
        }

        
    }
}
