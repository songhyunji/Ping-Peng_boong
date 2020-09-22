﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
	public GameObject groundBlock; // prefab
	public int adjustX;//not use this var
	public int adjustY;//not use this var

	public int mapsizeH = 15; //const map size
	public int mapsizeW = 10;
	public int[][] map = new int[][] {
		new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		new int[] { 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1 },
		new int[] { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1 },
		new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
		new int[] { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1 },
		new int[] { 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1 },
		new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		new int[] { 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1 },
		new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		new int[] { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1 },
		new int[] { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1 },
		new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		new int[] { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1 },
		new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
		new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
	};

	// Start is called before the first frame update
    
	void Start()
    {
        //j is width ,, i is height // vector.y is depth (fix -10f)
		for (int i = 1; i <= mapsizeH; i++)
		{
			for (int j = 1; j <= mapsizeW; j++)
			{
                //instantiate ground object at all of area . parent is spawnGround object
				GameObject ground = Instantiate(groundBlock, new Vector3(j - 5, -10, -i + 5), Quaternion.identity) as GameObject;
				ground.transform.parent = gameObject.transform;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}