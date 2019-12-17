using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour
{
    // Start is called before the first frame update
    InputField changeName;

    void Start()
    {
      changeName = GameObject.Find("InputField").GetComponent<InputField>();
      // text = GetComponent<Text>();
      // name = changedName.text;
      // PlayerPrefs.SetString("SetName", name);
  		// PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change()
    {
      PlayerPrefs.DeleteKey("SetName");
      name = changeName.text;
      PlayerPrefs.SetString("SetName", name);
  		PlayerPrefs.Save();
      Debug.Log("名前の変更が行われました");
      Debug.Log("変更後 " + name);
    }
}
