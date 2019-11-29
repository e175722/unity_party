using UnityEngine;
using System.Collections;
 
public class Setting : MonoBehaviour {
 
    public void  NextScene(){
        //今いるシーンがTitleという名前であれば、Quizという名前のシーンに移動する
        if (Application.loadedLevelName == "Main") {
            Application.LoadLevel ("Setting");
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 7596ef7bf7eca599e1fcd65c86d31c392b771699
