using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Similarity
{
    public class ComparisonGroup
    {
        public List<Iitem> Items;

        #region Constructors
        public ComparisonGroup()
        {
            Items = new List<Iitem>();
        }
        public ComparisonGroup(List<Iitem> items)
        {
            Items = items;
        }
        #endregion
    }
}
