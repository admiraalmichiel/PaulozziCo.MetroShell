using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace PaulozziCo.MetroShell.Presentation.Resources
{
    /// <summary>
    /// Color resource.
    /// </summary>
    [DataContract]
    [XmlSerializerFormat]
    public class ColorResource
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ColorResource() { }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [DataMember, XmlAttribute("Key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [DataMember, XmlAttribute("Value")]
        public string Value { get; set; }
    }

    /// <summary>
    /// Color palette.
    /// </summary>
    [DataContract]
    [XmlSerializerFormat]
    public class ColorPalette
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ColorPalette() { }

        /// <summary>
        /// Gets or sets the name of the palette.
        /// </summary>
        /// <value>
        /// The name of the palette.
        /// </value>
        [DataMember, XmlAttribute("PaletteName")]
        public string PaletteName { get; set; }

        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        /// <value>
        /// The colors.
        /// </value>
        [DataMember]
        [XmlArray("Colors")]
        [XmlArrayItem("ColorResource", typeof(ColorResource))]
        public ColorResource[] Colors { get; set; }
    }

    /// <summary>
    /// Collection of themes.
    /// </summary>
    [DataContract]
    [XmlSerializerFormat]
    public class ThemeCollection
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ThemeCollection() { }

        /// <summary>
        /// Gets or sets the themes.
        /// </summary>
        /// <value>
        /// The themes.
        /// </value>
        [DataMember]
        [XmlArray("Themes")]
        [XmlArrayItem("ColorPalette", typeof(ColorPalette))]
        public ColorPalette[] Themes { get; set; }
    }
}
