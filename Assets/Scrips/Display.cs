using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
	private Text targetText;

	void Start()
	{
		targetText = GetComponent<Text>();
		targetText.text = SaveName.name;
	}

	void Update()
	{
	
	}

	//void SetName()
	//{
	//	this.targetText = this.GetComponent<Text>();
	//	this.targetText.text = SaveName.name.ToString();
	//	Debug.Log("This Scene is Main. Name is " + SaveName.name);
	//}
}
