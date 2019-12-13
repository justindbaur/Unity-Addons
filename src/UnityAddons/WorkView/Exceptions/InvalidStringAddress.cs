﻿using System;

namespace UnityAddons.WorkView
{
    public class InvalidStringAddressException : Exception
    {
        public string Address { get; }

        public InvalidStringAddressException(string address) : base($"Invalid string address: { address }")
        {
            Address = address;
        }

        public InvalidStringAddressException() : this("Unknown")
        { }
    }
}