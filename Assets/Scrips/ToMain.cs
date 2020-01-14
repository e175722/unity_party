using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ToMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	public void NextScene()
	{
		if (Application.loadedLevelName == "Sign Up"){
			Application.LoadLevel("Main");
        }else if(Application.loadedLevelName == "ChangeName"){
            Application.LoadLevel("Main");
        }else if(Application.loadedLevelName == "Answer"){
            Application.LoadLevel("Main");
            PhotonNetwork.LeaveRoom (); //部屋を出る
            PhotonNetwork.Disconnect(); //photonとの接続を切る
        }
	}
}
