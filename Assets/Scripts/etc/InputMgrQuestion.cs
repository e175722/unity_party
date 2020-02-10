using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputMgrQuestion : MonoBehaviour
{

  InputField inputField;  //自分自身を入れる変数
  public Text Checktext;
    // Start is called before the first frame update
    void Start()
    {
      inputField = this.GetComponent<InputField> (); //自分自身を入れておく
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InputText(){
      //テキストにinputFieldの内容を反映
      if (Application.loadedLevelName == "Question") { //GuestEnterシーンではCheckTextに入れる変数が存在しないため、これがないとエラー吐く
        Checktext.text = inputField.text;
      }
    }
}
