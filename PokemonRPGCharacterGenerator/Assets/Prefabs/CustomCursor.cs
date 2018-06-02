using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour 
{
		public Texture2D BallCursor;
		public CursorMode cursorMode = CursorMode.Auto;
		public Vector2 hotSpot = Vector2.zero;
//		public PokeBallTypes CurrentBallType;

//	public Texture2D GetBallCursor
//	{Make the texture array get the current pokemon's value.}

		void Start()
		{
		
			Cursor.SetCursor(BallCursor, hotSpot, cursorMode);
		//Debug.Log ("Mouse Detected");
		}

	}

