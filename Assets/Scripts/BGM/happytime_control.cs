using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class happytime_control : MonoBehaviour
{
    public bool DontDestroyEnable = true;
    // Start is called before the first frame update
    void Start()
    {
        if(DontDestroyEnable){
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName == "Main") {
            DontDestroyEnable = false;
        }
    }
}
