using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public static string name;
    public InputField inputField;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        text = text.GetComponent<Text>();
        text.text = inputField.text;
        Debug.Log(text.text);
    }
    // Update is called once per frame
//     public void InputText()
//     {
//         text.text = inputField.text;
//         name = inputField.text;
//     }
//     
//     public static string GetName(){
//         return name;   
//     }
}
