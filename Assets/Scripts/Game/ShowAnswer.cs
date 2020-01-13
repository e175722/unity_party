using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class ShowAnswer : MonoBehaviour
{
    public Text AnswerText;

    // Start is called before the first frame update
    void Start()
    {
        AnswerText.text = vote.result;
        Debug.Log("問題のアンサー名 : " + vote.result);
        Debug.Log("最大投票数 : " + vote.counter.Max());
        //Debug.Log("あんさー : " + Convert.ToString(PlayerMgr.ansArray[vote.counter.Max()]));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
