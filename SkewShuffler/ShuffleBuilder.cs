using System;
using System.Collections.Generic;

namespace SkewShuffler
{
    public class ShuffleBuilder<T>
    {
        private Dictionary<T, double> intervals = new Dictionary<T, double>();
        private double totalresources = 0; // Total of all resources needed for all items
        private double maxinterval = 0; // Total of all weightings

        public ShuffleBuilder(Dictionary<T, double> items)
        {
            // Calculate total resources
            foreach (KeyValuePair<T, double> kvp in items)
            {
                totalresources += kvp.Value;
            }

            // Calculate individual weighting
            foreach (KeyValuePair<T, double> kvp in items)
            {
                double _interval = totalresources / kvp.Value; // Weighting is total over invididual resources
                intervals.Add(kvp.Key, _interval);
                maxinterval += _interval;
            }
        }

        public Shuffler<T> BuildShuffler()
        {
            // Using a List<ShuffleItem> to keep things in order
            List<ShuffleItem<T>> weightings = new List<ShuffleItem<T>>();

            double acc = 0f; // Bottom range of interval
            foreach (KeyValuePair<T, double> kvp in intervals)
            {
                acc += kvp.Value;
                var item = new ShuffleItem<T>(kvp.Key, acc);
                weightings.Add(item);
            }

            return new Shuffler<T>(weightings, maxinterval);
        }
    }
}
