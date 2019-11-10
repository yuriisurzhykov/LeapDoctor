/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2018.                                 *
 * Leap Motion proprietary and confidential.                                  *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace Leap
{
    class Listener : IDisposable
    {
        protected bool swigCMemOwn;

        public extern Listener();
        public extern Listener(IntPtr cPtr, bool cMemoryOwn);

        ~Listener() { }

        public virtual HandleRef getCPtr(Listener obj) { return new HandleRef(); }
        public virtual void Dispose() { }
        public virtual void OnConnect(Controller arg0) { }
        public virtual void OnDeviceChange(Controller arg0) { }
        public virtual void OnDisconnect(Controller arg0) { }
        public virtual void OnExit(Controller arg0) { }
        public virtual void OnFocusGained(Controller arg0) { }
        public virtual void OnFocusLost(Controller arg0) { }
        public virtual void OnFrame(Controller arg0) { }
        public virtual void OnInit(Controller arg0) { }
        public virtual void OnServiceConnect(Controller arg0) { }
        public virtual void OnServiceDisconnect(Controller arg0) { }

        public delegate void SwigDelegateListener_8(IntPtr arg0);
        public delegate void SwigDelegateListener_0(IntPtr arg0);
        public delegate void SwigDelegateListener_1(IntPtr arg0);
        public delegate void SwigDelegateListener_2(IntPtr arg0);
        public delegate void SwigDelegateListener_3(IntPtr arg0);
        public delegate void SwigDelegateListener_4(IntPtr arg0);
        public delegate void SwigDelegateListener_5(IntPtr arg0);
        public delegate void SwigDelegateListener_6(IntPtr arg0);
        public delegate void SwigDelegateListener_7(IntPtr arg0);
        public delegate void SwigDelegateListener_9(IntPtr arg0);
    }
}