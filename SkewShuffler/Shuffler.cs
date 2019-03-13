using System;
using System.Collections.Generic;
using System.Text;

namespace SkewShuffler
{
    public class Shuffler<T>
    {
        public double MaxInterval { get; private set; } // Total of all weightings
        private readonly List<ShuffleItem<T>> items;

        // Takes a random double within interval range
        public T this[double interval]
        {
            get
            {
                foreach (ShuffleItem<T> item in items)
                {
                    if (item.Interval > interval)
                    {
                        return item.Contents;
                    }
                }
                throw new IndexOutOfRangeException("Interval out of bounds");
            }
        }

        internal Shuffler(List<ShuffleItem<T>> items, double max)
        {
            this.items = items;
            MaxInterval = max;
        }
    }
}
