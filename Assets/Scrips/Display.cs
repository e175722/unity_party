using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
	public Text targetText;
	string key = "SavedText";

	void Start()
	{
		//SaveName temp = new SaveName();
		targetText = GetComponent<Text>();
		//Txet username = temp.name;
		targetText.text = PlayerPrefs.GetString("SetName");
		bool resString = PlayerPrefs.HasKey("SetName");
		Debug.Log(resString);

		// string stringValue = "";
		// string temp = SaveName.name;
		// PlayerPrefs.SetString("StringKey",temp);
		// PlayerPrefs.Save();
		//string stringValue = PlayerPrefs.GetString("SetName");
		//Debug.Log(stringValue);

		//targetText.text = PlayerPrefs.GetString(SaveName.name);


		// string fileName = "UserName";
		// string path = Application.persistentDataPath + "/" + fileName + ".xml";
		//
		// var serializer = new XmlSerializer(typeof(List<PostItData>));
		// var stream = new FileStream(path, FileMode.Open);
		//
		// List<SaveData> xmlDataList = serializer.Deserialize(stream) as List<SaveName>;
		// if (xmlDataList == null)
		// {
		// 	Debug.Log("xmlDataList is null");
		// 	return;
		// }
		//
		// foreach (SaveData data in xmlDataList)
		// {
		// 	Debug.Log("This scene is Main. UserName is " + data);
		// }
		//
		// Debug.Log(UnityEngine.Application.persistentDataPath);
	}

	void Update()
	{

	}

	// public void SaveText()
	// {
	// 	string temp = SaveName.name;
	// 	PlayerPrefs.SetString(key, temp);
	// 	PlayerPrefs.Save();
	// }

	//void SetName()
	//{
	//	this.targetText = this.GetComponent<Text>();
	//	this.targetText.text = SaveName.name.ToString();
	//	Debug.Log("This Scene is Main. Name is " + SaveName.name);
	//}
}
