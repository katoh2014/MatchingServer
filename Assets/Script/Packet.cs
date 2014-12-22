using System.Collections;
using System.IO;

//
//マッチングパケット定義
//

//マッチングリクエストパケット定義
public class MatchingRequestPacket : IPacket<MatchingRequest> {

	class MatchingRequestSerializer : Serializer { 
		//
		public bool Serialize(MatchingRequest packet) {
			bool ret = true;

			ret &= Serialize(packet.version);
			int request = (int)packet.request;
			ret &= Serialize(request);
			ret &= Serialize(packet.roomId);
			ret &= Serialize(packet.name,MatchingRequest.roomNameLength);
			ret &= Serialize(packet.level);

			return ret;
		}

		//
		public bool Deserialize(ref MatchingRequest element) {
			if (GetDataSize() == 0) { 
				//データが設定されていない
				return false;
			}

			bool ret = true;
			//INT型のデシリアライズ
			ret &= Deserialize(ref element.version);
			
			int request = 0;
			//INT型のデシリアライズ
			ret &= Deserialize(ref request);
			element.request = (MatchingRequestId)request;

			//INT型のデシリアライズ
			ret &= Deserialize(ref element.roomId);

			//ルーム名を指定の長さまでデシリアライズ
			ret &= Deserialize(ref element.name, MatchingRequest.roomNameLength);
			
			//INT型のデシリアライズ
			ret &= Deserialize(ref element.level);

			return ret;
		}
	}

	//パケットデータの実体
	MatchingRequest m_packet;

	//パケットデータをシリアライズするためのコンストラクタ
	public MatchingRequestPacket(MatchingRequest data) {

		m_packet = data;

	}

	//バイナリデータをパケットデータにデシリアライズするためのコンストラクタ
	public MatchingRequestPacket(byte[] data) {
		MatchingRequestSerializer serializer = new MatchingRequestSerializer();

		serializer.SetDeserializedData(data);
		serializer.Deserialize(ref m_packet);
	}

	public PacketId getPacketId() {
		return PacketId.MatchingRequest;
	}

	public MatchingRequest GetPacket() {

		return m_packet;

	}

	public byte[] GetData() {
		MatchingRequestSerializer serializer = new MatchingRequestSerializer();

		serializer.Serialize(m_packet);

		return serializer.GetSerializedData();
	}
}

//マッチングリクエストパケット定義
public class MatchingResponsePacket : IPacket<MatchingResponse> {
	class MatchingResponseSerializer : Serializer {

		public bool Serialize(MatchingResponse packet) {
			bool ret = true;

			int result = (int)packet.request;
			ret &= Serialize(result);

			int request = (int)packet.request;
			ret &= Serialize(request);

			ret &= Serialize(packet.roomId);
			ret &= Serialize(packet.name, MatchingRequest.roomNameLength);
			ret &= Serialize(packet.members);

			return ret;
		}

		//
		public bool Deserialize(ref MatchingResponse element) {
			if (GetDataSize() == 0){
				//データが設定されていない
				return false;
			}

			bool ret = true;

			int result = 0;
			ret &= Deserialize(ref result);
			element.result = (MatchingResult)result;

			int request = 0;
			ret &= Deserialize(ref request);
			element.request = (MatchingRequestId)request;
			
			ret &= Deserialize(ref element.roomId);
			ret &= Deserialize(ref element.name,MatchingResponse.roomNameLength);
			ret &= Deserialize(ref element.members);

			return ret;
		}
	}

	//パケットデータの実体
	MatchingResponse m_packet;
	
	//パケットデータをシリアライズするためのコンストラクタ
	public MatchingResponsePacket(MatchingResponse data) {
		m_packet = data;
	}

	//バイナリデータをパケットデータにデシリアライズするためのコンストラクタ
	public MatchingResponsePacket(byte[] data){
		MatchingResponseSerializer serializer = new MatchingResponseSerializer();

		serializer.SetDeserializedData(data);
		serializer.Deserialize(ref m_packet);
	}

	public PacketId GetPacketId() {
		return PacketId.MatchingResponse;
	}

	public MatchingResponse GetPacket() {
		return m_packet;
	
	}

	public byte[] GetData() {
		MatchingResponseSerializer serializer = new MatchingResponseSerializer();
		serializer.Serialize(m_packet);

		return serializer.GetSerializedData();
	}
}

//ルーム検索結果パケット定義
public class SearchroomPacket : IPacket<SearchRoomResponse> {

	class SearchRoomSerializer : Serializer
	{

		//
		public bool Serialize(SearchRoomResponse packet)
		{

			bool ret = true;

			ret &= Serialize(packet.roomNum);

			for (int i = 0; i < packet.roomNum; ++i)
			{
				ret &= Serialize(packet.rooms[i].roomId);
				ret &= Serialize(packet.rooms[i].name, MatchingResponse.roomNameLength);
				ret &= Serialize(packet.rooms[i].members);
				
			}

			return ret;
		}

		public bool Deserialize(ref SearchRoomResponse element) {

			if (GetDataSize() == 0) { 
				//データが定義されていない
				return false;
			}

			bool ret = true;

			ret &= Deserialize(ref element.roomNum);

			element.rooms = new RoomInfo[element.roomNum];
			for (int i = 0; i < element.roomNum; ++i) {
				ret &= Deserialize(ref element.rooms[i].roomId);

				ret &= Deserialize(ref element.rooms[i].name,MatchingResponse.roomNameLength);

				ret &= Deserialize(ref element.rooms[i].members);
			
			}
			return ret;
		}
	}
}



