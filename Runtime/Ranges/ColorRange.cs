using UnityEngine;

namespace Gangplank.Ranges
{
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
    }
}