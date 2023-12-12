namespace ExceptionAttribute.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class ThrowExceptionHereAttribute : Attribute
    {
        public Type type { get; set; }
        public string Name { get; set; }

        public ThrowExceptionHereAttribute(Type type)
        {
            this.type = type;
            this.Name = type.FullName;
        }
    }
}