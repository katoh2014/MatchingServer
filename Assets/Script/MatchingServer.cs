using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;

public class MatchingServer : MonoBehaviour {

	//最大ルーム作成数
	private const int MaxRoomNum = 4;

	//1ゲーム最大人数
	private const int MaxMemberNum = NetConfig.PLAYER_MAX;

	private int conter = 0;

	private class RoomContent {

		public int node = -1;
		public int roomId = -1;
		public string name = "";
		public int level = 0;
		public bool isClosed = false;
		public float elapsedTime = 0.0f;
		public int[] members = Enumerable.Repeat(-1, MaxMemberNum).ToArray();
	}

	private class MemberList {
		public int node = -1;
		public int roomId = -1;
		public IPEndPoint endPoint = null;
		
	}

	private string[] levelString = new string[]{
		"なし","低レート","普通","高レート"
	};

	private Dictionary<int,RoomContent>	rooms_ = new Dictionary<int,RoomContent>();

	private Dictionary<int, MemberList> m_members = new Dictionary<int, MemberList>();

	private Network network_ = null;

	private int roomIndex = 0;

	private RoomContent joinedRoom = new RoomContent();

	private MemberList[] sessionMembers = new MemberList[MaxMemberNum];

	private State matchingState = State.Idle;

	private float timer = 0.0f;

	private enum State { 
		Idle = 0,
		MatchingServer,
		RoomCreateRequested,
		RoomSearchRequested,
		RoomJoinRequested,
		StartSessionRequested,
		StartSessionNotified,
		MatchingEnded,
	}

	// Use this for initialization
	void Start () {
		GameObject obj = new GameObject("Network");
		network_ = obj.AddComponent<Network>();

		matchingState = State.Idle;

		if (network_ != null) { 
			
			network_
			
		}

	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
