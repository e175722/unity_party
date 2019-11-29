using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goGust : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  NextScene(string resultMessage){
        //今いるシーンがTitleという名前であれば、Quizという名前のシーンに移動する
            Application.LoadLevel ("GuestEnter");
    }
}
