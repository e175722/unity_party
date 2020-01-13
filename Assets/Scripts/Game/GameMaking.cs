using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaking : MonoBehaviour
{
    public InputField inputField;
    public Text QuesText;
    //各々の意見変数
    public static string idea;


    void Start()
    {
        //初期化
        idea = "入力されていません。";
    }

    public void InputText(){
    //テキストにinputFieldの内容を反映
        idea = inputField.text;
        QuesText.text = idea;
     }

    //ゲッター
    public static string getIdea(){
         return idea;
     }

    // Update is called once per frame
    void Update()
    {
    }
}
