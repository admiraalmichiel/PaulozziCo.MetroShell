using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace PaulozziCo.MetroShell.Presentation.Resources
{
    public class ThemeResources
    {
        private const string STR_ThemeColorsCollectionXML = "/PaulozziCo.MetroShell.Client;component/Presentation/Resources/ThemeColorsCollection.xml";

        /// <summary>
        /// Deserializes the theme.
        /// </summary>
        /// <returns>
        /// <see cref="ThemeCollection"/>
        /// </returns>
        public ThemeCollection Deserialize()
        {
            try
            {
                ThemeCollection itemsDeserialized = new ThemeCollection();
                XmlSerializer xs = new XmlSerializer(typeof(ThemeCollection));

                using (Stream stream = Application.GetResourceStream(new Uri(STR_ThemeColorsCollectionXML, UriKind.Relative)).Stream)
                {
                    itemsDeserialized = (ThemeCollection)xs.Deserialize(stream);
                }

                return itemsDeserialized;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the theme deserialized dictionaries collection.
        /// </summary>
        /// <returns>
        /// The dictionaries collection.
        /// </returns>
        public Dictionary<string, string>[] GetDictionariesCollection()
        {
            var collection = Deserialize();

            List<Dictionary<string, string>> themes = new List<Dictionary<string, string>>();

            foreach (var theme in collection.Themes)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (var color in theme.Colors)
                {
                    dict.Add(color.Key, color.Value);
                }

                themes.Add(dict);
            }

            Dictionary<string, string>[] result = themes.ToArray();

            return result;
        }
    }
}
