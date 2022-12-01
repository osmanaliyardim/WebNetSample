﻿using System.ComponentModel.DataAnnotations;

namespace WebNetSample.Business.ValidationRules;

public class DefaultValueAttribute : ValidationAttribute
{
    public override bool IsValid(object value) =>
        value switch
        {
            Guid guid => guid != default,
            string @string => !string.IsNullOrEmpty(@string),
            int @int => @int != default,
            var _ => true
        };
}