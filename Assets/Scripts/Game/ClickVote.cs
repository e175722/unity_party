using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
GamePlayerプレハブのButtonにアタッチされている
*/
public class ClickVote : MonoBehaviour
{
  public GameObject obj; //投票ボタンオブジェクトを入れる変数

  void Start()
  {
  }

  void Update()
  {
  }

  //投票ボタンが押された時
  public void OnClick (){
    string text = this.obj.transform.Find("Text").GetComponent<Text>().text; //投票ボタンの持っているテキストを取得
    int number = 0; //number初期化。これに選んだ選択肢のindexを入れる
    for (int i = 0; i < PlayerMgr.ansArray.Count; i++){ //全員の回答が入っているansArray配列の一つ一つと比較して、押されたボタンを判定させる。
      if (PlayerMgr.ansArray[i] == text){
        number = i;
      }
    }
    vote.voteNum = number; //vote.voteNumが実際に同期とられる変数
  }
}
