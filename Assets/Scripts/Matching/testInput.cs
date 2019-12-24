using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testInput : MonoBehaviour
{
    public InputField inputField;
    public static string testAns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

public void InputText(){
                //テキストにinputFieldの内容を反映         
        testAns = inputField.text;
        Debug.Log(testAns);
     }
     
public static string getAns(){
         return testAns;
     }
     
    // Update is called once per frame
    void Update()
    {
        
    }
}
