using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class InputManagerFree : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isGuest_f;
    void Start()
    {
        PhotonNetwork.LocalPlayer.NickName = "プレイヤー"  + PlayerPrefs.GetString("SetName");  //表示するプレイヤー名を入れる
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHost(){
      if (Application.loadedLevelName == "Free") { //ここはInputFieldがやることではない。でもここ変えたら他にいくつか変える必要がある。
        Debug.Log("isGuest_fをfalseにした");
        isGuest_f = false;
      }
    }

    public void SetGuest(){
      if (Application.loadedLevelName == "Free") { //ここはInputFieldがやることではない。でもここ変えたら他にいくつか変える必要がある。
        Debug.Log("isGuest_fをtrueにした");
        isGuest_f = true;
      }
    }
}
