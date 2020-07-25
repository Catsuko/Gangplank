using NUnit.Framework;
using Gangplank.Ranges;
using System.Linq;
using UnityEngine;

namespace Gangplank.Tests
{
    public abstract class RangeTests<T>
    {
        private readonly Range<T> _range;

        protected RangeTests(Range<T> range)
        {
            _range = range;
        }

        [Test]
        public void StartValueIsFirst ()
        {
            Assert.AreEqual(_range.Start, _range.Walk(0).First());
        }

        [Test]
        public void EndValueIsLast ()
        {
            Assert.AreEqual(_range.End, _range.Walk(0.2f).Last());
        }

        [Test]
        public void RandomValuesAreWithinRange ()
        {
            Random.InitState(0);
            var randomValues = new int[100].Select(n => _range.Random());
            Assert.IsTrue(randomValues.All(_range.Contains));
        }

        [Test]
        public void WalkedValuesAreWithinRange ()
        {
            Assert.IsTrue(_range.Walk(0.1f).All(_range.Contains));
        }
    }
}