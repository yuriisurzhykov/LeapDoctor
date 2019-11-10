namespace LeapGR.GestureModel
{
    public class Registry
    {
        public Gesture[] Gestures { get; set; } //Set of gestures

        public Registry(Gesture[] gestures) { Gestures = gestures; }
    }
}
