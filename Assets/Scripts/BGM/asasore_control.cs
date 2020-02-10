using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class asasore_control : MonoBehaviour
{
    public AudioClip asasore;
    public AudioClip happytime;
    private AudioSource source;
    private string beforeScene = "Start";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        source = GetComponent<AudioSource> ();
        source.clip = asasore;
        source.Play();
        
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    // Update is called once per frame
   void OnActiveSceneChanged ( Scene prevScene, Scene nextScene ) {
        //シーンがどう変わったかで判定

        if (beforeScene == "Start" && nextScene.name == "Main") {
            source.Stop();
            source.clip = happytime;
            source.Play();
        }
        if (beforeScene == "Start" && nextScene.name == "Sign Up") {
            source.Stop();
            source.clip = happytime;
            source.Play();
        }
         beforeScene = nextScene.name;
}
            

//         //アンサーからメインへ
//         if (beforeScene == "Answer" && nextScene.name == "Main") {
//             source.Stop ();
//             source.clip = asasore;    //流すクリップを切り替える
//             source.Play ();
//         }
//         //メニューからメインへ
//         if (beforeScene == "HostMaking" && nextScene.name == "Matching") {
//             source.Stop ();
//             source.clip = happytime;    //流すクリップを切り替える
//             source.Play ();
//         }
//         //メニューからメインへ
//         if (beforeScene == "GuestEnter" && nextScene.name == "Matching") {
//             source.Stop ();
//             source.clip = happytime;    //流すクリップを切り替える
//             source.Play ();
//         }
//         //メニューからメインへ
//         if (beforeScene == "HostFree" && nextScene.name == "Matching") {
//             source.Stop ();
//             source.clip = happytime;    //流すクリップを切り替える
//             source.Play ();
//         }
//         beforeScene = nextScene.name;
// }
}