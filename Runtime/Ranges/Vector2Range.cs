using UnityEngine;

namespace Gangplank.Ranges
{
    public class Vector2Range : Range<Vector2>
    {
        public Vector2Range()
        {
        }

        public Vector2Range(Vector2 start, Vector2 end) : base(start, end)
        {
        }

        public override Vector2 Interpolate(float t)
        {
            return Vector2.Lerp(Start, End, t);
        }
    }
}