﻿using System;
using System.ComponentModel;
using System.Reflection;

namespace HylandAddons.WorkView
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class WorkViewAttributeAttribute : Attribute
    {
        public string Address { get; set; } = null;

        [DefaultValue(false)]
        public bool Optional { get; } = false;


        public WorkViewAttributeAttribute(string address)
        {
            Address = address;
        }

        public WorkViewAttributeAttribute(bool optional = false)
        {
            Optional = optional;
        }

        public static bool IsDefined(PropertyInfo propertyInfo)
        {
            return Attribute.IsDefined(propertyInfo, typeof(WorkViewAttributeAttribute));
        }

        public static string GetStringAddress(PropertyInfo propertyInfo)
        {
            if (propertyInfo is null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }


            return propertyInfo.GetCustomAttribute<WorkViewAttributeAttribute>()?.Address ?? propertyInfo.Name;
        }

        public static AttributeAddress GetAttributeAddress(PropertyInfo propertyInfo)
        {
            return new AttributeAddress(GetStringAddress(propertyInfo));
        }

        public static bool IsOptional(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<WorkViewAttributeAttribute>()?.Optional ?? false;
        }
    }
}
