using UnityEngine;
using System.Collections;
 
public class Participant : MonoBehaviour {
 
    public void  NextScene(){
        //今いるシーンがTitleという名前であれば、Quizという名前のシーンに移動する
        if (Application.loadedLevelName == "Private") {
            Application.LoadLevel ("participant");
        }
    }
}