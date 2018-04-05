# Read Me

Agora.io Signaling SDKのネイティブプラグイン確認用のUnityプロジェクトです。

# 使い方

1. `Assets/AgoraSignaling/Demo/Demo`シーンを開く(Editorの場合)
1. Loginボタン右のテキストフィールドにアカウント名(任意)を入力し、Loginボタンを押す
1. Channel Joinボタン右のテキストフィールドにチャンネル名(任意)を入力し、Channel Joinボタンを押す
1. Send Messageボタン右のテキストフィールドにメッセージを入力し、Send Messageボタンを押す
1. 送受信したメッセージは画面中央のスクロールバーに表示される
1.　ログは画面下部のスクロールバーに表示される

# プラグインの場所

iOS : `Assets/AgoraSignaling/Plugins/iOS`以下
MacOS : `Assets/AgoraSignaling/Plugins/x86_64`以下

# iOSについて

UnityでiOSビルドを行ってください。同一チャンネル内の相手とチャットを行うことが出来ます。

# MacOSについて

Unityを再生しネイティブプラグイン内のスクリプトにアクセスは可能です。

しかし、AgoraのApiを実行することができないので動作しません。

ネイティブプラグイン内で仕込んでいるログはUnityEditor上では確認できないので

`~/Library/Logs/Unity/Editor.log`を開いてログを確認してください。
