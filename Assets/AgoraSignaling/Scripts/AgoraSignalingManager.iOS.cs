using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace UBL.Agora.Signaling
{
    public partial class AgoraSignalingManager : MonoBehaviour
    {
#if !UNITY_EDITOR  && UNITY_IOS
        [DllImport("__Internal")]
        private static extern void initialize(string appId, string gameObjectName);

        [DllImport("__Internal")]
        private static extern void login(string account);

        [DllImport("__Internal")]
        private static extern void logout();

        [DllImport("__Internal")]
        private static extern void channelLeave();

        [DllImport("__Internal")]
        private static extern void channelJoin(string channelName);

        [DllImport("__Internal")]
        private static extern void sendChannelMessage(string message, string msgId);
    #endif
    }
}