using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class PlayerMgr : MonoBehaviour, Photon.Pun.IPunObservable
{

    public Text PlayerName;
    public static string PlayerString;
    public GameObject nameTextObj;
    public GameObject AnsTextObj;
    public GameObject playerObj;
    public GameObject buttonObj; //ボタンのオブジェクト追加
    public PhotonView photonView;
    public Text Answer;
    public bool isDone_PlayerMgr = false;
    public static string buttonLabel;
    public string sign;
    public static string[] ansArray = new string[4];

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーネームのtext位置を取得
        Vector3 Ppos = PlayerName.transform.position;
        Vector3 Ppos2 = Answer.transform.position;
        Vector3 Ppos3 = buttonObj.transform.position;

        //photonViewオーナーの名前をテキスト表示
        PlayerName.text = photonView.Owner.NickName;
        PlayerString = PlayerName.text;

        //プレイヤーネームのtext位置を決定(入ってきた順に羅列されるように)
        PlayerName.transform.position = new Vector3(Ppos.x, Ppos.y - (photonView.Owner.ActorNumber)*50, Ppos.z );
        Answer.transform.position = new Vector3(Ppos.x + 200, Ppos2.y - (photonView.Owner.ActorNumber)*50, Ppos2.z );
        buttonObj.transform.position = new Vector3(Ppos.x, Ppos3.y + 500 - (photonView.Owner.ActorNumber)*50, Ppos3.z );

        sign = Convert.ToString(photonView.Owner.ActorNumber);
        
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
            if(GameMaking.getIdea() != null){
                buttonObj.transform.Find("Text").GetComponent<Text>().text = GameMaking.getIdea();
                sign = Convert.ToString(photonView.Owner.ActorNumber) + GameMaking.getIdea();
                ansArray[photonView.Owner.ActorNumber-1] = GameMaking.getIdea();
          }
        }
        
        //完了ボタンを押したならtrueを更新
        isDone_PlayerMgr = ButtonMgr.isDone;
        
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            // 自身側が生成したオブジェクトの場合は
            // 色相値と移動中フラグのデータを送信する
            stream.SendNext(Answer.text);
            stream.SendNext(isDone_PlayerMgr);
            stream.SendNext(buttonObj.transform.Find("Text").GetComponent<Text>().text);
            stream.SendNext(sign);
            ButtonMgr.isDone = false;
        }else {
            // 他プレイヤー側が生成したオブジェクトの場合は
            // 受信したデータから色相値と移動中フラグを更新する
            Answer.text = Convert.ToString(stream.ReceiveNext());
            isDone_PlayerMgr = Convert.ToBoolean(stream.ReceiveNext());
            
            string value = Convert.ToString(stream.ReceiveNext());
            buttonObj.transform.Find("Text").GetComponent<Text>().text = value;
            string temp = Convert.ToString(stream.ReceiveNext());
            ansArray[Convert.ToInt32(temp.Substring(0,1))-1] = temp.Substring(1,temp.Length-1);

            if(isDone_PlayerMgr == true){
                if(Application.loadedLevelName == "Matching" || Application.loadedLevelName == "Answer"){
                    Application.LoadLevel ("Question");
                }else if(Application.loadedLevelName == "Talking"){
                    Application.LoadLevel ("Voting");
                }
                ButtonMgr.isDone = false;
            }
        }
    }

}
