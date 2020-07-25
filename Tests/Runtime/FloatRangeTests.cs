using NUnit.Framework;
using Gangplank.Ranges;

namespace Gangplank.Tests
{
    [TestFixture(0f, 10f)]
    [TestFixture(-5f, 5f)]
    [TestFixture(100f, 90f)]
    [TestFixture(37.5f, -37.5f)]
    public class FloatRangeTests : RangeTests<float>
    {
        public FloatRangeTests(float start, float end) : base(new FloatRange(start, end))
        {
        }
    }
}