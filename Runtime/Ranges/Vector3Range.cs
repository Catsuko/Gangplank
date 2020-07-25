using System;
using UnityEngine;

namespace Gangplank.Ranges
{
    [Serializable]
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

        public override bool Contains(Vector3 value)
        {
            return value.x.IsWithin(Start.x, End.x) &&
                   value.y.IsWithin(Start.y, End.y) &&
                   value.z.IsWithin(Start.z, End.z);
        }
    }
}