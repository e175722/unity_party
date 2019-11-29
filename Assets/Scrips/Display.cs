using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class Display : MonoBehaviour
{
    
//     GameObject test;
//     UnityScript script;
//     // Start is called before the first frame update
//     void Start()
//     {
//         test = GameObject.Find("Test");
//         script = test.GetComponent<UnityScript>();
//     }
// 
//     // Update is called once per frame
//     void Update()
//     {
//         string userName = script.name;
//         Debug.Log("ユーザー名は" + userName);
//     }

//         string temp;
//         void Start(){
//             temp = Test.GetName();
//             print(temp);
//         }
=======
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
>>>>>>> 7596ef7bf7eca599e1fcd65c86d31c392b771699
}
