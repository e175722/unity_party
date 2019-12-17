using UnityEngine;
using System.Collections;
 
public class Free: MonoBehaviour {
 
    public void  NextScene(){
        //今いるシーンがTitleという名前であれば、Quizという名前のシーンに移動する
        if (Application.loadedLevelName == "Room") {
            Application.LoadLevel ("Free");
        }
    }
}