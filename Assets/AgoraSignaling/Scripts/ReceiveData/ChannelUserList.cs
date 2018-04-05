using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UBL.Agora.Signaling
{
    [Serializable]
    public class ChannelUserList
    {
        [SerializeField]
        private List<string> accounts;

        public List<string> Accounts
        {
            get { return accounts; }
        }

        [SerializeField]
        private List<int> uids;

        public List<int> Uids
        {
            get { return uids; }
        }
    }
}