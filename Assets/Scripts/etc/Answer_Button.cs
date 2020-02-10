using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer_Button : MonoBehaviour
{

  public static bool isPopupFlag = false; //Answerシーンのポップアップを出すのに使う.
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool getIsPopupFlag(){ //ボタンを押したらisDoneをtrueにする
      return isPopupFlag;
    }
}
