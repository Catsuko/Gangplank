using System;
using UnityEngine;

namespace Gangplank.Ranges
{
    [Serializable]
    public class FloatRange : Range<float>
    {
        public FloatRange()
        {
        }

        public FloatRange(float start, float end) : base(start, end)
        {
        }

        public override float Interpolate(float t)
        {
            return Mathf.Lerp(Start, End, t);
        }
    }
}