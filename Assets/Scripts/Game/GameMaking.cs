using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
QuestionシーンのButton_AnswerDicideにアタッチしている
*/
public class GameMaking : MonoBehaviour
{
  public InputField inputField; //ユーザーの回答を入れているInputField
  public Text CheckText; //回答確認用
  //各々の意見変数
  public static string idea; //ユーザーの回答を保存しておく変数


  void Start()
  {
    //初期化
    idea = "入力されていません。";
  }

  public void InputText(){
    //テキストにinputFieldの内容を反映
    idea = inputField.text;
    CheckText.text = idea;
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
