using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
	//InputFieldを格納する変数
	InputField inputField;
	public static string name = "";

	// string key = "SavedText";
	public Text text;

    // Start is called before the first frame update
    void Start()
    {
    	inputField = GameObject.Find("InputField").GetComponent<InputField>();
			text = GetComponent<Text>();
			//Txet username = temp.name;
			text.text = SaveName.name;
			//text.text = PlayerPrefs.GetString(key,"");
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void GetName()
	{
		name = inputField.text;
		PlayerPrefs.SetString("SetName", name);
		PlayerPrefs.Save();
		Debug.Log("Your Name is " + name);
		Debug.Log("名前が登録されました");
		//Debug.Log("GetName()");
	}

	public void SaveText()
	{
		// name = inputField.text;
		// PlayerPrefs.SetString("SetName", name);
		// PlayerPrefs.Save();
		// //保存キー「SavedText」で入力文字を保存
		// PlayerPrefs.SetString(key, name);
		// PlayerPrefs.Save();
		// text.text = name;
		// inputField.text = "";
	}

	public void DeleteName()
	{
		PlayerPrefs.DeleteKey("SetName");
		Debug.Log("名前を削除しました");
	}
}
