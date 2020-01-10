using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;
using System;

public class NextScene : MonoBehaviourPunCallbacks
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
     public async void  Next(string resultMessage){
        if (Application.loadedLevelName == "HostMaking") {
            Application.LoadLevel ("Matching");
        }else if(Application.loadedLevelName == "GuestEnter") {
            Application.LoadLevel ("Matching");
        //下記に関してはルーム作成者のみ画面遷移可能
        }else if(Application.loadedLevelName == "Matching") {
            Application.LoadLevel ("Question");
        }else if(Application.loadedLevelName == "Question") {
            Application.LoadLevel ("Talking");
        }else if(Application.loadedLevelName == "Talking") {
            Application.LoadLevel ("Voting");
        }else if(Application.loadedLevelName == "Voting") {
            //WaitForSeconds(5);
            await Task.Delay(2000);
            Application.LoadLevel ("Wait");
        }else if(Application.loadedLevelName == "Answer") {
            Application.LoadLevel ("Question");
        }
    }

}

