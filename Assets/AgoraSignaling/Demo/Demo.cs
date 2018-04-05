using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UBL.Agora.Signaling.Demo
{
    public class Demo : MonoBehaviour
    {
        [SerializeField]
        private string _appId;

        [SerializeField]
        private AgoraSignalingManager _signalingManager;

        [SerializeField]
        private Button _loginButton;

        [SerializeField]
        private Button _channelJoinButton;

        [SerializeField]
        private Button _messageSendButton;

        [SerializeField]
        private InputField _accountInputField;

        [SerializeField]
        private InputField _channelInputField;

        [SerializeField]
        private InputField _messageInputField;

        [SerializeField]
        private Text _chatMessageText;

        [SerializeField]
        private Text _logText;

        private void Start()
        {
            _signalingManager.Initialize(_appId);
            AgoraSignalingManager.OnLogHandler.Subscribe(OnLog);
            _signalingManager.OnMessageChannelReceiveHandler.Subscribe(OnMessageChannelReceive);
            _loginButton.onClick.AddListener(OnLoginButtonClicked);
            _channelJoinButton.onClick.AddListener(OnChannelJoinButtonClicked);
            _messageSendButton.onClick.AddListener(OnMessageSendButtonClicked);
        }

        private void OnLoginButtonClicked()
        {
            _signalingManager.Login(_accountInputField.text);
        }

        private void OnChannelJoinButtonClicked()
        {
            _signalingManager.ChannelJoin(_channelInputField.text);
        }

        private void OnMessageSendButtonClicked()
        {
            _signalingManager.SendChannelMessage(_messageInputField.text, "0");
        }

        #region Handler

        private void OnLog(string log)
        {
            string current = _logText.text;
            current += string.Format("\n{0}", log);
            _logText.text = current;
        }

        private void OnMessageChannelReceive(MessageChannelReceive message)
        {
            string msg = _chatMessageText.text;
            msg += string.Format("\n{0}", message.Message);
            _chatMessageText.text = msg;
        }

        #endregion
    }
}