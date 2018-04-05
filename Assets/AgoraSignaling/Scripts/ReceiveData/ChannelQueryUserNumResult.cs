using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UBL.Agora.Signaling
{
    [Serializable]
    public class ChannelQueryUserNumResult
    {
        [SerializeField]
        private string name;

        public string Name
        {
            get { return name; }
        }


        [SerializeField]
        private string status;

        public string Status
        {
            get { return status; }
        }
    }
}