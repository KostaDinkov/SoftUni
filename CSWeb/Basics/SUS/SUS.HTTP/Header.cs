﻿using System;

namespace SUS.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public Header(string headerString)
        {
            var parts = headerString.Split(new[] {": "}, 2, StringSplitOptions.None);
            Name = parts[0];
            Value = parts[1];
        }



        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}