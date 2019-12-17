using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
//test
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void Back()
	{
		if(Application.loadedLevelName == "Sign Up"){
      Application.LoadLevel("Start");
    }else if(Application.loadedLevelName == "Setting"){
      Application.LoadLevel("Main");
    }else if(Application.loadedLevelName == "Room"){
      Application.LoadLevel("Main");
    }else if(Application.loadedLevelName == "Private"){
      Application.LoadLevel("Room");
    }else if(Application.loadedLevelName == "makeRoom_p"){
      Application.LoadLevel("Private");
    }else if(Application.loadedLevelName == "Participant"){
      Application.LoadLevel("Private");
    }else if(Application.loadedLevelName == "Free"){
      Application.LoadLevel("Room");
    }else if(Application.loadedLevelName == "ChangeName"){
      Application.LoadLevel("Setting");
    }
	}

}
