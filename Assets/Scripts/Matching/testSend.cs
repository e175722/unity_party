using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testSend : MonoBehaviour
{
    public Text text;    
    // Start is called before the first frame update
    void Start()
    {
        string ID = InputManager.getRoomID();
        
        text.text = ID; 
    }

    // Update is called once per frame
    void Update()
    {
    }
}
