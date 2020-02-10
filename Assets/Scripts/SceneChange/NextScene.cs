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
  public AudioClip next;
  public AudioClip back;
  AudioSource audioSource;
  //Sign Upシーンからの遷移
  public void  SignUp_To_Start(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Sign Up") {
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene ("Start",0.7f);
    }
  }
  public void  SignUp_To_Main(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Sign Up") {
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene ("Main",0.7f);
    }
  }



  //Mainシーンから他への遷移
  public void  Main_To_Room(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Main") {
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene ("Room",0.7f);
    }
  }
  public void  Main_To_Setting(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Main") {
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene ("Setting",0.7f);
    }
  }



  //Settingシーンから他への遷移
  public void  Setting_To_ChangeName(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Setting"){
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene("ChangeName",0.7f);
    }
  }
  public void  Setting_To_Main(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Setting"){
      audioSource.PlayOneShot(back);
      FadeManager.Instance.LoadScene("Main",0.7f);
    }
  }



  //ChangeNameシーンから他への遷移
  public void  ChangeName_To_Setting(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "ChangeName"){
      audioSource.PlayOneShot(back);
      FadeManager.Instance.LoadScene("Setting",0.7f);
    }
  }
  public void  ChangeName_To_Main(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "ChangeName"){
      audioSource.PlayOneShot(back);
      FadeManager.Instance.LoadScene("Main",0.7f);
    }
  }



  //Roomシーンから他への遷移
  public void  Room_To_Private(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Room"){
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene("Private",0.7f);
    }
  }
  public void  Room_To_Free(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Room"){
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene("Free",0.7f);
    }
  }
  public void  Room_To_Main(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Room"){
      audioSource.PlayOneShot(back);
      FadeManager.Instance.LoadScene("Main",0.7f);
    }
  }



  //Privateシーンから他への遷移
  public void  Private_To_HostMaking(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Private"){
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene("HostMaking",0.7f);
    }
  }
  public void  Private_To_GuestEnter(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Private"){
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene("GuestEnter",0.7f);
    }
  }
  public void  Private_To_Room(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Private"){
      audioSource.PlayOneShot(back);
      FadeManager.Instance.LoadScene("Room",0.7f);
    }
  }



  //Freeシーンから他への遷移
  public void  Free_To_Room(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Free"){
      audioSource.PlayOneShot(back);
      FadeManager.Instance.LoadScene("Room",0.7f);
    }
  }
  public void  Free_To_HostFree(string resultMessage){
    if (Application.loadedLevelName == "Free"){
      Application.LoadLevel("HostFree");
    }
  }



  //HostMakingから他への遷移
  public void  HostMaking_To_Matching(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "HostMaking"){
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene("Matching",0.7f);
    }
  }
  public void  HostMaking_To_Private(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "HostMaking"){
      audioSource.PlayOneShot(back);
      FadeManager.Instance.LoadScene("Private",0.7f);
    }
  }



  //GuestEnterから他への遷移
  public void  GuestEnter_To_Matching(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "GuestEnter"){
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene("Matching",0.7f);
    }
  }
  public void  GuestEnter_To_Private(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "GuestEnter"){
      audioSource.PlayOneShot(back);
      FadeManager.Instance.LoadScene("Private",0.7f);
    }
  }



  //Answerから他への遷移
  public void  Answer_To_Question(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if(Application.loadedLevelName == "Answer") {
      //FadeManager.Instance.LoadScene ("Question");
      ButtonMgr.isPopupFlag = true;
      GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
      GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
    }
  }
  public void  Answer_To_Main(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if(Application.loadedLevelName == "Answer") {
      //PhotonNetwork.LeaveRoom();
      //PhotonNetwork.Disconnect();
      //FadeManager.Instance.LoadScene ("Main");
      ButtonMgr.isPopupFlag = false;
      GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
      GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
    }
  }




  //ここからホストのみが遷移可能なやつら
  //Mtchingから他へのの遷移
  public void  Matching_To_Question(){
    audioSource = GetComponent<AudioSource>();
    if (Application.loadedLevelName == "Matching"){
      GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
      GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
      //FadeManager.Instance.LoadScene("Question");
    }
  }
  //Questionから他への遷移
  public void  Question_To_WaitQ(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if(Application.loadedLevelName == "Question") {
      GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
      GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
      //FadeManager.Instance.LoadScene ("Talking");
      //FadeManager.Instance.LoadScene ("Wait_Q");

    }
  }
  //Talkingから他への遷移
  public void  Talking_To_Voting(string resultMessage){
    audioSource = GetComponent<AudioSource>();
    if(Application.loadedLevelName == "Talking") {
      audioSource.PlayOneShot(next);
      FadeManager.Instance.LoadScene ("Voting",0.7f);
    }
  }
  //Votingから他への遷移
  public void  Voting_To_Wait(string resultMessage){
    //audioSource = GetComponent<AudioSource>();
    if(Application.loadedLevelName == "Voting") {
      Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaa");
      GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
      GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
      //FadeManager.Instance.LoadScene ("Wait",0.7f);
    }
  }
}
