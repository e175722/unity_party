using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaking : MonoBehaviour
{
    public InputField inputField;
    public Text testText;
    public Text voteText;
    //各々の意見変数
    public static string idea;


    void Start()
    {

    }

    public void InputText(){
    //テキストにinputFieldの内容を反映
        idea = inputField.text;
        testText.text = idea;
        //Debug.Log(idea);
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
