using System.Xml.Serialization;

namespace LeapGR.GestureModel
{
    public class Gesture
    {
        [XmlElement(ElementName = "GestureIndex")]                     //порядковый номер жеста
        public int GestureIndex { get; set; }

        [XmlElement(ElementName = "GestureName")]                      //название жеста
        public string GestureName { get; set; }

        [XmlElement(ElementName = "PrimitivesCount")]                  //количество составны частей
        public int PrimitivesCount { get; set; }

        [XmlArray(ElementName = "Primitives")]                         //описание составных частей для жеста
        public Primitive[] Primitives { get; set; }
    }
}