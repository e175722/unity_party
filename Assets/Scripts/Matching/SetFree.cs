using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SetFree : MonoBehaviour
{
  // Start is called before the first frame update
  public static bool isGuest_f;
  void Start()
  {
    PhotonNetwork.LocalPlayer.NickName = "プレイヤー：　"  + PlayerPrefs.GetString("SetName");  //表示するプレイヤー名を入れる
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SetHost(){
    if (Application.loadedLevelName == "Free") {
      isGuest_f = false;
    }
  }

  public void SetGuest(){
    if (Application.loadedLevelName == "Free") {
      isGuest_f = true;
    }
  }
}
