using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
ChangeNameシーンのButton_NameDicideにアタッチされている
*/
public class ChangeName : MonoBehaviour
{
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
    //以下2行で名前変更確認Popup表示
    GameObject obj = (GameObject)Resources.Load ("Popup_Check(OKCancelButton)");
    GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
  }
}
