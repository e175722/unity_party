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
    public static int Wait_QNowNum = 0; //Wait_Qルームにいる人数
    public static int CountNum_Q = 0; //誰かがルームを抜けた時に使用

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
      if(propertiesThatChanged.TryGetValue("Wait_QNow", out object WaitNowObj)) {  //WaitNowの値を取得。取得したものはWaitNowObjに格納
        int WaitNow = (int)WaitNowObj;
        CountNum_Q = CountNum_Q + 1; //1人から送信されるたびに+1
        if(WaitNow == 1){ //waitシーンにいるプレイヤーから送られてきたなら
          Wait_QNowNum = Wait_QNowNum + 1; //waitシーンにいる人数カウント
        }
        if(CountNum_Q == PhotonNetwork.CurrentRoom.PlayerCount){ //全員からの受信が終わったら(現在の人数=受信した数)
          if(count_Q == Wait_QNowNum){ //waitルームに入った人数とwaitシーンにいる人数が同じなら(抜けた人はQuestionシーンで抜けた)
            if(PhotonNetwork.IsMasterClient == true){ //マスターなら
              roomHash["count_Q"] = count_Q; //roomHashに辞書型として送信したい値を入れる
              PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
            }
          }else{ //抜けた人はwait_Qシーンで抜けた
            if(PhotonNetwork.IsMasterClient == true){ //マスターなら
              count_Q = count_Q - 1; //自分が投票した分のデクリメント
              roomHash["count_Q"] = count_Q; //roomHashに辞書型として送信したい値を入れる
              PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
            }
          }
        }
      }
    }


    //ボタンが押されたら動く(送信側)
    public void Done_Q(){
      count_Q = count_Q + 1;//自分が投票した分のインクリメント
      roomHash["count_Q"] = count_Q;//roomHashに辞書型として送信したい値を入れる
      PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
    }

    //Questionシーンで誰かが抜けたら、今wait_Qにいるかどうかを送信
    public override void OnPlayerLeftRoom(Photon.Realtime.Player player){
      CountNum_Q = 0;
      Wait_QNowNum = 0;
      int WaitNow = 0; //Waitシーンにいるかどうかのかの変数
      if(Application.loadedLevelName == "Wait_Q"){
        WaitNow = 1; //自分はwaitシーンにいるというフラグ
        roomHash["Wait_QNow"] = WaitNow; //roomHashに辞書型として送信したい値を入れる
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
      }else{
        roomHash["Wait_QNow"] = WaitNow; //roomHashに辞書型として送信したい値を入れる
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
      }
    }
}
