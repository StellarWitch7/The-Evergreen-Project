using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Evergreen.App.Util
{
    public static class Generators
    {
        public static string RandomString(int length, ref List<string> ignored, bool addResultToIgnored)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            bool generating = true;
            var newString = string.Empty;

            while (generating == true)
            {
                generating = false;
                newString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
                
                foreach (string value in ignored)
                {
                    if (newString == value)
                    {
                        generating = true;
                    }
                }
            }

            if (addResultToIgnored)
            {
                ignored.Add(newString);
            }

            return newString;
        }
    }
}
