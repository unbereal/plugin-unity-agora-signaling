using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UniRx;
using UnityEngine;

namespace UBL.Agora.Signaling
{
    public partial class AgoraSignalingManager : MonoBehaviour
    {
        #region UniRx

        //State
        private static Subject<QueryUserStatusResult> _onQueryUserStatusResultSubject =
            new Subject<QueryUserStatusResult>();

        public static IObservable<QueryUserStatusResult> onQueryUserStatusResultHandler
        {
            get { return _onQueryUserStatusResultSubject; }
        }

        //Log
       private static Subject<string> _onLogSubject = new Subject<string>();

        public static IObservable<string> OnLogHandler
        {
            get { return _onLogSubject; }
        }

        //Login
        Subject<string> _onLoginSuccessSubject = new Subject<string>();

        public IObservable<string> OnLoginSuccessHandler
        {
            get { return _onLoginSuccessSubject; }
        }

        Subject<string> _onLoginFailedSubject = new Subject<string>();

        public IObservable<string> OnLoginFailedHandler
        {
            get { return _onLoginFailedSubject; }
        }

        Subject<string> _onLogoutSubject = new Subject<string>();

        public IObservable<string> OnLogoutHandler
        {
            get { return _onLogoutSubject; }
        }

        //Channel
        Subject<string> _onChannelJoinedSubject = new Subject<string>();

        public IObservable<string> OnChannelJoinedHandler
        {
            get { return _onChannelJoinedSubject; }
        }

        Subject<string> _onChannelLeavedSubject = new Subject<string>();

        public IObservable<string> OnChannelLeavedHandler
        {
            get { return _onChannelLeavedSubject; }
        }

        Subject<string> _onChannelJoinFailedSubject = new Subject<string>();

        public IObservable<string> OnChannelJoinFailedHandler
        {
            get { return _onChannelJoinFailedSubject; }
        }

        Subject<ChannelQueryUserNumResult> _onChannelQueryUserNumResultSubject =
            new Subject<ChannelQueryUserNumResult>();

        public IObservable<ChannelQueryUserNumResult> OnChannelQueryUserNumResultHandler
        {
            get { return _onChannelQueryUserNumResultSubject; }
        }

        Subject<ChannelQueryUserIsIn> _onChannelQueryUserIsInSubject = new Subject<ChannelQueryUserIsIn>();

        public IObservable<ChannelQueryUserIsIn> OnChannelQueryUserIsInHandler
        {
            get { return _onChannelQueryUserIsInSubject; }
        }

        Subject<ChannelUserList> _onChannelUserListSubject = new Subject<ChannelUserList>();

        public IObservable<ChannelUserList> OnChannelUserListHandler
        {
            get { return _onChannelUserListSubject; }
        }
        //Message

        Subject<MessageInstantReceive> _onMessageInstantReceiveSubject = new Subject<MessageInstantReceive>();

        public IObservable<MessageInstantReceive> OnMessageInstantReceiveHandler
        {
            get { return _onMessageInstantReceiveSubject; }
        }

        Subject<string> _onMessageSendErrorSubject = new Subject<string>();

        public IObservable<string> OnMessageSendErrorHandler
        {
            get { return _onMessageSendErrorSubject; }
        }

        Subject<string> _onMessageSendSuccessSubject = new Subject<string>();

        public IObservable<string> OnMessageSendSuccessHandler
        {
            get { return _onMessageSendSuccessSubject; }
        }

        Subject<MessageChannelReceive> _onMessageChannelReceiveSubject = new Subject<MessageChannelReceive>();

        public IObservable<MessageChannelReceive> OnMessageChannelReceiveHandler
        {
            get { return _onMessageChannelReceiveSubject; }
        }

        #endregion

        #region Public

        public void Initialize(string appId)
        {
//            Debug.Log(test());
//            Debug.Log(test2());
            initialize(appId, gameObject.name);
        }

        public void Login(string account)
        {
            login(account);
        }

        public void Logout()
        {
            logout();
        }

        public void ChannelLeave()
        {
            channelLeave();
        }

        public void ChannelJoin(string channelName)
        {
            channelJoin(channelName);
        }

        public void SendChannelMessage(string message, string msgId)
        {
            sendChannelMessage(message, msgId);
        }

        #endregion

        #region Callback

        //State
        public void OnQueryUserStatusResult(string json)
        {
            var data = JsonUtility.FromJson<QueryUserStatusResult>(json);
            _onQueryUserStatusResultSubject.OnNext(data);
        }

        //Log
        public void OnLog(string log)
        {
            Debug.LogFormat("OnLog:{0}", log);
            _onLogSubject.OnNext(log);
        }

        //Login
        public void OnLoginSuccess(string uid)
        {
            Debug.LogFormat("OnLoginSuccess:{0}", uid);
            _onLoginSuccessSubject.OnNext(uid);
        }

        public void OnLoginFailed(string error)
        {
            Debug.LogFormat("OnLoginFailed:{0}", error);
            _onLoginFailedSubject.OnNext(error);
        }

        //Channel
        public void OnChannelJoined(string channelId)
        {
            Debug.LogFormat("OnChannelJoined:{0}", channelId);
            _onChannelJoinedSubject.OnNext(channelId);
        }

        public void OnChannelJoinFailed(string error)
        {
            Debug.LogFormat("OnChannelJoinFailed:{0}", error);
            _onChannelJoinFailedSubject.OnNext(error);
        }


        public void OnChennelQueryUserNumResult(string json)
        {
            var data = JsonUtility.FromJson<ChannelQueryUserNumResult>(json);
            _onChannelQueryUserNumResultSubject.OnNext(data);
        }

        public void OnChennelQueryUserIsIn(string json)
        {
            var data = JsonUtility.FromJson<ChannelQueryUserIsIn>(json);
            _onChannelQueryUserIsInSubject.OnNext(data);
        }

        public void OnChannelUserList(string json)
        {
            var data = JsonUtility.FromJson<ChannelUserList>(json);
            _onChannelUserListSubject.OnNext(data);
        }

        //Message
        public void OnMessageInstantReceive(string json)
        {
            var data = JsonUtility.FromJson<MessageInstantReceive>(json);
            Debug.LogFormat("OnReceiveMessage:{0}", json);
            _onMessageInstantReceiveSubject.OnNext(data);
        }

        public void OnMessageChannelReceive(string json)
        {
            var data = JsonUtility.FromJson<MessageChannelReceive>(json);
            Debug.LogFormat("OnCReceiveChannelMessage:{0}", json);
            _onMessageChannelReceiveSubject.OnNext(data);
        }

        public void OnMessageSendSuccess(string messageId)
        {
            _onMessageSendSuccessSubject.OnNext(messageId);
        }

        public void OnMessageSendError(string error)
        {
            _onMessageSendErrorSubject.OnNext(error);
        }

        #endregion
    }
}