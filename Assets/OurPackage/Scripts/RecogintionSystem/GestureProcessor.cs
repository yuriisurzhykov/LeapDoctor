using Leap;
using LeapGR.API;
using LeapGR.GestureModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Leap.Unity;

namespace LeapGR
{
    class GestureProcessor : Listener, IGestureProcessor
    {
        #region Variables

        const string REGISTRY_FILE = "gestures.xml";
        const float INIT_COORDINATES = 100f;
        const int INIT_COUNTER = 0;
        const int FRAME_INTERVAL = 5000;

        long currentFrameTime;
        long previousFrameTime;
        long frameTimeChange;

        Registry _registry;
        Controller _controller;
        List<int> _recognized;
        List<float> _coordinates;
        List<int> _number;

        Chirality _handedness;
        #endregion

        #region Constructor
        public GestureProcessor(Chirality handedness)
        {
            LoadGestures();
            InitializeSensor();
            InitializeProcessor();
            _handedness = handedness;
        }
        #endregion

        #region Controller
        public void UninitializeSensor()
        {
            _controller.RemoveListener(this);
            _controller.Dispose();
        }

        public void UninitializeProcessor()
        {
            _number.Clear();
            _coordinates.Clear();
            _recognized.Clear();
        }

        public void InitializeProcessor()
        {
            if (_registry != null)
            {
                int length = _registry.Gestures.Length;

                _recognized = Enumerable.Repeat<int>(INIT_COUNTER, length).ToList();
                _number = Enumerable.Repeat<int>(INIT_COUNTER, length).ToList();
                _coordinates = Enumerable.Repeat<float>(INIT_COORDINATES, length).ToList();
            }
        }

        public void InitializeSensor()
        {
            try
            {
                _controller = new Leap.Controller();
                _controller.AddListener(this);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion

        #region GestureProcessor
        public void LoadGestures()
        {
            _registry = null;

            string path = AppDomain.CurrentDomain.BaseDirectory + "//" + REGISTRY_FILE;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Registry));
                    _registry = (Registry)xs.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void CheckDirection(int gestureIndex, Primitive primitive, Finger finger)
        {

        }

        public void CheckFinger(Gesture gesture, Finger finger)
        {

        }

        public void CheckGesture(Gesture gesture)
        {

        }
        #endregion

        public override void OnFrame(Leap.Controller ctrl)
        {
            Frame frame = ctrl.Frame();

            currentFrameTime = frame.Timestamp;
            frameTimeChange = currentFrameTime - previousFrameTime;

            if (frameTimeChange > FRAME_INTERVAL)
            {
                foreach (Gesture gesture in _registry.Gestures)
                {
                    Task.Factory.StartNew(() =>
                    {
                    //    Finger finger = frame.Hand(_handedness.indexOf()).Fingers[gesture.FingerIndex];
                        //CheckFinger(gesture, finger);
                    });
                }

                previousFrameTime = currentFrameTime;
            }
        }
    }
}