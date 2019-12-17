using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class PlayerMgr : MonoBehaviour
{

    public Text PlayerName;
    public GameObject playerObj;
    public PhotonView photonView;
    
    // Start is called before the first frame update
    void Start()
    {    
        Vector3 Ppos = playerObj.transform.position;
        
        PlayerName.text = PhotonNetwork.LocalPlayer.NickName;
        
        if(photonView.IsMine == true){
            PlayerName.transform.position = new Vector3(Ppos.x+100, Ppos.y+400, Ppos.z);
        }
    
        Debug.Log("プレイヤー名の座標" + PlayerName.transform.position);
        Debug.Log("点の座標 : " + Ppos);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
