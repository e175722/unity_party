using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateQuestion : MonoBehaviour
{
 public Text text;
 private static string hiragana = "あいうえおかきくけこさしすせそたちつてとなにねのはひふへほまみむめもらりるれろやゆよわ";
 private static string[] odai = new string[7] {"有名人", "夏の果物", "冬の果物", "夏の曲", "冬の曲", "今話題の人", "黒歴史"};
 private static string sentense;
 
    // Start is called before the first frame update
    void Start()
    {   
        if (Application.loadedLevelName == "Question") {
            sentense = "「" + hiragana[Random.Range(0, 42)] + "」で始まる" + odai[Random.Range(0, 6)] + "といえば";
        }
        
        text.text = sentense;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
