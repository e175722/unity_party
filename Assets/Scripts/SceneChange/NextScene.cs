using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;
using System;



/*
いろいろアタッチされてます
*/

public class NextScene : MonoBehaviourPunCallbacks
{
  // Start is called before the first frame update
  void Start()
  {
  }
  // Update is called once per frame
  void Update()
  {
  }



  //Sign Upシーンからの遷移
  public void  SignUp_To_Start(string resultMessage){
    if (Application.loadedLevelName == "Sign Up") {
      Application.LoadLevel ("Start");
    }
  }
  public void  SignUp_To_Main(string resultMessage){
    if (Application.loadedLevelName == "Sign Up") {
      Application.LoadLevel ("Main");
    }
  }



  //Mainシーンから他への遷移
  public void  Main_To_Room(string resultMessage){
    if (Application.loadedLevelName == "Main") {
      Application.LoadLevel ("Room");
    }
  }
  public void  Main_To_Setting(string resultMessage){
    if (Application.loadedLevelName == "Main") {
      Application.LoadLevel ("Setting");
    }
  }
  public void Main_To_HowToPlay(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Main") {
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene ("HowToPlay",0.7f);
    }
  }



  //Settingシーンから他への遷移
  public void  Setting_To_ChangeName(string resultMessage){
    if (Application.loadedLevelName == "Setting"){
      Application.LoadLevel("ChangeName");
    }
  }
  public void  Setting_To_Main(string resultMessage){
    if (Application.loadedLevelName == "Setting"){
      Application.LoadLevel("Main");
    }
  }



  //ChangeNameシーンから他への遷移
  public void  ChangeName_To_Setting(string resultMessage){
    if (Application.loadedLevelName == "ChangeName"){
      Application.LoadLevel("Setting");
    }
  }
  public void  ChangeName_To_Main(string resultMessage){
    if (Application.loadedLevelName == "ChangeName"){
      Application.LoadLevel("Main");
    }
  }

  //HowToPlayシーンから他への遷移
  public void  HowToPlay_To_Main(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "HowToPlay"){
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene("Main",0.7f);
    }
  }



  //Roomシーンから他への遷移
  public void  Room_To_Private(string resultMessage){
    if (Application.loadedLevelName == "Room"){
      Application.LoadLevel("Private");
    }
  }
  public void  Room_To_Free(string resultMessage){
    if (Application.loadedLevelName == "Room"){
      Application.LoadLevel("Free");
    }
  }
  public void  Room_To_Main(string resultMessage){
    if (Application.loadedLevelName == "Room"){
      Application.LoadLevel("Main");
    }
  }



  //Privateシーンから他への遷移
  public void  Private_To_HostMaking(string resultMessage){
    if (Application.loadedLevelName == "Private"){
      Application.LoadLevel("HostMaking");
    }
  }
  public void  Private_To_GuestEnter(string resultMessage){
    if (Application.loadedLevelName == "Private"){
      Application.LoadLevel("GuestEnter");
    }
  }
  public void  Private_To_Room(string resultMessage){
    if (Application.loadedLevelName == "Private"){
      Application.LoadLevel("Room");
    }
  }



  //Freeシーンから他への遷移
  public void  Free_To_Room(string resultMessage){
    if (Application.loadedLevelName == "Free"){
      Application.LoadLevel("Room");
    }
  }
  public void  Free_To_HostFree(string resultMessage){
    if (Application.loadedLevelName == "Free"){
      Application.LoadLevel("HostFree");
    }
  }
  public void  Free_To_GuestFree(string resultMessage){
    if (Application.loadedLevelName == "Free"){
      Application.LoadLevel("GuestFree");
    }
  }



  //HostMakingから他への遷移
  public void  HostMaking_To_Matching(string resultMessage){
    if (Application.loadedLevelName == "HostMaking"){
      Application.LoadLevel("Matching");
    }
  }
  public void  HostMaking_To_Private(string resultMessage){
    if (Application.loadedLevelName == "HostMaking"){
      Application.LoadLevel("Private");
    }
  }



  //GuestEnterから他への遷移
  public void  GuestEnter_To_Matching(string resultMessage){
    if (Application.loadedLevelName == "GuestEnter"){
      Application.LoadLevel("Matching");
    }
  }
  public void  GuestEnter_To_Private(string resultMessage){
    if (Application.loadedLevelName == "GuestEnter"){
      Application.LoadLevel("Private");
    }
  }



  //Answerから他への遷移
  public void  Answer_To_Question(string resultMessage){
    if(Application.loadedLevelName == "Answer") {
      //Application.LoadLevel ("Question");
      ButtonMgr.isPopupFlag = true;
      GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
       GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
    }
  }
  public void  Answer_To_Main(string resultMessage){
    if(Application.loadedLevelName == "Answer") {
      //PhotonNetwork.LeaveRoom();
      //PhotonNetwork.Disconnect();
      //Application.LoadLevel ("Main");
      ButtonMgr.isPopupFlag = false;
      GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
       GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
    }
  }




  //ここからホストのみが遷移可能なやつら
  //Mtchingから他へのの遷移
  public void  Matching_To_Question(){
    if (Application.loadedLevelName == "Matching"){
      GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
       GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
       //PhotonNetwork.CurrentRoom.IsOpen = false; //ルームを閉鎖する
      //Application.LoadLevel("Question");
    }
  }
  //Questionから他への遷移
  public void  Question_To_WaitQ(string resultMessage){
    if(Application.loadedLevelName == "Question") {
      GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
       GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
      //Application.LoadLevel ("Talking");
      //Application.LoadLevel ("Wait_Q");

    }
  }
  //Talkingから他への遷移
  public void  Talking_To_Voting(string resultMessage){
    if(Application.loadedLevelName == "Talking") {
      Application.LoadLevel ("Voting");
    }
  }
  //Votingから他への遷移
  public void  Voting_To_Wait(string resultMessage){
    if(Application.loadedLevelName == "Voting") {
      GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
       GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
      //Application.LoadLevel ("Wait");
    }
  }
}
