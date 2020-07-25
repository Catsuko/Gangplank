using System;
using UnityEngine;

namespace Gangplank.Ranges
{
    [Serializable]
    public class ColorRange : Range<Color>
    {
        public ColorRange()
        {
        }

        public ColorRange(Color start, Color end) : base(start, end)
        {
        }

        public override Color Interpolate(float t)
        {
            return Color.Lerp(Start, End, t);
        }

        public override bool Contains(Color value)
        {
            return value.r.IsWithin(Start.r, End.r) &&
                   value.g.IsWithin(Start.g, End.g) &&
                   value.b.IsWithin(Start.b, End.b) &&
                   value.a.IsWithin(Start.a, End.a);
        }
    }
}