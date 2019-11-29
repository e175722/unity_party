using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//追加する！
using UnityEngine.UI;
 
public class InputManager : MonoBehaviour {
 
  //オブジェクトと結びつける
  public InputField inputField;
  public Text text;
  public static string roomID;
  public static bool isGuest = false;
 
  void Start () {
    //Componentを扱えるようにする
             inputField = inputField.GetComponent<InputField> ();
              if (Application.loadedLevelName == "HostMaking") {
                  text = text.GetComponent<Text> ();
                }
      if (Application.loadedLevelName == "GuestEnter") {
            isGuest = true;
        }
        Debug.Log(isGuest);
    }
 
    public void InputText(){
                //テキストにinputFieldの内容を反映
        if (Application.loadedLevelName == "HostMaking") {
         text.text = inputField.text;
         }
        roomID = inputField.text;
     }
     
     public static string getRoomID(){
         return roomID;
     }
     
      public static bool getIsguest(){
         return isGuest;
     }
 
}