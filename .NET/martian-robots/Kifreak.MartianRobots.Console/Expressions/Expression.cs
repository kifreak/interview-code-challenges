using System;
using System.Collections.Generic;
using System.Reflection;
using Kifreak.MartianRobots.Console.Expressions.Interfaces;
using Kifreak.MartianRobots.Console.ViewModel;

namespace Kifreak.MartianRobots.Console.Expressions
{
    public class Expression : IExpression
    {
        private readonly IDataParser _parser;

        public Expression(IDataParser parser)
        {
            _parser = parser;
        }
        public void Interpret(EntryData context, string property, string item)
        {
            PropertyInfo propertyDefinition = context.GetType().GetProperty(property);
            if (propertyDefinition == null)
            {
                throw new NullReferenceException("Not found Property: " + property);
            }

            var propertyType = propertyDefinition.PropertyType;
            if (propertyType.IsGenericType && (propertyType.GetGenericTypeDefinition()) == typeof(List<>))
            {
                var list = propertyDefinition.GetValue(context);
                propertyType.GetMethod("Add")?.Invoke(list, new[] {_parser.Parse(item)});
            }
            else
            {
                propertyDefinition.SetValue(context, _parser.Parse(item));
            }
        }
    }
}