using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

Dictionary<string, string> properties = CallContext.GetData("rsprop") as Dictionary<string, string>;

string message = null;
properties.TryGetValue("message", out message);

Console.WriteLine(message);
message