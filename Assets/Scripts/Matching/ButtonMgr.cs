using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


/*
・MatchingシーンのCanvas,Button_ToQuestion
・TalkingシーンのCanvas,Button_ToVoting
・AnswerシーンのCanvas,Button_NextQuestion
にアタッチされている
*/
public class ButtonMgr : MonoBehaviour
{
  public GameObject DoneButton; //ホストのみが押せるボタンを入れておく
  public static bool isDone = false;  //同期を取るための変数。ホストがボタンを押したかどうかを入れる

  public static bool isPopupFlag = false; //Answerシーンのポップアップを出すのに使う.

  // Start is called before the first frame update
  void Start()
  {
    if (Application.loadedLevelName == "Matching"){
      isDone = false;
    }
  }

  // Update is called once per frame
  void Update()
  {
      //マスターかどうかで、ボタンオブジェクトをアクティブor非アクティブに
      if(PhotonNetwork.IsMasterClient == true ){
          DoneButton.SetActive(true);
      }else{
          DoneButton.SetActive(false);
      }

  }

  public void isDoneChange(){ //ボタンを押したらisDoneをtrueにする
    isDone = true;
    Debug.Log("完了がクリックされました。isDone = " + isDone);
  }

  public bool getIsPopupFlag(){ //ボタンを押したらisDoneをtrueにする
    return isPopupFlag;
  }

}
