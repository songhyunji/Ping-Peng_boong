﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing3 : SampleMap
{
	public override void init()
	{
		base.init();
		mapsizeH = 5;
		mapsizeW = 6;
		parfait = false;
		map = new int[,] {
			{ 1, 1, 1, 1, 1, 1},
			{ 1, 0, 22, 2, 1, 1},
			{ 1, 0, 0, 0, 0, 1},
			{ 1, 0, 0, 2, 2, 1},
			{ 1, 1, 1, 1, 1, 1}
		};

		startPositionA = new Vector3(1, -9, 1);
		startPositionB = new Vector3(1, -9, 2);
	}
}
