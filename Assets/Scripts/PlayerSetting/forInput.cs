using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/*
・Sign UpシーンのInputField_InputName
・ChangeNameシーンのInputField_InputName
にアタッチされている
*/
public class forInput : MonoBehaviour
{
  InputField inputField; //自分自身を入れる変数
  public Text CheckText;  //名前チェック用

  void Start()
  {
    inputField = this.GetComponent<InputField> ();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void InputText(){  //確認用TextにInputするだけ
    CheckText.text = inputField.text;
  }
}
