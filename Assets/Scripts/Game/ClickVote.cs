using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickVote : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //投票ボタンが押された時
    public void OnClick (){
        string text = this.obj.transform.Find("Text").GetComponent<Text>().text;
        int number = 0;
        for (int i = 0; i < PlayerMgr.ansArray.Length; i++){
            if (PlayerMgr.ansArray[i] == text){
                number = i;
            }
        }
        switch (number) {
            case 0:
            Debug.Log("0番が押されました");
            vote.voteNum = 0;
            break;
            case 1:
            Debug.Log("1番が押されました");
            vote.voteNum = 1;
            break;
            case 2:
            Debug.Log("2番が押されました");
            vote.voteNum = 2;
            break;
            case 3:
            Debug.Log("3番が押されました");
            vote.voteNum = 3;
            break;
            default:
            break;
        }
    }
}
