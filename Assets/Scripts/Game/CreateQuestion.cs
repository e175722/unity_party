using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System;



/*
・QuestionシーンのText_Qestion
・AnswerシーンのText_Question
にアタッチされている
*/
public class CreateQuestion : MonoBehaviourPunCallbacks
{

  public Text text;
  //private static string hiragana = "あいうえおかきくけこさしすせそたちつてとなにねのはひふへほまみむめもらりるれろやゆよわ";
  //private static string[] odai = new string[9] {"有名人", "夏の果物", "冬の果物", "夏の曲", "冬の曲", "今話題の人", "黒歴史","言われて嬉しい言葉","言われたら嫌な言葉"};
  private static string sentense;
  private static Hashtable roomHash = new Hashtable();

  public string[] textMessage; //問題を入れる配列

  // Start is called before the first frame update
  void Start()
  {
    if (Application.loadedLevelName == "Question") {
      if(PhotonNetwork.IsMasterClient){
        //sentense = "「" + hiragana[UnityEngine.Random.Range(0, 42)] + "」で始まる" + odai[UnityEngine.Random.Range(0, 8)] + "といえば";
        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load("QestionList", typeof(TextAsset) )as TextAsset; //Resourcesフォルダから対象テキストを取得
        string TextLines = textasset.text; //テキスト全体をstring型で入れる変数を用意して入れる
        textMessage = TextLines.Split('\n'); //ここで問題を改行ごとにわける
        //Debug.Log(textMessage.Length);
        sentense = textMessage[UnityEngine.Random.Range(0, textMessage.Length)];
        roomHash["sentense"] = sentense;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        //Debug.Log(sentense);
      }
      else{
        int request = -1;
         roomHash["request"] = request;
         PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
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
      sentense = test;
    }
    if (propertiesThatChanged.TryGetValue ("request", out object requestObj)) {
         if(PhotonNetwork.IsMasterClient){
            roomHash["sentense"] = sentense;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        }
        //int test = Convert.ToInt32(requestObj);
        
  }
  }

  // Update is called once per frame
  void Update()
  {
  }

}
