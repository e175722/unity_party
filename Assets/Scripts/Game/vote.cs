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

    public static int voteNum = 0;　//自分が投票する番号
    public static int voteSum = 0;  //投票した回数
    public static int[] counter = new int[4]{0,0,0,0};
    public static string result = "";


    private static Hashtable roomHash = new Hashtable();

    void Start()
    {
        //初期化
        voteNum = 0;　
        voteSum = 0;
        counter = new int[4]{0,0,0,0};
    }

    //何かしらセットされ次第始動(受信側)
    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {
        if (propertiesThatChanged.TryGetValue("voteNum", out object voteNumObj)) {
            int num = (int)voteNumObj;
            counter[num] = counter[num] + 1; //0(num = 0)番に投票、[0,0,0,0] --> [1,0,0,0]
            int intMax = counter.Max();

            Debug.Log("------Votingシーンにて------");
            Debug.Log("-- counter start --");
            //counterの中身を全て確認
            foreach (int element in counter){
                Debug.Log(element);
            }
            Debug.Log("-- counter end --");

            Debug.Log("counterの最大値 :" +  intMax);
            int index2 = 0;
            for (int i = 0; i < counter.Length; i++){
                if (counter[i] == intMax){
                    index2 = i;
                }
            }
            result = PlayerMgr.ansArray[index2];
        }
        if(propertiesThatChanged.TryGetValue("voteSum", out object voteSumObj)) {
            Debug.Log("voteSumの値_v : "  + (int)voteSumObj);
            voteSum = (int)voteSumObj;
            if(voteSum == PhotonNetwork.CurrentRoom.PlayerCount){
                Application.LoadLevel("Answer");
            }
        }
    }


    //決定ボタンが押されたら動く(送信側)
    public void decide(){
        Debug.Log("決定ボタンが押されました," + voteNum + "に投票");
        roomHash["voteNum"] = voteNum;
        voteSum = voteSum + 1;
        roomHash["voteSum"] = voteSum;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);

    }


    // Update is called once per frame
    void Update()
    {
    }

}
