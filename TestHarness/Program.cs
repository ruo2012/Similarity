using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Similarity;
using Similarity.Comparison;
using Similarity.Processing;
using System.Net;

namespace TestHarness
{
    class Program
    {
        private static CERCDBDataContext db = new CERCDBDataContext();
        static void Main(string[] args)
        {
            var wc = new WebClient();
            var wizardOfOz = new ComparisonItem(wc.DownloadString("https://www.gutenberg.org/cache/epub/420/pg420.txt").GetWordCount());
            var RobinHood = new ComparisonItem(wc.DownloadString("https://www.gutenberg.org/cache/epub/964/pg964.txt").GetWordCount());
            var fantasyGroup = new ComparisonGroup() { };
            fantasyGroup.AddItem(wizardOfOz);
            fantasyGroup.AddItem(RobinHood);

            var l = "You who so plod amid serious things that you feel it shame to give yourself up even for a few short moments to mirth and joyousness".SearchScore(fantasyGroup);
        }
    }
}
