﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipes.Shared
{
    public interface IScriptRunner
    {

        string Name { get; }
        RunnerCatalog RunnerCatalog { get; set; }
        ExecutionResult Execute(ScriptContext context);
        List<ScriptDefinition> GetScripts();

    }
}
