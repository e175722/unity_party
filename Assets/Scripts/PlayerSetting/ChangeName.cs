using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
ChangeNameシーンのButton_NameDicideにアタッチされている
*/
public class ChangeName : MonoBehaviour
{
    
public AudioClip next;
public AudioClip back;
AudioSource audioSource;
  // Start is called before the first frame update

  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
  }

  public void ChangeCheck()
  {
    audioSource = GetComponent<AudioSource>();
    //以下2行で名前変更確認Popup表示
    GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
    GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
  }
}
