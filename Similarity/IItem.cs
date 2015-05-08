using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Similarity
{
    public interface Iitem
    {
        Dictionary<string, int> AttributeCount { get; }
        String Title { get; set; }
        String Location { get; set; }
    }
}
