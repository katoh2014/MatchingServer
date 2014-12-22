using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;


public class Network : MonoBehaviour {

	private SessionTCP m_sessionTcp = null;

	private const int m_headerVersion = NetConfig.SERVER_VERSION;

	private Dictionary<int,NodeInfo> m_node = new Dictionary<int,NodeInfo>;

	//送受信用のパケット最大サイズ
	private const int m_packetSize = 1400;

	public delegate void RecvNotifier(int node, byte[] data);

	private Dictionary<int , RecvNotifier> m_notifier = new Dictionary<int,RecvNotifier>();

	//イベント通知のデリゲート
	public delegate void NetEventHandler(int node , NetEventState state);

	//イベントハンドラ-
	private NetEventHandler m_handler;

	private class NodeInfo{
		public int node = 0;
	}


	void Awake(){
		m_sessionTcp = new SessionTCP();
		m_sessionTcp.re();

	}

	public void RegisterEventHandler(NetEventHandler handler){
		m_handler = handler;
	}
}



