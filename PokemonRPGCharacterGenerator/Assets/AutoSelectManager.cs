using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class AutoSelectManager : MonoBehaviour 
{
//	public int TreeSlot;
	//public static bool CanSelect = false;
//	public TreeSlot = TreeManager.options;

	public int [] TreeRolls = new int[4];
	//options [intrandnumber1].isOn = true;
	public TreeManager [] ActiveRolls = new TreeManager[4];
	List <int> TempRolls = new List <int> ();
//	static List <int> IRN1List = new List <int> ();



	public void AutoSelect ()
	{

		for (int i = 0; i < 4; i++) 
		{
////			ActiveRolls[i].RollOnTree ();
	TreeRolls [i] = ActiveRolls[i].intrandnumber1;
////			TreeRolls [i] = IRN1List.ElementAt (i);
					}


		for (int i = 0; i < 4; i++) 
		{
			if (TreeRolls [i] == 0) 
			{
				TempRolls.Add (i);
				Debug.Log ("Fuck");

			}
		}



		for (int i = 0; i < 4; i++) 
		{
			if (TreeRolls [i] == 7) 
			{
				TempRolls.Add (i);
				Debug.Log ("Add 7s...");

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
				Debug.Log ("Add 8s...");
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
				Debug.Log ("Add 6s...");
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
				Debug.Log ("Add 9s...");
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
				Debug.Log ("Add 10s...");
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
			if (TreeRolls [i] > 10) 
			{
				TempRolls.Add (i);
				Debug.Log ("Add 10+s...");
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


	}
}
