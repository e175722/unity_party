using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System;

public class CreateQuestion : MonoBehaviourPunCallbacks
{
    public Text text;
    private static string hiragana = "あいうえおかきくけこさしすせそたちつてとなにねのはひふへほまみむめもらりるれろやゆよわ";
    private static string[] odai = new string[9] {"有名人", "夏の果物", "冬の果物", "夏の曲", "冬の曲", "今話題の人", "黒歴史","言われて嬉しい言葉","言われたら嫌な言葉"};
    private static string sentense;
    private static Hashtable roomHash = new Hashtable();
 
    // Start is called before the first frame update
    void Start()
    {   
        if (Application.loadedLevelName == "Question") {
            if(PhotonNetwork.IsMasterClient){
                sentense = "「" + hiragana[UnityEngine.Random.Range(0, 42)] + "」で始まる" + odai[UnityEngine.Random.Range(0, 8)] + "といえば";
                roomHash["sentense"] = sentense;
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                //Debug.Log(sentense);
            }
        }
        else if (Application.loadedLevelName == "Answer") {
             if(PhotonNetwork.IsMasterClient){
                roomHash["sentense"] = sentense;
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                //Debug.Log(sentense);
             }
        }
    }
    
    // ルームのハッシュが送信されたら、送信されたハッシュが入ってくる(Photonの機能で戻り値の型、関数名、引数を一致させると勝手に呼ばれる)
    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {
       if (propertiesThatChanged.TryGetValue ("sentense", out object sentenseObj)) {
           string test = Convert.ToString(sentenseObj);
           text.text = test;
       }
    }
 
    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.IsMasterClient){
            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        }
    }
    
}