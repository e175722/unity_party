using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

/*
・HostMakingシーンのButton_MakeRoom
・GuestEnterのButton_Participate
にアタッチされている
*/
public class ChangeToMatching : MonoBehaviourPunCallbacks
{
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void  NextScene(string resultMessage){ //ルーム作成ボタンやルーム参加ボタンが押された時に動く関数

    //以下のif文は現在不必要だが、今後必要な可能性があるため残しておく
    if (Application.loadedLevelName == "HostMaking") {
      PhotonNetwork.ConnectUsingSettings();
    }else if(Application.loadedLevelName == "GuestEnter") {
      PhotonNetwork.ConnectUsingSettings();
    }
  }


    //RoomOptions roomOptions = new RoomOptions();
    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster() {
      string ID = InputManager.getRoomID();  // ルーム作成者が作成したルームIDを取得
      if(Application.loadedLevelName == "HostMaking" || Application.loadedLevelName == "GuestEnter"){
        if(InputManager.getIsguest() == true){  // ルームの作成者かそうでないかの判定
          PhotonNetwork.JoinRoom(ID);  //プライベートルームに参加する
        }else{
          RoomOptions roomOptions = new RoomOptions();
          roomOptions.IsVisible = false;　//ランダムなマッチングを防ぐ
          PhotonNetwork.CreateRoom(ID, roomOptions, TypedLobby.Default); //ルームを作成する
        }
      }
    }


      public override void OnJoinedRoom() { //部屋にに参加出来たら動く関数
        Application.LoadLevel("Matching");
      }


      public override void OnJoinRoomFailed	(short returnCode, string message){ //部屋に参加出来なかったら動く関数
        //以下2行でアラート表示
        GameObject obj = (GameObject)Resources.Load ("Popup_Alert(OnlyOKButton)");
        GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);


        PhotonNetwork.Disconnect(); //Photonからの接続を切る.
        Debug.Log("faildJoin");
      }
      public override void OnCreateRoomFailed(short returnCode, string message){ //部屋を作成出来なかったら動く関数
        //以下2行でアラート表示
        GameObject obj = (GameObject)Resources.Load ("Popup_Alert(OnlyOKButton)");
        GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);


        PhotonNetwork.Disconnect();  //Photonからの接続を切る.
        Debug.Log("faildCreate");
      }
    }
