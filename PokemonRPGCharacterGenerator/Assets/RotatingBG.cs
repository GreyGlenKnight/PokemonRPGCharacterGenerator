using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBG : MonoBehaviour 

	{
		public void Update()

		{
			transform.Rotate(Time.deltaTime, 0, .33f);

		}

	}