using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forInput : MonoBehaviour
{
    public InputField inputField;
    public Text text;

    void Start()
    {
      inputField = inputField.GetComponent<InputField> ();
      if (Application.loadedLevelName == "Sign Up") {
            text = text.GetComponent<Text> ();
      }else if(Application.loadedLevelName == "ChangeName"){
            text = text.GetComponent<Text> ();
      }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InputText(){
        if (Application.loadedLevelName == "Sign Up") {
         text.text = inputField.text;
        }else if(Application.loadedLevelName == "ChangeName") {
         text.text = inputField.text;
         }
     }
}
