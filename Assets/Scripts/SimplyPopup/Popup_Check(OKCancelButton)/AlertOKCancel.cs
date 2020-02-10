using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AlertOKCancel : MonoBehaviour
{


  public float timeOut = 0.1f;
  private float timeElapsed;
  InputField  objGet;
  // Start is called before the first frame update
  void Start()
  {
    this.GetComponent<Text>().color = new Color (0, 0, 0, 0);
    if (Application.loadedLevelName == "ChangeName"){
      objGet = GameObject.Find("InputField_InputName").GetComponent<InputField>();
      //string name = objGet.transform.GetChild(2).gameObject.GetComponent<Text>().text;
      string name = objGet.text;
      this.GetComponent<Text>().text = "名前を " + name + " に変更してもよろしいですか？";
    }
    else if(Application.loadedLevelName == "Sign Up"){
      objGet = GameObject.Find("InputField_InputName").GetComponent<InputField>();
      //string name = objGet.transform.GetChild(2).gameObject.GetComponent<Text>().text;
      string name = objGet.text;
      this.GetComponent<Text>().text = "名前を " + name + " で決定してもよろしいですか？";
    }
    else if(Application.loadedLevelName == "HostMaking"){
      objGet = GameObject.Find("InputField_InputRoomID").GetComponent<InputField>();
      //string name = objGet.transform.GetChild(2).gameObject.GetComponent<Text>().text;
      string name = objGet.text;
      this.GetComponent<Text>().text = "ルーム名 " + name + " で作成してもよろしいですか？";
    }
    else if(Application.loadedLevelName == "GuestEnter"){
      objGet = GameObject.Find("InputField_InputRoomID").GetComponent<InputField>();
      //string name = objGet.transform.GetChild(2).gameObject.GetComponent<Text>().text;
      string name = objGet.text;
      this.GetComponent<Text>().text = "ルーム名 " + name + " に入室してもよろしいですか？";
    }
    else if(Application.loadedLevelName == "HostFree"){
      this.GetComponent<Text>().text = "フリールームを作成してもいいですか？";
    }
    else if(Application.loadedLevelName == "Free"){
      this.GetComponent<Text>().text = "フリールームに参加してもいいですか？";
    }

    else if(Application.loadedLevelName == "Matching"){
      this.GetComponent<Text>().text = "このメンバーで始めてもよろしいですか？";
    }
    else if(Application.loadedLevelName == "Question"){
      objGet = GameObject.Find("InputField_InputAnswer").GetComponent<InputField>();
      //string answer = objGet.transform.GetChild(2).gameObject.GetComponent<Text>().text;
      string answer = objGet.text;
      this.GetComponent<Text>().text = "回答は " + answer + " でよろしいですか？";
    }
    else if(Application.loadedLevelName == "Voting"){
      GameObject objGet2 = GameObject.Find("Button_VoteDecide");
      //objGet2.GetComponent<Vote>().voteVum;
      //string answer = objGet.transform.GetChild(2).gameObject.GetComponent<Text>().text;
      int voteNum = objGet2.GetComponent<vote>().getVoteNum();
      this.GetComponent<Text>().text = "投票は　" + PlayerMgr.ansArray[voteNum] + " でよろしいですか？";
    }
    else if(Application.loadedLevelName == "Answer"){
      GameObject objGet2 = GameObject.Find("Button_BackToMain");
      bool PopupFlag = objGet2.GetComponent<Answer_Button>().getIsPopupFlag();
      if(PopupFlag == true){
      this.GetComponent<Text>().text = "次の問題にいってもよろしいですか？";
     }
     else{
      this.GetComponent<Text>().text = "Main画面に戻ってもいいですか？";
     }

    }
  }

  // Update is called once per frame
  void Update()
  {
    timeElapsed += Time.deltaTime;

    if(timeElapsed >= timeOut) {
      this.gameObject.GetComponent<Text>().color = Color.black;
    }
  }
}
