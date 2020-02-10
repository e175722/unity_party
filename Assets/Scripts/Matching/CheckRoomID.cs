using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
MatchingシーンのMain Cameraにアタッチされている
*/
public class CheckRoomID : MonoBehaviour
{
  /*

   */

  public Text text;
  // Start is called before the first frame update
  void Start()
  {
    string ID = InputManager.getRoomID();
    Debug.Log("CheckRoomIDが呼ばれたよ");
    string ID_f = MatchingFree.getRoomID_F();
    Debug.Log(MatchingFree.getRoomID_F());
    text.text = ID_f;
    // text.text = ID + ID_f;
  }

  // Update is called once per frame
  void Update()
  {
  }
}
