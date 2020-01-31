using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

/*
QuestionシーンのButton_ToWatingにアタッチされている
Wait_QシーンのWating_Q_Textにアタッチされている
*/

public class Wating_Q : MonoBehaviourPunCallbacks
{
    public static int count_Q = 0;//Wait_Qシーンに入ってきた人のカウントをする変数
    private static Hashtable roomHash = new Hashtable();//roomHashテーブル。同期を取るために必要。

    // Start is called before the first frame update
    void Start()
    {
      //カウントの初期化
      if(Application.loadedLevelName == "Question"){
        count_Q = 0;
      }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {
      if (propertiesThatChanged.TryGetValue("count_Q", out object countObj)) {  //count_Qを取得。取得したものはcountObjに格納。
        count_Q = (int)countObj; //countObjをintにキャスト
        Debug.Log("count数 : " + count_Q);
        Debug.Log("現在の部屋人数 : " + PhotonNetwork.CurrentRoom.PlayerCount);
        if(count_Q == PhotonNetwork.CurrentRoom.PlayerCount){ //現在の人数が揃ったら次のシーンに遷移
          Application.LoadLevel("Talking");
        }
      }
    }


    //ボタンが押されたら動く(送信側)
    public void Done_Q(){
      count_Q = count_Q + 1;//自分が投票した分のインクリメント
      roomHash["count_Q"] = count_Q;//roomHashに辞書型として送信したい値を入れる
      PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
    }
}
