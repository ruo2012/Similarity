using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Similarity.Comparison_Logic;
using System.Threading.Tasks;

namespace Similarity
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Computes the Cosine Similarity of a string compared to a Comparison Group
        /// </summary>
        /// <param name="MainText">The string that forms the basis of comparison</param>
        /// <param name="Group">The Comparison Group containing all of the other strings to compare the maintext to</param>
        /// <returns>A Dictionary of the Text Item along with its Cosine Similarity</returns>
        public static Dictionary<Iitem, double> CosineSimilarity(this String MainText, ComparisonGroup Group)
        {
            var ret = new Dictionary<Iitem, double>();
            var item = new TextItem(MainText);
            foreach(var otherItem in Group.Items)
            {
                ret.Add(otherItem, item.CosineCoefficient(otherItem));
            }
            return ret;
        }
        /// <summary>
        /// Computes the Cosine Similarity of a TextItem compared to a Comparison Group
        /// </summary>
        /// <param name="MainText">The TextItem that forms the basis of comparison</param>
        /// <param name="Group">The Comparison Group containing all of the other strings to compare the maintext to</param>
        /// <returns>A Dictionary of the Text Item along with its Cosine Similarity</returns>
        public static Dictionary<Iitem, double> CosineSimilarity(this Iitem MainText, ComparisonGroup Group)
        {
            var ret = new Dictionary<Iitem, double>();
            foreach (var otherItem in Group.Items)
            {
                ret.Add(otherItem, MainText.CosineCoefficient(otherItem));
            }
            return ret;
        }
    }
}
