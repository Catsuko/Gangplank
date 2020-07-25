using NUnit.Framework;
using Gangplank.Ranges;
using UnityEngine;

namespace Gangplank.Tests
{
    [TestFixtureSource("Vector2RangeTestArgs")]
    public class Vector2RangeTests : RangeTests<Vector2>
    {
        static object[] Vector2RangeTestArgs =
{
            new object[] { Vector2.zero, Vector2.one },
            new object[] { Vector2.left, Vector2.right },
            new object[] { Vector2.left, Vector2.up },
        };

        public Vector2RangeTests(Vector2 start, Vector2 end) : base(new Vector2Range(start, end))
        {
        }
    }
}
