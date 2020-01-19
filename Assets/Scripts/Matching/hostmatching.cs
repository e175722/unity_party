using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/*
HostMakingシーンのhostmatching_managerにアタッチされている
*/

// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class hostmatching : MonoBehaviourPunCallbacks
{
  public static int playerID;  //使ってるかも
  public static int playerCount;  //??

  private void Start() {
    // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する

    var v = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));  //必要だけど・・・
    PhotonNetwork.Instantiate("GamePlayer", v, Quaternion.identity);  //ユーザーのインスタンスを作成
    playerID = PhotonNetwork.LocalPlayer.ActorNumber;  //使ってるかも
    Debug.Log("playerID = " + playerID);
  }


  void Update(){
    //playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
  }

}
