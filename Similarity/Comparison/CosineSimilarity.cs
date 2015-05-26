using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Similarity.Comparison
{
    public static class CosineSimilarity
    {
        /// <summary>
        /// Returns the Cosine Similarity for two Text Items
        /// </summary>
        /// <param name="item">The first item</param>
        /// <param name="ItemToCompare">The Second Item</param>
        /// <returns>The Score of the Cosine Similarity (-1 to 1) 1 being a perfect match.</returns>
        public static Double CosineCoefficient(this ComparisonItem item, ComparisonItem ItemToCompare)
        {
            return CosineCoefficient(ComparisonGenerator(item.Attributes, ItemToCompare.Attributes));
        }
        /// <summary>
        /// Takes two Word Count Dictionaries and creates a List of Tuples(int, int).
        /// This list represents each word found in both Dictionary 1 and Dictionary 2.
        /// Example:
        /// WordCount1 = {"Brown" : 5, "Cow" : 6}
        /// WordCount2 = {"Brown" : 3, "Chicken : 4}
        /// Results would be [{5,3}, {6,0}, {0,4}]
        /// </summary>
        /// <param name="val1">The WordCount Dictionary from TextItem 1</param>
        /// <param name="val2">The WordCount Dictionary from TextItem 2</param>
        /// <returns>The List of points consisting of the counts from bost lists. Used for Comparison. </returns>
        private static List<Tuple<double, double>> ComparisonGenerator(Dictionary<string, double> val1, Dictionary<string, double> val2)
        {
            //Create a new List to store the results
            var result = new List<Tuple<double, double>>();
            //Go through each word in val1
            foreach (var word in val1)
            {
                //If it doesn't exist in the second dictionary
                if (!val2.ContainsKey(word.Key))
                {
                    // Add its value and 0 to the result tuple (Val,0)
                    result.Add(new Tuple<double, double>(word.Value, 0));
                }
            }
            foreach (var word in val2)
            {
                //If it doesn't exist in the first dictionary
                if (!val1.ContainsKey(word.Key))
                {
                    // Add its value and 0 to the result tuple (0, Val)
                    result.Add(new Tuple<double, double>(0, word.Value));
                }
                else
                {
                    //It exists in both val1 and val2 so add their values to the result (Val1, Val2)
                    result.Add(new Tuple<double, double>(val1[word.Key], word.Value));
                }
            }
            return result;
        }
        /// <summary>
        /// Calculate the Cosine Coefficient
        /// Based on http://en.wikipedia.org/wiki/Cosine_similarity
        /// </summary>
        /// <param name="values">The List of related values [{5,3}, {6,0}, {0,4}]</param>
        /// <returns>The Cossine Similarity between the two</returns>
        private static Double CosineCoefficient(List<Tuple<double, double>> values)
        {
            double num = 0,
                   a = 0,
                   b = 0,
                   den = 0;
            foreach (var set in values)
            {
                //Numerator = sum of a*b
                num += set.Item1 * set.Item2;
                //Sum of A^2
                a += Math.Pow(set.Item1, 2);
                //Sum of B^2
                b += Math.Pow(set.Item2, 2);
            }
            //root of the sum of a^2 * the root of the sum of b^2
            den = Math.Sqrt(a) * Math.Sqrt(b);
            if (den == 0) return 0;
            var similarity = Math.Round(num / den, 3);
            return 1 - (Math.Acos(similarity) / Math.PI);
        }
    }
}
