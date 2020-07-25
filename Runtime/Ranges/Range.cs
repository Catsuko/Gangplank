using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;

namespace Gangplank.Ranges
{
    /// <summary>
    /// Represents a set of values with a start and end.
    /// </summary>
    /// <typeparam name="TValue">Type of value represented by the range.</typeparam>
    public abstract class Range<TValue>
    {
        [SerializeField]
        private TValue _start, _end;

        public TValue Start { get { return _start; } }
        public TValue End { get { return _end; } }

        public Range()
        {
        }

        public Range(TValue start, TValue end)
        {
            _start = start;
            _end = end;
        }

        public abstract TValue Interpolate(float t);
 
        public TValue Random()
        {
            return Interpolate(UnityEngine.Random.value);
        }

        public IEnumerable<TValue> Walk(float stepSize)
        {
            return Walk(() => stepSize);
        }

        public IEnumerable<TValue> Walk(Func<float> stepDelegate)
        {
            float time = 0, previousTime = 0;
            while (time < 1 || (previousTime < 1 && time >= 1))
            {
                yield return Interpolate(time);
                previousTime = time;
                time += stepDelegate.Invoke();
            }
        }

        public IEnumerator Walk(Action<TValue> valueHandler, Func<float> stepDelegate)
        {
            foreach(var step in Walk(stepDelegate))
            {
                valueHandler.Invoke(step);
                yield return null;
            }
        }
    }
}

