namespace ExceptionAttribute.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using ExceptionAttribute.Attributes;
    using Newtonsoft.Json;

    public class ExceptionAttributeModule
    {
        public void RandomException(Assembly assembly)
        {
            var returnString = "";
            var classesToPickFrom = new List<ThrowExceptionHereAttribute>();
            
            foreach (var type in assembly.GetTypes())
            {
                var classes = type.GetCustomAttributes(typeof(ThrowExceptionHereAttribute), true);

                foreach (var clas in classes)
                {
                    classesToPickFrom.Add((ThrowExceptionHereAttribute) clas);
                    var json = JsonConvert.SerializeObject(clas, Formatting.Indented);
                    returnString += json + Environment.NewLine;
                }
            }

            var rand = Random.Shared.Next(classesToPickFrom.Count);
            var selected = classesToPickFrom[rand];

            throw new Exception($"Exception thrown in {selected.Name}: {selected.type.Namespace}");
        }
    }
}