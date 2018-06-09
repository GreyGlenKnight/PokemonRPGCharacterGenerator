using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour 
{
		public Texture2D PokeballCursor;
		public CursorMode cursorMode = CursorMode.Auto;
		public Vector2 hotSpot = Vector2.zero;

		void Start()
		{
			Cursor.SetCursor(PokeballCursor, hotSpot, cursorMode);
		//Debug.Log ("Mouse Detected");
		}

	}

