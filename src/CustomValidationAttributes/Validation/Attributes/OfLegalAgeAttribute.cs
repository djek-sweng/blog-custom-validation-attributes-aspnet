using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Validation.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
public sealed class OfLegalAgeAttribute : ValidationAttribute
{
    private const int _LEGAL_AGE = 18;
    private int _age;

    public OfLegalAgeAttribute()
    {
        _age = -1;
    }

    public override bool IsValid(object? value)
    {
        if (value is null)
            return false;

        _age = (int)value;

        return IsOfLegalAge(_age);
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(CultureInfo.CurrentCulture,
            $"The property, field or parameter '{name}' is invalid, because no legal age is given. " +
            $"The value of '{name}' is '{_age}', but must be at least '{_LEGAL_AGE}'.");
    }

    private static bool IsOfLegalAge(int age)
    {
        return age > _LEGAL_AGE - 1;
    }
}
