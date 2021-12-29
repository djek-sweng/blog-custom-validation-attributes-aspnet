using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Validation.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
public sealed class LettersOnlyAttribute : ValidationAttribute
{
    private const string _REGEX_PATTERN = "^[a-zA-Z]*$";
    private string _text;

    public LettersOnlyAttribute()
    {
        _text = string.Empty;
    }

    public override bool IsValid(object? value)
    {
        if (value is null)
            return false;

        _text = (string)value;

        return IsLettersOnly(_text);
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(CultureInfo.CurrentCulture,
            $"The property, field or parameter '{name}' is invalid, because only letters are allowed. " +
            $"The value of '{name}' is '{_text}', but must match regex pattern '{_REGEX_PATTERN}'.");
    }

    private static bool IsLettersOnly(string text)
    {
        var regex = new Regex(_REGEX_PATTERN);

        return regex.IsMatch(text);
    }
}
