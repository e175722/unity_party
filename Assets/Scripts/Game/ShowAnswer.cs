using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;


/*
AnswerシーンのText_Answerにアタッチされている
*/
public class ShowAnswer : MonoBehaviour
{

  // Start is called before the first frame update
  void Start()
  {
    this.GetComponent<Text>().text = vote.result;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
