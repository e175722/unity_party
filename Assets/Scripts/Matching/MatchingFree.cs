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
public class MatchingFree : MonoBehaviourPunCallbacks
{
  public static string roomID_f;
  // Start is called before the first fsrame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }


  // public void  HostMakingFree(){ //ルーム作成ボタンやルーム参加ボタンが押された時に動く関数
  //   //以下のif文は現在不必要だが、今後必要な可能性があるため残しておく
  //     isGuest_f = false;
  //     //PhotonNetwork.OnJoinedLobby();
  //     PhotonNetwork.ConnectUsingSettings();
  //     Debug.Log("HostMaking");
  // }
  //
  // public void  GuestEnterFree(){ //ルーム作成ボタンやルーム参加ボタンが押された時に動く関数
  //   //以下のif文は現在不必要だが、今後必要な可能性があるため残しておく
  //     isGuest_f = true;
  //     PhotonNetwork.ConnectUsingSettings();
  // }

  public void  NextScene(string resultMessage){ //ルーム作成ボタンやルーム参加ボタンが押された時に動く関数

    //以下のif文は現在不必要だが、今後必要な可能性があるため残しておく
    if (Application.loadedLevelName == "HostFree") {
      Debug.Log("第一関門");
      roomID_f = Convert.ToString(UnityEngine.Random.Range(0, 1000));
      PhotonNetwork.ConnectUsingSettings();
    }else if(Application.loadedLevelName == "Free"){
      Debug.Log("るーむ参加が押された");
      PhotonNetwork.ConnectUsingSettings();
    }
  }


  public static string getRoomID_F(){
    return roomID_f;
  }


    //RoomOptions roomOptions = new RoomOptions();
    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster() {
      Debug.Log("コールバック呼ばれた");
      //if(Application.loadedLevelName == "HostFree" || Application.loadedLevelName == "GuestFree"){
          //Debug.Log("guestFree");
          Debug.Log("isGuest_f : " + InputManagerFree.isGuest_f);
          if(InputManagerFree.isGuest_f == true){  // ルームの作成者かそうでないかの判定
            Debug.Log("ルームに参加しましょ");
            PhotonNetwork.JoinRandomRoom(); //フリールームに参加する
          }else{
            RoomOptions roomOptions = new RoomOptions();
            Debug.Log("ルーム作りましょ");
            //roomID_f = Convert.ToString(UnityEngine.Random.Range(0, 1000));
            PhotonNetwork.CreateRoom(getRoomID_F(), roomOptions, TypedLobby.Default); //ルームを作成する
          }
      //}
    }

    public override void OnJoinedRoom() { //部屋にに参加出来たら動く関数
      Application.LoadLevel("Matching");
    }

    public override void OnJoinRoomFailed(short returnCode, string message){ //部屋に参加出来なかったら動く関数
      PhotonNetwork.Disconnect(); //Photonからの接続を切る.
      Debug.Log("faildJoin");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("room created.");
    }

    }
