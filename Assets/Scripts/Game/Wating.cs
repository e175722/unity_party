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
  // Start is called before the first frame update
  void Start()
  {
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
      if(vote.voteSum == PhotonNetwork.CurrentRoom.PlayerCount){  //人数分の投票が出揃ったらAnswerシーンに遷移
        Application.LoadLevel("Answer");
      }
    }
  }

}
