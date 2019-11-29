using UnityEngine;
using System.Collections;
 
public class Participant : MonoBehaviour {
 
    public void  NextScene(){
        //今いるシーンがTitleという名前であれば、Quizという名前のシーンに移動する
        if (Application.loadedLevelName == "Private") {
<<<<<<< HEAD
            Application.LoadLevel ("participant");
=======
            Application.LoadLevel ("GuestEnter");
>>>>>>> 7596ef7bf7eca599e1fcd65c86d31c392b771699
        }
    }
}