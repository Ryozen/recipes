using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Recipes.Core;
using Recipes.Shared;

namespace Recipes.Tests
{
    public class CoreTests
    {
        public class RunnerTest
        {
            [Fact]
            public void ExecuteCSharpBasicSuccess()
            {
                string expected = "hello world";

                ScriptContext context = new ScriptContext()
                {
                    Type = "csharp",
                    Name = "writer",
                    Parameters = new Dictionary<string, string>() 
                {
                    { "message", "hello world" }
                }
                };

                ExecutionResult result = Runner.Execute(context);
                Assert.Equal<string>(expected, result.Output);

            }
        }

    }
}
