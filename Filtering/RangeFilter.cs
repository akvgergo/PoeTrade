using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade {

    /// <summary>
    /// Used to define a range with minimum and maximum values, or only either.
    /// </summary>
    public class RangeFilter {

        public double? Min { get; set; }
        public double? Max { get; set; }
        
        /// <summary>
        /// Returns a new instance with no defined values.
        /// </summary>
        public static RangeFilter NullRange => new RangeFilter();

        /// <summary>
        /// Whether the range given by the instance is valid. Returns <see cref="false"/> if the ranges have no overlap.
        /// </summary>
        /// <remarks>
        /// Both null values are also considered valid, since that just means we aren't actually filtering.
        /// </remarks>
        public bool IsValid => Min.HasValue && Max.HasValue ? Min <= Max : true;

        /// <summary>
        /// Returns true neither minimum or maximum are defined.
        /// </summary>
        public bool IsNullRange => !Min.HasValue || !Max.HasValue;

        /// <summary>
        /// Returns the middle value of the range, or either the minimum or maximum if only one is defined. NaN if
        /// there is no range.
        /// </summary>
        public double Average => Min.HasValue && Max.HasValue ? (Min.Value + Max.Value) / 2 : Min ?? Max ?? double.NaN;

        public RangeFilter(double min) {
            Min = min;
        }

        public RangeFilter(double? min = null, double? max = null) {
            Min = min;
            Max = max;
        }

        public static implicit operator RangeFilter(double min) => new RangeFilter(min);

        public static implicit operator RangeFilter((double min, double max) range) => new RangeFilter(range.min, range.max);

        public override bool Equals(object obj) {
            return obj is RangeFilter filter &&
                   Min == filter.Min &&
                   Max == filter.Max;
        }

        public override int GetHashCode() {
            int hashCode = 1537547080;
            hashCode = hashCode * -1521134295 + Min.GetHashCode();
            hashCode = hashCode * -1521134295 + Max.GetHashCode();
            return hashCode;
        }
    }
}
