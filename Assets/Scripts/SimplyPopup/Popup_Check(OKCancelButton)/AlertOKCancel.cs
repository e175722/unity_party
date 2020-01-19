using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AlertOKCancel : MonoBehaviour
{

  public float timeOut = 0.1f;
  private float timeElapsed;
  GameObject objGet;
  // Start is called before the first frame update
  void Start()
  {
    this.GetComponent<Text>().color = new Color (0, 0, 0, 0);
    if (Application.loadedLevelName == "ChangeName"){
      objGet = GameObject.Find("InputField_InputName");
      string name = objGet.transform.GetChild(2).gameObject.GetComponent<Text>().text;
      this.GetComponent<Text>().text = "名前を " + name + " に変更してもよろしいですか？";
    }
    else if(Application.loadedLevelName == "Sign Up"){
      objGet = GameObject.Find("InputField_InputName");
      string name = objGet.transform.GetChild(2).gameObject.GetComponent<Text>().text;
      this.GetComponent<Text>().text = "名前を " + name + " で決定してもよろしいですか？";
    }
    else if(Application.loadedLevelName == "Matching"){
      this.GetComponent<Text>().text = "このメンバーで始めてもよろしいですか？";
    }
    else if(Application.loadedLevelName == "Question"){
      objGet = GameObject.Find("InputField_InputName");
      string answer = objGet.transform.GetChild(2).gameObject.GetComponent<Text>().text;
      this.GetComponent<Text>().text = "回答は " + answer + " でよろしいですか？";
    }
  }

  // Update is called once per frame
  void Update()
  {
    timeElapsed += Time.deltaTime;

    if(timeElapsed >= timeOut) {
      this.gameObject.GetComponent<Text>().color = Color.black;
    }
  }
}
