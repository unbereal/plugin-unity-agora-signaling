using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace UBL.Agora.Signaling
{
    public partial class AgoraSignalingManager : MonoBehaviour
    {
#if UNITY_EDITOR || UNITY_STANDALONE_OSX


        [DllImport("Agora-Signaling-Bundle")]
        private static extern void initialize(string appId, string gameObjectName);

        [DllImport("Agora-Signaling-Bundle")]
        private static extern void login(string account);

        [DllImport("Agora-Signaling-Bundle")]
        private static extern void logout();

        [DllImport("Agora-Signaling-Bundle")]
        private static extern void channelLeave();

        [DllImport("Agora-Signaling-Bundle")]
        private static extern void channelJoin(string channelName);

        [DllImport("Agora-Signaling-Bundle")]
        private static extern void sendChannelMessage(string message, string msgId);

        #region Callback

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnLogCallback(string str);

        private OnLogCallback _onLogCallback = msg => Debug.Log(msg);

        [DllImport("Agora-Signaling-Bundle")]
        public static extern void setOnLogCallback(IntPtr ptr);
        [DllImport ("Agora-Signaling-Bundle")]
        public static extern void debugLogTest(); 

        #endregion
        

        void Start()
        {
            var callback = new OnLogCallback(_onLogCallback);
            var ptr = Marshal.GetFunctionPointerForDelegate(callback);
            setOnLogCallback(ptr);
            debugLogTest();
        }

#endif
    }
}