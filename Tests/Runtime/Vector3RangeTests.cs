using NUnit.Framework;
using Gangplank.Ranges;
using UnityEngine;

namespace Gangplank.Tests
{
    [TestFixtureSource("Vector3RangeTestArgs")]
    public class Vector3RangeTests : RangeTests<Vector3>
    {
        static object[] Vector3RangeTestArgs =
{
            new object[] { Vector3.zero, Vector3.one },
            new object[] { Vector3.left, Vector3.right },
            new object[] { Vector3.left, Vector3.forward },
        };

        public Vector3RangeTests(Vector3 start, Vector3 end) : base(new Vector3Range(start, end))
        {
        }
    }
}