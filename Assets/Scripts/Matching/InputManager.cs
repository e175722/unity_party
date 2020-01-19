using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//追加する！
using UnityEngine.UI;
using Photon.Pun;


/*
・HostMakingシーンのInputField_InputRoomID
・GuestEnterシーンのInputField_InputRoomID
にアタッチされている
*/
public class InputManager : MonoBehaviour {

  //オブジェクトと結びつける
  InputField inputField;  //自分自身を入れる変数
  public Text Checktext; //RoomID確認用。
  public static string roomID; //roomIDを入れておく。他のシーンから参照する
  public static bool isGuest = false; //GuestかHostかの判定


  void Start () {
    PhotonNetwork.LocalPlayer.NickName = "プレイヤー"  + PlayerPrefs.GetString("SetName");  //表示するプレイヤー名を入れる
    inputField = this.GetComponent<InputField> (); //自分自身を入れておく

    if (Application.loadedLevelName == "HostMaking") { //ここはInputFieldがやることではない。でもここ変えたら他にいくつか変える必要がある。
      isGuest = false;
    }
    if (Application.loadedLevelName == "GuestEnter") {
      isGuest = true;
    }
    Debug.Log("guest : " + isGuest);
  }

  public void InputText(){
    //テキストにinputFieldの内容を反映
    if (Application.loadedLevelName == "HostMaking") { //GuestEnterシーンではCheckTextに入れる変数が存在しないため、これがないとエラー吐く
      Checktext.text = inputField.text;
    }
    roomID = inputField.text; //roomID保存
  }

  //ゲッター
  public static string getRoomID(){
    return roomID;
  }
  //ゲッター
  public static bool getIsguest(){
    return isGuest;
  }

}
