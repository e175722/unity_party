using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class ButtonMgr : MonoBehaviour
{   
    public GameObject DoneButton;
    public static bool isDone = false;
    
    // Start is called before the first frame update
    void Start()
    {
         if(InputManager.getIsguest() == true){
             DoneButton.SetActive (false);
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void isDoneChange(){
        isDone = true;
        Debug.Log("完了がクリックされました。isDone = " + isDone);
    }
    
}
