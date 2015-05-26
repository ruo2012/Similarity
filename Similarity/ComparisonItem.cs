using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Similarity
{
    public class ComparisonItem
    {
        private Dictionary<String, Double> _attributeCount;

        #region Constructors
        public ComparisonItem()
        {
            _attributeCount = new Dictionary<string, Double>();
        }
        public ComparisonItem(Dictionary<String, Double> attributes)
        {
            _attributeCount = attributes;
        }
        #endregion

        #region Methods
        public Double GetValue(String attribute)
        {
            if (!_attributeCount.ContainsKey(attribute)) return 0; else return _attributeCount[attribute];
        }
        public void AddAttribute(String attribute, Double value)
        {
            if (_attributeCount.ContainsKey(attribute)) throw new ArgumentException("That attribute already exists in this item. ");
            _attributeCount.Add(attribute, value);
        }
        public void ChangeAttributeValue(String attribute, Double value)
        {
            if (!_attributeCount.ContainsKey(attribute)) throw new ArgumentException("That attribute does not exist.");
            _attributeCount[attribute] = value;
        }
        public void RemoveAttribute(String attribute)
        {
            if (!_attributeCount.ContainsKey(attribute)) throw new ArgumentException("This attribute does not exist");
            _attributeCount.Remove(attribute);
        }
        #endregion

        #region Properties
        public Dictionary<String, Double> Attributes { get { return _attributeCount; } }
        public String Source { get; set; }
        public String Summary { get; set; }
        #endregion
    }
}
