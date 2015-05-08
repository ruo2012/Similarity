using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Similarity.Processing;
using Newtonsoft.Json;
namespace Similarity
{
    /// <summary>
    /// Acts as a container for text that is to be compared.
    /// </summary>
    public class TextItem : Iitem
    {
        #region Local Variables
        //Holds the text of the item
        private string _text, 
        //Holds the location of where the document can be found
                       _location;
        //Holds the unique word count for the text
        private Dictionary<String, Int32> _wordCount;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public TextItem()
        {
            _wordCount = new Dictionary<string, int>();
        }
        /// <summary>
        /// Constructor that takes the text it is suppose to get a word count for.
        /// </summary>
        /// <param name="text">The String that acts as the item to compare.</param>
        public TextItem(String text)
        {
            //Set the local text to what they pass you
            _text = text;
            //get the word count for that text
            _wordCount = text.GetWordCount();
        }
        /// <summary>
        /// Constructor that initializes itself based on a json string.
        /// If IsJSON is set to false the Object will have nothing set.
        /// </summary>
        /// <param name="JSON">The JSON string of the object.</param>
        /// <param name="IsJSON">The boolean that determines if the object is loaded from this json string.</param>
        public TextItem(String JSON, bool IsJSON)
        {
            //If the user specified the string is JSON load it.
            if(IsJSON) this.LoadFromJSON(JSON);
        }
        /// <summary>
        /// Constructor that takes the text and the location of the document
        /// </summary>
        /// <param name="text">The String that acts as the item to compare.</param>
        /// <param name="location">The location of the document</param>
        public TextItem(String text, String location)
        {
            _text = text;
            _location = location;
            _wordCount = text.GetWordCount();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads the values from a JSON string into the object
        /// </summary>
        /// <param name="json">The json for the object</param>
        public void LoadFromJSON(string json)
        {
            //Deserialize the object
            var obj = JsonConvert.DeserializeObject<TextItem>(json);
            //Set this objects location
            this._location = obj.Location;
            //Set this objects Word Count dictionary
            this._wordCount = obj.AttributeCount;
            //Set this objects Text
            this._text = obj._text;
        }
        /// <summary>
        /// Converts this TextItem object to a JSON String
        /// </summary>
        /// <param name="StoreText">A boolean to determine if you want the text of the item stored in the JSON. (Might not be important, and takes up extra memory)</param>
        /// <returns></returns>
        public String GetJSON(bool StoreText)
        {
            //If the user wants to store the text serialize the current object
            //If the user doesn't want to create a new object of this type and 
            //set all of its properties except for the text and serialize it.
            if (StoreText) return JsonConvert.SerializeObject(this); else return JsonConvert.SerializeObject(new TextItem() { _wordCount = this._wordCount, _location = this._location });
        }
        #endregion

        #region Properties
        public string Title { get; set; }
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                _wordCount = _text.GetWordCount();
            }
        }
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        public Dictionary<string, Int32> AttributeCount
        {
            get
            {
                return _wordCount;
            }
        }
        #endregion
    }
}
