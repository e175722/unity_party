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
        //プレイヤーネームのtext位置を取得
        Vector3 Ppos = PlayerName.transform.position;

        //photonViewオーナーの名前をテキスト表示
        PlayerName.text = photonView.Owner.NickName;

        //プレイヤーネームのtext位置を決定(入ってきた順に羅列されるように)
        PlayerName.transform.position = new Vector3(Ppos.x, Ppos.y - (photonView.Owner.ActorNumber)*50, Ppos.z );

        Debug.Log("プレイヤー名の座標" + PlayerName.transform.position);
        Debug.Log("点の座標 : " + Ppos);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
