﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut5 : SampleMap
{
	public override void init()
	{
		base.init();
		mapsizeH = 4;
		mapsizeW = 7;
		parfait = false;
		map = new int[][] {
		new int[] { 1, 1, 1, 1, 1, 1, 1},
		new int[] { 1, 2, 1, 1, 1, 2, 1},
		new int[] { 1, 0, 0, 0, 0, 0, 1},
		new int[] { 1, 1, 1, 1, 1, 1, 1}
	

		};

		startPositionA = new Vector3(1, -9, 1);
		
		startPositionB = new Vector3(1, -8, 2);
		startUpstairB = true;
	}
}
