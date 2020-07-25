using UnityEngine;

namespace Gangplank.Ranges
{
    public class Vector3Range : Range<Vector3>
    {
        public Vector3Range()
        {
        }

        public Vector3Range(Vector3 start, Vector3 end) : base(start, end)
        {
        }

        public override Vector3 Interpolate(float t)
        {
            return Vector3.Lerp(Start, End, t);
        }
    }
}