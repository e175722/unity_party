using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
	//InputFieldを格納する変数
	InputField inputField;
	public static string name = "";

    // Start is called before the first frame update
    void Start()
    {
    	inputField = GameObject.Find("InputField").GetComponent<InputField>();	
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void GetName()
	{
		name = inputField.text;
		Debug.Log("Your Name is " + name);
	}
}
