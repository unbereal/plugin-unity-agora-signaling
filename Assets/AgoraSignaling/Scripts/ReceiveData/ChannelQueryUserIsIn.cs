using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UBL.Agora.Signaling 
{
    [Serializable]
public class ChannelQueryUserIsIn
{

    [SerializeField]
    private string channelId;

    [SerializeField]
    private string error;

    [SerializeField]
    private bool isIn;
}

}
