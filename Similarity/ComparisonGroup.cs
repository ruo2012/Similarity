using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Similarity
{
    public class ComparisonGroup
    {
        private List<ComparisonItem> _items;
        private Dictionary<String, Int32> _attributeFrequency;

        #region Constructors
        public ComparisonGroup()
        {
            _items = new List<ComparisonItem>();
            _attributeFrequency = new Dictionary<string, int>();
        }
        public ComparisonGroup(List<ComparisonItem> items)
        {
            _items = new List<ComparisonItem>();
            _attributeFrequency = new Dictionary<string, int>();
            foreach(var item in items)
            {
                //Add the item to the list of items
                _items.Add(item);
                //Add the attributes to the term frequency list
                foreach(var attribute in item.Attributes)
                {
                    //If it exists incriment its value by 1
                    //If it doesn't add it to the term frequency with a value of 1
                    if (_attributeFrequency.ContainsKey(attribute.Key)) _attributeFrequency[attribute.Key] = _attributeFrequency[attribute.Key] + 1; else _attributeFrequency.Add(attribute.Key, 1);
                }
            }
        }
        #endregion

        #region Methods
        public int AttributeFrequency(String attribute)
        {
            if (!_attributeFrequency.ContainsKey(attribute)) return 0; else return _attributeFrequency[attribute];
        }
        public void AddItem(ComparisonItem item)
        {
            _items.Add(item);
            foreach(var attribute in item.Attributes)
            {
                //If it exists incriment its value by 1
                //If it doesn't add it to the term frequency with a value of 1
                if (_attributeFrequency.ContainsKey(attribute.Key)) _attributeFrequency[attribute.Key] = _attributeFrequency[attribute.Key] + 1; else _attributeFrequency.Add(attribute.Key, 1);
            }
        }
        public Double MaxAttributeOccurence(String attribute)
        {
            var ret = 0.0;
            //Go through each item in the list
            foreach(var i in _items)
            {
                //Check to see if the item exists
                if(i.Attributes.ContainsKey(attribute))
                {
                    //If that item exists and it's value is greater than the return, set the return to be its value
                    if (i.Attributes[attribute] > ret) ret = i.Attributes[attribute];
                }
            }
            return ret;
        }
        #endregion

        #region Properties
        public int ItemCount { get { return _items.Count; } }
        public List<ComparisonItem> Items { get { return _items; } } 
        #endregion
    }
}
