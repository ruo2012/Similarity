using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Similarity;
using System.Net;
namespace TestHarness
{
    class Program
    {
        private static CERCDBDataContext db = new CERCDBDataContext();
        static void Main(string[] args)
        {
            //var wc = new WebClient();
            //var group = new ComparisonGroup();
            //var littleWomen = new TextItem(wc.DownloadString("http://www.textfiles.com/etext/FICTION/alcott-little-261.txt")) { Location = "http://www.textfiles.com/etext/FICTION/alcott-little-261.txt" };
            //var Aladin = new TextItem(wc.DownloadString("http://www.textfiles.com/etext/FICTION/alad10.txt"));
            ////Add items to the group
            //group.Items.Add(littleWomen);
            //group.Items.Add(Aladin);
            //var x = littleWomen.GetJSON(false);
            //group.Items.Add(new TextItem(x, true));
            ////Generate a Comparison
            //var comparison = littleWomen.CosineSimilarity(group);
            var group = new ComparisonGroup();
            foreach(var dmgCase in db.vDamageCaseQueries.Where(p=>p.Description.Length > 20))
            {
                group.Items.Add(new TextItem(dmgCase.Description) { Title = dmgCase.CaseID.ToString(), Location = "CERCDB" });
            }
            var id = "";
            var highest = new Dictionary<Iitem, double>();
            //Do a comparison for each one
            foreach(var c in group.Items)
            {
                id = c.Title.ToString();
                var similarity = c.CosineSimilarity(group).Where(p => p.Key.Title != c.Title).OrderByDescending(p => p.Value).ToDictionary(p => p.Key, p => p.Value);
                if (highest.Count == 0) highest = similarity;
                if (similarity.Max(p => p.Value) > highest.Max(p => p.Value)) highest = similarity; 
            }
            var x = 1;
        }
    }
}
