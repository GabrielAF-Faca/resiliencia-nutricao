using System;

namespace Ufn.Resiliencia.Api.Portal.Domain.Extensions;
public static class StringExtensions
{
    public static bool IsGuid(this string value)
    {
        return Guid.TryParse(value, out _);
    }
}