using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class PlayerMgr : MonoBehaviour, Photon.Pun.IPunObservable
{

    public Text PlayerName;
    public GameObject nameTextObj;
    public GameObject AnsTextObj;
    public GameObject playerObj;
    public GameObject buttonObj; //ボタンのオブジェクト追加
    public PhotonView photonView;
    public Text Answer;
    public static bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーネームのtext位置を取得
        Vector3 Ppos = PlayerName.transform.position;
        Vector3 Ppos2 = Answer.transform.position;
        Vector3 Ppos3 = buttonObj.transform.position;

        //photonViewオーナーの名前をテキスト表示
        PlayerName.text = photonView.Owner.NickName;

        //プレイヤーネームのtext位置を決定(入ってきた順に羅列されるように)
        PlayerName.transform.position = new Vector3(Ppos.x, Ppos.y - (photonView.Owner.ActorNumber)*50, Ppos.z );
        Answer.transform.position = new Vector3(Ppos.x + 200, Ppos2.y - (photonView.Owner.ActorNumber)*50, Ppos2.z );
        buttonObj.transform.position = new Vector3(Ppos.x, Ppos3.y + 500 - (photonView.Owner.ActorNumber)*50, Ppos3.z );

        Debug.Log("プレイヤー名の座標" + PlayerName.transform.position);
        Debug.Log("点の座標 : " + Ppos);

        //ネットワークオブジェクトを消去しない設定
        DontDestroyOnLoad(this);


    }

    // Update is called once per frame
    void Update()
    {
        //シーンによってネットワークオブジェクトをアクティブ化
        if (Application.loadedLevelName == "Matching" || Application.loadedLevelName == "Talking") {
            nameTextObj.SetActive (true);
        }else{
            nameTextObj.SetActive (false);
        }

        //シーンによってネットワークオブジェクトをアクティブ化
        if (Application.loadedLevelName == "Talking") {
            AnsTextObj.SetActive (true);
        }else{
            AnsTextObj.SetActive (false);
        }

        //ボタンオブジェクトのアクティブ化
        if (Application.loadedLevelName == "Voting") {
            buttonObj.SetActive (true);
        }else{
            buttonObj.SetActive (false);
        }

        //text表示
        if( photonView.IsMine == true ){
            Answer.text = GameMaking.getIdea();
            //それぞれのボタンのラベルに答えを入れる
            buttonObj.transform.Find("Text").GetComponent<Text>().text = GameMaking.getIdea();
        }

        //完了ボタンを押したなら画面遷移
        if(isDone == true){
            Application.LoadLevel ("Question");

            isDone = false;
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            // 自身側が生成したオブジェクトの場合は
            // 色相値と移動中フラグのデータを送信する
            stream.SendNext(Answer.text);
            stream.SendNext(isDone);
            stream.SendNext(buttonObj.transform.Find("Text").GetComponent<Text>().text);
            Debug.Log("Send_isDone : " + isDone);
        } else {
            // 他プレイヤー側が生成したオブジェクトの場合は
            // 受信したデータから色相値と移動中フラグを更新する
            Answer.text = Convert.ToString(stream.ReceiveNext());
            isDone = Convert.ToBoolean(stream.ReceiveNext());
            buttonObj.transform.Find("Text").GetComponent<Text>().text = Convert.ToString(stream.ReceiveNext());
            Debug.Log("Receive_isDone : " + isDone);

        }
    }

}
