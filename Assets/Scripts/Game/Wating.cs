using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Linq;
using System;

public class Wating : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {
        if (propertiesThatChanged.TryGetValue("voteNum", out object voteNumObj)) {
            int num = (int)voteNumObj;
            vote.counter[num] = vote.counter[num] + 1;
            int intMax = vote.counter.Max();

            Debug.Log("-------Wateシーンにて-------");
            Debug.Log("-- counter start --");
            //counterの中身を全て確認
            foreach (int element in vote.counter){
                Debug.Log(element);
            }
            Debug.Log("-- counter end --");

            int index2 = 0;
            for (int i = 0; i < vote.counter.Length; i++){
                if (vote.counter[i] == intMax){
                    index2 = i;
                }
            }
            vote.result = PlayerMgr.ansArray[index2];
        }
        if(propertiesThatChanged.TryGetValue("voteSum", out object voteSumObj)) {
            Debug.Log("voteSumの値_w : "  + (int)voteSumObj);
            vote.voteSum = (int)voteSumObj;
            if(vote.voteSum == PhotonNetwork.CurrentRoom.PlayerCount){
                Application.LoadLevel("Answer");
            }
        }
    }

}
