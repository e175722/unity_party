using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertText : MonoBehaviour
{
  public float timeOut = 0.2f;
  private float timeElapsed;
  // Start is called before the first frame update
  void Start()
  {
    this.GetComponent<Text>().color = new Color (0, 0, 0, 0);
    if (Application.loadedLevelName == "HostMaking") {
      this.GetComponent<Text>().text = "このルームIDはすでに使用されています";
    }
    else if (Application.loadedLevelName == "GuestEnter") {
      this.GetComponent<Text>().text = "このルームIDのルームは存在しません";
    }
    else if (Application.loadedLevelName == "ChangeName") {
      this.GetComponent<Text>().text = "名前が変更されました";
    }
    else if (Application.loadedLevelName == "Sign Up"){
      this.GetComponent<Text>().text = "名前を決定しました";
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
