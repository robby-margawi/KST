using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment
{
    /// <summary>
    /// The name resolver class.
    /// </summary>
    public class SortNameComparer : IComparer<string>
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="x">First string to compare.</param>
        /// <param name="y">Second string to compare.</param>
        /// <returns></returns>
        public int Compare(string x, string y)
        {
            if (string.IsNullOrWhiteSpace(x)) throw new ArgumentNullException(nameof(x));
            if (string.IsNullOrWhiteSpace(y)) throw new ArgumentNullException(nameof(y));

            var xSegments = x.Split(new char[] { ' ' }, StringSplitOptions.None);

            var ySegments = y.Split(new char[] { ' ' }, StringSplitOptions.None);

            var lastNameComparison = StringComparer.InvariantCulture.Compare(xSegments.Last(), ySegments.Last());

            if (lastNameComparison != 0)
                return lastNameComparison;

            for (var i = 0; i < xSegments.Length - 1 && i < ySegments.Length - 1; i++)
            {
                var giveNameComparison = StringComparer.InvariantCulture.Compare(xSegments[i], ySegments[i]);
                if (giveNameComparison == 0)
                    continue;
                else
                    return giveNameComparison;
            }

            return 0;
        }
    }
}
