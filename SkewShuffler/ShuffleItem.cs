using System;
using System.Collections.Generic;
using System.Text;

namespace SkewShuffler
{
    internal class ShuffleItem<T>
    {
        public T Contents { get; set; }
        public double Interval { get; set; }

        public ShuffleItem(T contents, double interval)
        {
            Contents = contents;
            Interval = interval;
        }
    }
}
