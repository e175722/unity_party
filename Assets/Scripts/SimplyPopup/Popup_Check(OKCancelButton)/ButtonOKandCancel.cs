using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;



public class ButtonOKandCancel : MonoBehaviourPunCallbacks
{
  public float timeOut = 0.1f;
  private float timeElapsed;
  //public InputField InputChangeName;
  InputField objGet;
  // Start is called before the first frame update
  void Start()
  {
    this.GetComponent<Image>().color = new Color (0, 0, 0, 0);
    this.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color (0, 0, 0, 0);
  }

  // Update is called once per frame
  void Update()
  {
    timeElapsed += Time.deltaTime;

    if(timeElapsed >= timeOut) {
      this.gameObject.GetComponent<Image>().color = Color.white;
      this.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;

    }
  }
 /// public override void OnDisconnected(DisconnectCause cause){
  //  FadeManager.Instance.LoadScene("Main",0.7f);
  //}

  public void OKButton()
  {
    if (Application.loadedLevelName == "ChangeName" || Application.loadedLevelName == "Sign Up" ){
      objGet = GameObject.Find("InputField_InputName").GetComponent<InputField>();
      //name = objGet.transform.GetChild(2).gameObject.GetComponent<Text>().text;
      string name = objGet.text;
      PlayerPrefs.DeleteKey("SetName");
      PlayerPrefs.SetString("SetName", name);
      PlayerPrefs.Save();
      GameObject obj = (GameObject)Resources.Load ("Popup_Alert(OnlyOKButton)");
      GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
      Debug.Log("名前の変更が行われました");
      Debug.Log("変更後 " + name);
    }
    else if(Application.loadedLevelName == "HostMaking"){
      GameObject objGet2 = GameObject.Find("Button_MakeRoom");
      objGet2.GetComponent<ChangeToMatching>().NextScene( );
      }
      else if(Application.loadedLevelName == "GuestEnter"){
      GameObject objGet2 = GameObject.Find("Button_Participate");
      objGet2.GetComponent<ChangeToMatching>().NextScene( );
      }
      else if(Application.loadedLevelName == "HostFree"){
        GameObject objGet2 = GameObject.Find("Button_ToMaching");
        objGet2.GetComponent<MatchingFree>().NextScene( );
        }
        else if(Application.loadedLevelName == "Free"){
          GameObject objGet2 = GameObject.Find("Button_Guest");
          objGet2.GetComponent<MatchingFree>().NextScene( );
          }
    else if(Application.loadedLevelName == "Matching"){
      GameObject objGet2 = GameObject.Find("Button_ToQuestion");
      objGet2.GetComponent<ButtonMgr>().isDoneChange( );
      //audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene("Question",0.7f);
      //Application.LoadLevel("Question");
    }
    else if(Application.loadedLevelName == "Question"){
      GameObject objGet2 = GameObject.Find("Button_ToWating");
      //objGet2.GetComponent<Wating_Q>().Done_Q();
      //audioSource.PlayOneShot(next);
     FadeManager.Instance.LoadScene("Wait_Q",0.7f);
     //Application.LoadLevel("Wait_Q");
    }
    else if(Application.loadedLevelName == "Voting"){
     // GameObject objGet2 = GameObject.Find("Button_VoteDecide");
      //objGet2.GetComponent<vote>().decide();
     // audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene("Wait",0.7f);
      //Application.LoadLevel("Wait");
    }
    else if(Application.loadedLevelName == "Answer"){
      GameObject objGet2 = GameObject.Find("Button_BackToMain");
      bool PopupFlag = objGet2.GetComponent<Answer_Button>().getIsPopupFlag();
      if(PopupFlag == true){
     // audioSource.PlayOneShot(next);
     GameObject objGet3 = GameObject.Find("Button_NextQuestion");
     objGet3.GetComponent<ButtonMgr>().isDoneChange();
      FadeManager.Instance.LoadScene("Question",0.7f);

     // Application.LoadLevel("Question");
     }
     else{
       PhotonNetwork.LeaveRoom();
       PhotonNetwork.Disconnect();
      // audioSource.PlayOneShot(next);
       FadeManager.Instance.LoadScene("Main",0.7f);
      // Application.LoadLevel ("Main");
     }
    }
  }
}
