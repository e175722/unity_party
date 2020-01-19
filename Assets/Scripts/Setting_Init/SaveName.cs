using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
・Sign UpシーンのInitNameDecide
・Sign UpシーンのDeleteName
にアタッチされている
*/
public class SaveName : MonoBehaviour
{


	/*
	このスクリプトはChangeNameに統合したい。保留
	*/





	//InputFieldを格納する変数
	InputField inputField;
	public static string name = "";


	// Start is called before the first frame update
	void Start()
	{
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
	}

	public static string getName(){
		return name;
	}

	public void DeleteName()
	{
		PlayerPrefs.DeleteKey("SetName");
		Debug.Log("名前を削除しました");
	}
}
