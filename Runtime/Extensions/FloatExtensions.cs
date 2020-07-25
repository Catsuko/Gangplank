using UnityEngine;

namespace Gangplank
{
    internal static class FloatExtensions
    {
        internal static bool IsWithin(this float value, float a, float b)
        {
            return Mathf.Clamp(value, Mathf.Min(a, b), Mathf.Max(a, b)) == value;
        }
    }
}
