using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Linq;

/*
StartシーンのMaterにアタッチされている
*/
public class StartMove : MonoBehaviour {

public AudioClip next;
AudioSource audioSource;
  // Use this for initialization
  void Start () {
    audioSource = GetComponent<AudioSource>();
  }
    float fadeAlpha = 0;
    float interval;
    float time = 0;
  // Update is called once per frame
  void Update () {
    bool resString = PlayerPrefs.HasKey("SetName");
    if (Input.GetMouseButton(0)) {  //画面をタッチしたら
      if (resString) //すでに名前が登録されてるかどうか。
      {
        audioSource.PlayOneShot(next);
        FadeManager.Instance.LoadScene ("Main", 1.0f);
// 		while (time <= interval) {
// 			this.fadeAlpha = Mathf.Lerp (1f, 0f, time / interval);
// 			time += Time.deltaTime;
// 		}
      }else{
        audioSource.PlayOneShot(next);
        FadeManager.Instance.LoadScene ("Sign up", 1.0f);
      }
    }
    //Debug.Log(resString);
  }
}
