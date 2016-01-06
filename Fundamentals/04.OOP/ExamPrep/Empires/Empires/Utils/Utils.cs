namespace Empires.Utils
{
    using System;

    internal static class IdGenerator
    {
        private static ulong nextId;

        public static ulong GenerateID()
        {
            nextId++;
            return nextId;
        }
    }

    internal class Utils
    {
        public static dynamic CastTo(object obj, Type castTo)
        {
            return Convert.ChangeType(obj, castTo);
        }
    }
}