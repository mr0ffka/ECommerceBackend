﻿namespace ECommerce.Application.Extensions
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);
        public static bool HasValue(this string s) => !IsNullOrEmpty(s);
    }
}
