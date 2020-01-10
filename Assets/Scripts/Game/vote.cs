using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System;
using System.Linq;


public class vote : MonoBehaviourPunCallbacks
{

  public GameObject obj;
  public static int voteNum = 0;　//自分が投票する番号
  public static int voteSum = 0;  //投票した回数
  public static int[] counter = new int[4]{0,0,0,0};
  public string voteStr = "";
  List<string> item = new List<string>();
  public static string result = "";
  public GameObject photonIns;

  private static Hashtable roomHash = new Hashtable();
  private static Hashtable voteHash = new Hashtable();

  void Start()
  {
    voteNum = 0;　
    voteSum = 0;  
    counter = new int[4]{0,0,0,0};
  }

  public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {
    if (propertiesThatChanged.TryGetValue("voteNum", out object voteNumObj)) {
      int num = (int)voteNumObj;
      counter[num] = counter[num] + 1;
      int intMax = counter.Max();
      Debug.Log(intMax);
      int index2 = 0;
      for (int i = 0; i < counter.Length; i++){
        if (counter[i] == intMax){
          index2 = i;
        }
      }    
      Debug.Log(intMax);   
      result = PlayerMgr.ansArray[index2];
    }
    if(propertiesThatChanged.TryGetValue("voteSum", out object voteSumObj)) {
      Debug.Log("voteSumの値"  + (int)voteSumObj);
      voteSum = (int)voteSumObj;
      if(voteSum == PhotonNetwork.CurrentRoom.PlayerCount){
        Application.LoadLevel("Answer");
      }
    }
  }


  //投票ボタンが押された時
  public void OnClick (){
    string text = this.obj.transform.Find("Text").GetComponent<Text>().text;
    int number = 0;
    for (int i = 0; i < PlayerMgr.ansArray.Length; i++){
      if (PlayerMgr.ansArray[i] == text){
        number = i;
      }
    }
    Debug.Log("ボタン判定");
    Debug.Log(number);
    switch (number) {
      case 0:
      Debug.Log("0番が押されました");
      voteNum = 0;
      break;
      case 1:
      Debug.Log("1番が押されました");
      voteNum = 1;
      break;
      case 2:
      Debug.Log("2番が押されました");
      voteNum = 2;
      break;
      case 3:
      Debug.Log("3番が押されました");
      voteNum = 3;
      break;
      default:
      break;
    }
  }


  public void decide(){
    Debug.Log("決定ボタンが押されました" + voteNum);
    roomHash["voteNum"] = voteNum;
    voteSum = voteSum + 1;
    roomHash["voteSum"] = voteSum;
    PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);

    //voteSum = voteSum + 1;
    //voteHash["voteSum"] = voteSum;
    //PhotonNetwork.CurrentRoom.SetCustomProperties(voteHash);
  }


  // Update is called once per frame
  void Update()
  {
  }

}
