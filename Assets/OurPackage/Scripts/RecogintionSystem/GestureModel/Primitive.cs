using System.Xml.Serialization;

namespace LeapGR.GestureModel
{
    public class Primitive
    {
        [XmlElement(ElementName = "Axis", Type = typeof(Axis))]         //axis of perfomance gesture
        public Axis Axis { get; set; }

        [XmlElement(ElementName = "Direction")]                         //direction: +1 -> positive changing
        public int Direction { get; set; }                              //             -1 -> negative

        [XmlElement(ElementName = "Order", IsNullable = true)]          //order of perfomance part of movement
        public int? Order { get; set; }

        [XmlElement(ElementName = "FramesCount")]                       //amount frames for of perfomance the part of movement
        public int FramesCount { get; set; }
    }

    /// <summary>
    /// asix of direction perfomance
    /// </summary>
    public enum Axis
    {
        [XmlEnum("X")]
        X,
        [XmlEnum("Y")]
        Y,
        [XmlEnum("Z")]
        Z
    };
}
