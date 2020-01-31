using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System;
using System.Linq;


/*
VotingシーンのButton_Decideにアタッチされている
*/
public class vote : MonoBehaviourPunCallbacks
{

  public static int voteNum = 0;　//自分が投票する番号
  public static int voteSum = 0;  //投票した回数
  public static int[] counter = new int[4]{0,0,0,0};//何番に何表投票されたかを入れておく配列
  public static string result = "";//もっとも多い表の回答を入れておくためのstring
  public static bool isSecond = false; //初めてVotingシーンに訪れたならfalse
  private static Hashtable roomHash = new Hashtable();//roomHashテーブル。同期を取るために必要。
  public Text SameVoteText; //最大投票数が複数出た場合に出現する

  void Start()
  {
    SameVoteText.text　= "";
    //問題出題されて初めてVotingシーンに訪れたら初期化
    if(isSecond == false){
      //初期化
      voteNum = 0;
      voteSum = 0;
      counter = new int[4]{0,0,0,0};
    }else{
      SameVoteText.text = "最も投票数の多かった回答が複数あったのであなたが決めましょう！";
    }

  }

  //何かしらセットされ次第始動(受信側)
  public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {

    if (propertiesThatChanged.TryGetValue("voteNum", out object voteNumObj)) {  //voteNumを取得。取得したものはvoteNumObjに格納。
      int num = (int)voteNumObj;  //voteNumObjをintにキャスト
      counter[num] = counter[num] + 1;   //0(num = 0)番に投票、[0,0,0,0] --> [1,0,0,0]
      int intMax = counter.Max();  //最も多い票数を獲得した回答を取得(その回答のindexではない)


      Debug.Log("------Votingシーンにて------");
      Debug.Log("-- counter start --");
      //counterの中身を全て確認
      foreach (int element in counter){
        Debug.Log(element);
      }
      Debug.Log("-- counter end --");
      Debug.Log("counterの最大値 :" +  intMax);


      int index2 = 0;  //最も多く表を獲得している回答のindexを格納するための変数
      for (int i = 0; i < counter.Length; i++){  //このforで表が最も多い回答を探す
        if (counter[i] == intMax){
          index2 = i;

        }
      }
      result = PlayerMgr.ansArray[index2];  //最も表を獲得した回答を格納
    }

    if(propertiesThatChanged.TryGetValue("voteSum", out object voteSumObj)) {  //voteSumの値を取得。取得したものはvoteSumObjに格納
      Debug.Log("voteSumの値_v : "  + (int)voteSumObj);
      voteSum = (int)voteSumObj;  //voteSumObjをintにキャスト
      if(voteSum >= PhotonNetwork.CurrentRoom.PlayerCount){  //人数分以上の投票数が出揃ったら

        int voteMaxNum = 0; //最大投票数の数

        for (int i = 0; i < counter.Length; i++){  //最も投票数が多いものの数を計算
          if (counter[i] == counter.Max()){
            voteMaxNum = voteMaxNum + 1;
          }
        }

        if(voteMaxNum == 1){ //投票最大数が一つの時
          isSecond = false;
          Application.LoadLevel("Answer");
        }else if(voteMaxNum != 1 && PhotonNetwork.IsMasterClient == true){
          Application.LoadLevel("Voting");
        }

      }
    }
  }


  //決定ボタンが押されたら動く(送信側)
  public void decide(){
    Debug.Log("決定ボタンが押されました," + voteNum + "に投票");
    roomHash["voteNum"] = voteNum;//roomHashに辞書型として送信したい値を入れる
    voteSum = voteSum + 1;//自分が投票した分のインクリメント
    roomHash["voteSum"] = voteSum;//roomHashに辞書型として送信したい値を入れる
    PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);//この行で送信
  }

  public int getVoteNum(){
    return voteNum;
  }


  // Update is called once per frame
  void Update()
  {
  }

}
