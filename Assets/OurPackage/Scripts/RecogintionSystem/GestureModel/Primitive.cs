using System.Xml.Serialization;

namespace LeapGR.GestureModel
{
    public class Primitive
    {
        [XmlElement(ElementName = "Axis", Type = typeof(Axis))]         //axis of perfomance gesture
        public Axis Axis { get; set; }

        [XmlElement(ElementName = "Direction")]                         //direction: +1 -> positive changing
        public int Direction { get; set; }                              //             -1 -> negative

        [XmlElement(ElementName = "FramesCount")]                       //the number of frames to perform part of the movement
        public int FramesCount { get; set; }

        [XmlElement(ElementName = "Order", IsNullable = true)]          //the execution order of part of the movement
        public int? Order { get; set; }

        [XmlElement(ElementName = "NumberFingers")]                     //number of fingers
        public int? AmountFingers { get; set; }

        [XmlElement(ElementName = "Fingers")]                           //array of fingerses numbers
        public int Finger { get; set; }
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
