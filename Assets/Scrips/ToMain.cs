﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void NextScene()
	{
		if (Application.loadedLevelName == "Sign Up")
		{
			Application.LoadLevel("Main");
		}
	}
}
