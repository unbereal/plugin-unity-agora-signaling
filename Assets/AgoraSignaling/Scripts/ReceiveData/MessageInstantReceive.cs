using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UBL.Agora.Signaling
{
    [Serializable]
    public class MessageInstantReceive 
    {
        [SerializeField]
        private string account;

        [SerializeField]
        private int uid;

        [SerializeField]
        private string message;

        public string Account
        {
            get { return account; }
        }

        public int Uid
        {
            get { return uid; }
        }

        public string Message
        {
            get { return message; }
        }
    }
}