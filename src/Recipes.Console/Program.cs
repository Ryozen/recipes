using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDesk.Options;
using Recipes.Shared;
using Recipes.Core;

namespace Recipes.Console
{
    class Program
    {

        const string COPYRIGHT = 
            "Recipes - Windows Scripts Management System\r\n" +
            "(c) 2012 NewSkies Innovation Center\r\n\r\n" +
            "ALPHA Software. Use at your own risk!!!";

        static void Main(string[] args)
        {

            Dictionary<string, string> properties = new Dictionary<string, string>();

            System.Console.WriteLine(COPYRIGHT);

            var p = new OptionSet()
            {
                { "p:", "Properties for scripts", (m, v) => 
                    {
                        properties.Add(m, v);
                    }
                }
            };

            var scriptName = p.Parse(args).FirstOrDefault();

            Runner.Execute(scriptName, properties);
            
        }
    }
}
