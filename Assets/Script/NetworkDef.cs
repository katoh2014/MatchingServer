using UnityEngine;
using System.Collections;

public class NetConfig { 
	public const int SERVER_VERSION = 1;
	public const int PLAYER_MAX = 4;
	public const int MATCING_SERVER_PORT = 50763;
	public const int GAME_SERVER_PORT = 50764;
	public const int GAME_PORT = 50765;
}

public enum NetEventType {

	Connect = 0,	//接続イベント
	Disconnect,		//切断イベント
	SendError,		//送信エラー
	ReceiveError,	//受信エラー
}

//イベントの結果
public enum netEventResult { 

	Failure = 1,	//失敗
	Success = 0,	//成功
}

//イベントの状態を通知
public class NetEventState {

	public int 				node;	// イベントが発生したノード.
	public NetEventType		type;	//イベントのタイプ
	public netEventResult	result;	//イベントの結果
}