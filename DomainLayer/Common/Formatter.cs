using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Common
{
    public class Formatter : IFormatter
    {
        private TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public string ToProperCase(string input)
        {
            return textInfo.ToTitleCase(input.Trim().ToLowerInvariant());
        }
    }
}
