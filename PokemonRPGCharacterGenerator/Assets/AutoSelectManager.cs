using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class AutoSelectManager : MonoBehaviour 
{

	public int [] TreeRolls = new int[4];
	public TreeManager [] ActiveRolls = new TreeManager[4];
	public bool TreeFull;
	public List <int> TempRolls = new List <int> ();
	public static List <int> DeadTrees = new List <int> ();
	public static List <int> ActiveTrees = new List <int> ();


	public void AutoSelect ()
	{
		
		for (int i = 0; i < TreeManager.IRN1List.Count; i++) 
		{
			if (TreeManager.IRN1List.Count > 0) 
			{
				if (TreeManager.IRN1List.ElementAt (i) > 0) 
				{
					TreeRolls [i] = TreeManager.IRN1List.ElementAt (i);
				}
			}
		}
		for (int i = 0; i < 4; i++) 
		{
			if (TreeRolls [i] == 7) 
			{
				TempRolls.Add (i);
//				Debug.Log ("Add 7s...");

			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].SelectMe ();
			TempRolls.Clear ();

			{
				return;}
		}
	


		for (int i = 0; i < 4; i++) 
		{
			if (TreeRolls [i] <= 5) 
			{
				TempRolls.Add (i);
			}
		}
		if (TempRolls.Count > 0) {
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].SelectMe ();
			TempRolls.Clear ();
			{
				return;}
		}

		for (int i = 0; i < 4; i++) {
			if (TreeRolls [i] == 8) {
				TempRolls.Add (i);
//				Debug.Log ("Add 8s...");
			}
		}
		if (TempRolls.Count > 0) {
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].SelectMe ();
			TempRolls.Clear ();
			{
				return;}
		}


		for (int i = 0; i < 4; i++) {
			if (TreeRolls [i] == 6) {
				TempRolls.Add (i);
//				Debug.Log ("Add 6s...");
			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].SelectMe ();
			TempRolls.Clear ();
			{
				return;}
		}


		for (int i = 0; i < 4; i++) {
			if (TreeRolls [i] == 9) {
				TempRolls.Add (i);
//				Debug.Log ("Add 9s...");
			}
		}
		if (TempRolls.Count > 0) {
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].SelectMe ();
			TempRolls.Clear ();
			{
				return;}
		}


		for (int i = 0; i < 4; i++) 
		{
			if (TreeRolls [i] == 10) 
			{
				TempRolls.Add (i);
//				Debug.Log ("Add 10s...");
			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].SelectMe ();
			TempRolls.Clear ();
			{
				return;}
		}


		for (int i = 0; i < 4; i++) 
		{
			if (TreeRolls [i] == 11) 
			{
				TempRolls.Add (i);
			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].SelectMe ();
			TempRolls.Clear ();
			{
				return;
			}
		}

		for (int i = 0; i < 4; i++) 
		{
			if (TreeRolls [i] == 12) 
				
			{
//				DeadTrees.Add (i);
				TempRolls.Add (i);
			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].SelectMe ();
			TempRolls.Clear ();
			{
				return;
			}
		}
			


//		for (int i = 0; i < 4; i++) 
//		{
//			if (TreeRolls [i] == 0) 
//			{


		}

	}

