﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
	public float outlineWidth = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		Player now = GameController.instance.nowPlayer;

		if (now == GameController.instance.player1)
		{
			GameController.instance.player1.GetComponent<Renderer>().sharedMaterial.SetFloat("_OutlineWidth", outlineWidth);
			GameController.instance.player2.GetComponent<Renderer>().sharedMaterial.SetFloat("_OutlineWidth", 1.0f);
		}
		else
		{
			GameController.instance.player2.GetComponent<Renderer>().sharedMaterial.SetFloat("_OutlineWidth", outlineWidth);
			GameController.instance.player1.GetComponent<Renderer>().sharedMaterial.SetFloat("_OutlineWidth", 1.0f);
		}


		
	}
}
