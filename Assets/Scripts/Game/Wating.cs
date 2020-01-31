using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Linq;
using System;


/*
WaitシーンのMain_Cameraにアタッチされている
*/

public class Wating : MonoBehaviourPunCallbacks
{
  private static Hashtable roomHash = new Hashtable();//roomHashテーブル。同期を取るために必要。

  // Start is called before the first frame update
  void Start()
  {
      vote.isSecond = true;　//Waitシーンにいる時点でvoingシーンに訪れるのが初めてではないためtrueに
  }

  // Update is called once per frame
  void Update()
  {

  }
  //何かしらセットされ次第始動(受信側)
  public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {
    if (propertiesThatChanged.TryGetValue("voteNum", out object voteNumObj)) {  //voteNumを取得。取得したものはvoteNumObjに格納。
      int num = (int)voteNumObj;  //voteNumObjをintにキャスト
      vote.counter[num] = vote.counter[num] + 1;  //0(num = 0)番に投票、[0,0,0,0] --> [1,0,0,0]
      int intMax = vote.counter.Max();  //最も多い票数を獲得した回答を取得(その回答のindexではない)

      Debug.Log("-------Wateシーンにて-------");
      Debug.Log("-- counter start --");
      //counterの中身を全て確認
      foreach (int element in vote.counter){
        Debug.Log(element);
      }
      Debug.Log("-- counter end --");

      int index2 = 0;  //最も多く表を獲得している回答のindexを格納するための変数
      for (int i = 0; i < vote.counter.Length; i++){  //このforで表が最も多い回答を探す
        if (vote.counter[i] == intMax){
          index2 = i;
        }
      }
      vote.result = PlayerMgr.ansArray[index2];  //最も表を獲得した回答を格納
    }
    if(propertiesThatChanged.TryGetValue("voteSum", out object voteSumObj)) {  //voteSumの値を取得。取得したものはvoteSumObjに格納
      Debug.Log("voteSumの値_w : "  + (int)voteSumObj);
      vote.voteSum = (int)voteSumObj;  //voteSumObjをintにキャスト
      if(vote.voteSum >= PhotonNetwork.CurrentRoom.PlayerCount){  //人数分以上の投票が出揃ったらAnswerシーンに遷移

        int voteMaxNum = 0; //最大投票数の数

        for (int i = 0; i < vote.counter.Length; i++){  //最も投票数が多いものの数を計算
          if (vote.counter[i] == vote.counter.Max()){
            voteMaxNum = voteMaxNum + 1;
          }
        }

        if(voteMaxNum == 1){ //投票最大数が一つの時
          vote.isSecond = false;
          Application.LoadLevel("Answer");
        }else if(voteMaxNum != 1 && PhotonNetwork.IsMasterClient == true){
          Application.LoadLevel("Voting");
        }

      }
    }
    if(propertiesThatChanged.TryGetValue("WaitNow", out object WaitNowObj)) {  //WaitNowの値を取得。取得したものはWaitNowObjに格納
      int WaitNow = (int)WaitNowObj;
      vote.CountNum = vote.CountNum + 1; //1人から送信されるたびに+1
      if(WaitNow == 1){ //waitシーンにいるプレイヤーから送られてきたなら
        vote.WaitNowNum = vote.WaitNowNum + 1; //waitシーンにいる人数カウント
      }
      if(vote.CountNum == PhotonNetwork.CurrentRoom.PlayerCount){ //全員からの受信が終わったら(現在の人数=受信した数)
        if(vote.voteSum == vote.WaitNowNum){ //投票数とwaitシーンにいる人数が同じなら(抜けた人はvotingシーンで抜けた)
          if(PhotonNetwork.IsMasterClient == true){ //マスターなら
            roomHash["voteSum"] = vote.voteSum; //roomHashに辞書型として送信したい値を入れる
            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
          }
        }else{ //抜けた人はwaitシーンで抜けた
          if(PhotonNetwork.IsMasterClient == true){ //マスターなら
            vote.voteSum = vote.voteSum - 1; //投票数を-1
            roomHash["voteSum"] = vote.voteSum; //roomHashに辞書型として送信したい値を入れる
            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
          }
        }
      }
    }
  }

  //Waitシーンにいるのかどうかを送信しようかな
  public override void OnPlayerLeftRoom(Photon.Realtime.Player player){
    vote.CountNum = 0;
    vote.WaitNowNum = 0;
    int WaitNow = 0; //Waitシーンにいるかどうかのかの変数
    if(Application.loadedLevelName == "Wait"){
      WaitNow = 1; //自分はwaitシーンにいるというフラグ
      roomHash["WaitNow"] = WaitNow; //roomHashに辞書型として送信したい値を入れる
      PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
    }else{
      roomHash["WaitNow"] = WaitNow; //roomHashに辞書型として送信したい値を入れる
      PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
    }
  }

}
