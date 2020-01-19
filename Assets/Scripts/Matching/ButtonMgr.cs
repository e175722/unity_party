using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


/*
・MatchingシーンのButton_ToQuestion
・TalkingシーンのButton_ToVoting
・AnswerシーンのButton_NextQuestion
にアタッチされている
*/
public class ButtonMgr : MonoBehaviour
{
  public GameObject DoneButton; //ホストのみが押せるボタンを入れておく
  public static bool isDone = false;  //同期を取るための変数。ホストがボタンを押したかどうかを入れる

  // Start is called before the first frame update
  void Start()
  {
    if(InputManager.getIsguest() == true){ //ホスト以外非表示
      DoneButton.SetActive(false);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void isDoneChange(){ //ボタンを押したらisDoneをtrueにする
    isDone = true;
    Debug.Log("完了がクリックされました。isDone = " + isDone);
  }

}
