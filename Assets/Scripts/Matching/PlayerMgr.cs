using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class PlayerMgr : MonoBehaviour, Photon.Pun.IPunObservable
{

    public Text PlayerName;
    public GameObject playerObj;
    public PhotonView photonView;
    public Text Answer;
    
    private float timeElapsed = 0;
    public float timeOut = 1;
    
    // Start is called before the first frame update
    void Start()
    {    
        //プレイヤーネームのtext位置を取得
        Vector3 Ppos = PlayerName.transform.position;
        Vector3 Ppos2 = Answer.transform.position;
        
        //photonViewオーナーの名前をテキスト表示
        PlayerName.text = photonView.Owner.NickName;
        
        if( photonView.IsMine == true ){
			Answer.text = UnityEngine.Random.Range(1000,9999).ToString();
		}
     
        //プレイヤーネームのtext位置を決定(入ってきた順に羅列されるように)
        PlayerName.transform.position = new Vector3(Ppos.x, Ppos.y - (photonView.Owner.ActorNumber)*50, Ppos.z ); 
        Answer.transform.position = new Vector3(Ppos.x + 200, Ppos2.y - (photonView.Owner.ActorNumber)*50, Ppos2.z );        
    
        Debug.Log("プレイヤー名の座標" + PlayerName.transform.position);
        Debug.Log("点の座標 : " + Ppos);
    }
    
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            // 自身側が生成したオブジェクトの場合は
            // 色相値と移動中フラグのデータを送信する
            stream.SendNext(Answer.text);
        } else {
            // 他プレイヤー側が生成したオブジェクトの場合は
            // 受信したデータから色相値と移動中フラグを更新する
            Answer.text = Convert.ToString(stream.ReceiveNext());

        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed >= timeOut) {
            if( photonView.IsMine == true ){
			Answer.text = UnityEngine.Random.Range(1000,9999).ToString();
		}

            timeElapsed = 0.0f;
        }
    }
}
