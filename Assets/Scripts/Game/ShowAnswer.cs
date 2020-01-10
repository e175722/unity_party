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
        //AnswerText.text = Convert.ToString(PlayerMgr.ansArray[vote.counter.Max()]);
        AnswerText.text = vote.result;
        Debug.Log("あんさー2 : " + vote.result);
        Debug.Log("あんさー : " + vote.counter.Max());
        Debug.Log("あんさー : " + Convert.ToString(PlayerMgr.ansArray[vote.counter.Max()]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
