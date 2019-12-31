using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System;using System.Linq;


public class vote : MonoBehaviourPunCallbacks
{

    public GameObject obj;
    public static int voteNum = 0;　//自分が投票する番号
    private int[] counter = new int[4]{0,0,0,0};
    public string voteStr = "";
    List<string> item = new List<string>();

    private static Hashtable roomHash = new Hashtable();

    void Start()
    {

    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {
      if (propertiesThatChanged.TryGetValue("voteNum", out object voteNumObj)) {
         //int num = Convert.ToInt(voteNumObj);
         Debug.Log("voteNumの値"  + (int)voteNumObj);
         int num = (int)voteNumObj;
         Debug.Log("numの値");
         Debug.Log(num);
         counter[num] = counter[num] + 1;
         Debug.Log(counter[0]);
         Debug.Log(counter[1]);
         Debug.Log(counter[2]);
         Debug.Log(counter[3]);
         int　intMax　= counter.Max();
         //int index2 = Array.IndexOf(counter,intMax);
         int index2 = 0;
         for (int i = 0; i < counter.Length; i++){
           Debug.Log("要素");
           Debug.Log(counter[i]);
           if (counter[i] == intMax){
             Debug.Log("院でx†うくす");
             Debug.Log(i);
              index2 = i;
           }
         }
         Debug.Log("最大値 : " + intMax);
         Debug.Log("最大値のインデックス : " + index2);
         Debug.Log(PlayerMgr.ansArray[index2]);
         //Debug.Log(item[0]);
         // Debug.Log(item[1]);
         // Debug.Log(item[2]);
         // Debug.Log(item[3]);
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
            //voteStr = PlayerMgr.getLabel();
            //voteText.text = "0番が押されました";
						break;
				case 1:
						Debug.Log("1番が押されました");
            voteNum = 1;
            //voteStr = PlayerMgr.getLabel();
						break;
        case 2:
            Debug.Log("2番が押されました");
            voteNum = 2;
            //voteStr = PlayerMgr.getLabel();
            //voteText.text = "2番が押されました";
            break;
        case 3:
            Debug.Log("3番が押されました");
            voteNum = 3;
            //voteStr = PlayerMgr.getLabel();
            //voteText.text = "3番が押されました";
            break;
				default:
						break;
				}

		}


    public void decide(){
      Debug.Log("決定ボタンが押されました" + voteNum);
      //voteText.text = voteNum + "番に投票しました";
        roomHash["voteNum"] = voteNum;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        //item.Add(voteStr);
    }



    // Update is called once per frame
    void Update()
    {
    }
}
