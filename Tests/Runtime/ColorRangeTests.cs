using Gangplank.Ranges;
using UnityEngine;

namespace Gangplank.Tests
{
    public class ColorRangeTests : RangeTests<Color>
    {
        public ColorRangeTests() : base(new ColorRange(Color.red, Color.blue))
        {
        }
    }
}