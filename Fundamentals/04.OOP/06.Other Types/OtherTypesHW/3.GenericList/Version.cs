namespace _3.GenericList
{
    using System;

    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Struct |
        AttributeTargets.Interface |
        AttributeTargets.Enum |
        AttributeTargets.Method
        )]
    internal class VersionAttribute : Attribute
    {
        public VersionAttribute(double version)
        {
            this.Version = version;
        }

        public double Version { get; }
    }
}