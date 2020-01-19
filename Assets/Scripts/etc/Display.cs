using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
MainシーンのText_UserNameにアタッチされている
*/
public class Display : MonoBehaviour
{
	string key = "SavedText"; //??????
	void Start()
	{

		this.GetComponent<Text>().text = PlayerPrefs.GetString("SetName"); //Main画面で表示している名前を取得
		bool resString = PlayerPrefs.HasKey("SetName"); //??????
		Debug.Log("aaaaaaa");
	}

	void Update()
	{
	}
}
