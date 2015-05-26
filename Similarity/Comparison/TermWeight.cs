using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Similarity.Comparison
{
    /// <summary>
    /// Uses Term Frequency - Inverse Document Frequency to create a weight for a term.
    /// </summary>
    public static class TermWeight
    {
        /// <summary>
        /// Used to calculate the Term Frequency - Inverse Document Frequency of a word.
        /// Make sure that the string contains only one word and that it has been processed in the same way your attributes in the GroupToCompare were.
        /// </summary>
        /// <param name="str">The single word you wish to get a weight for.</param>
        /// <param name="GroupToCompare">The group you are using to find it's weight</param>
        /// <returns>The weight for the word, higher values means the term is more substantial</returns>
        public static double GetTermWeight(this String str, ComparisonGroup GroupToCompare)
        {
            //Check to see that the term exists in the group
            if(GroupToCompare.AttributeFrequency(str) == 0) return 0;
            //log(N/nt)
            return Math.Log10(1 + GroupToCompare.ItemCount / GroupToCompare.AttributeFrequency(str));
        }

        public static List<Tuple<ComparisonItem, Double>> SearchScore(this ComparisonItem mainItem, ComparisonGroup GroupToCompare)
        {
            var ret = new List<Tuple<ComparisonItem, Double>>();
            //Iterate through the group of items to calculate that items score
            foreach(var item in GroupToCompare.Items)
            {
                //Holds the sum of the score for this item
                var sum = 0.0;
                //Iterate through each term
                foreach(var term in mainItem.Attributes)
                {
                    var itemValue = item.GetValue(term.Key);
                    var termWeight = GetTermWeight(term.Key, GroupToCompare);
                    var maxValue = GroupToCompare.MaxAttributeOccurence(term.Key);
                    //If the term exists 
                    if (maxValue != 0 && itemValue != 0) sum += (itemValue / (maxValue)) * termWeight;
                }
                ret.Add(new Tuple<ComparisonItem, double>(item, sum));
            }
            return ret;
        }
        public static List<Tuple<ComparisonItem, Double>> SearchScore(this String search, ComparisonGroup GroupToCompare)
        {
            return SearchScore(new ComparisonItem(Processing.WordCount.GetWordCount(search)), GroupToCompare);
        }
    }
}
