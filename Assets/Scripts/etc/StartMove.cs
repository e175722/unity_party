using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/*
StartシーンのMaterにアタッチされている
*/
public class StartMove : MonoBehaviour {

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    bool resString = PlayerPrefs.HasKey("SetName");
    if (Input.GetMouseButton(0)) {  //画面をタッチしたら
      if (resString) //すでに名前が登録されてるかどうか。
      {
        SceneManager.LoadScene("Main");
      }else{
        SceneManager.LoadScene("Sign Up");
      }
    }
    //Debug.Log(resString);
  }
}
