using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class hostmatching : MonoBehaviourPunCallbacks
{    
    public static int playerID;
    private void Start() {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster() {
        // ルーム作成者が作成したルームIDを取得
        string ID = InputManager.getRoomID();
        
        // ルームの作成者かそうでないかの判定
        if(InputManager.getIsguest() == true){
            //ルームに参加する
            PhotonNetwork.JoinRoom(ID);
        }else{
            //ルームを作成する
            PhotonNetwork.CreateRoom(ID, new RoomOptions(), TypedLobby.Default);
        }
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom() {
        var v = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("GamePlayer", v, Quaternion.identity); 
        playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log("playerID = " + playerID); 
    }
}