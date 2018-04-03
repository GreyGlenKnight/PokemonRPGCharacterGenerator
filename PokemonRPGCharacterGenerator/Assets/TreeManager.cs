using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;



public class TreeManager : MonoBehaviour 
{
	
	List<int> Bonuses = new List<int> ();
	//I think we use new since bonuses will belong to treemanager.
	public Toggle[] options = new Toggle[12];
	//options are the selected bonuses for each tree per roll. Array of toggles.
	//We use an array for the toggles, but a list for the bonuses.
	public Text Tree_text;
	public bool CanSelect = false;
	//public bool CanChoose;
	public void RollOnTree()


	{
		RollTheList (Bonuses, options, Tree_text);
	}
	public void SelectMe()

	{
		Debug.Log ("SelectMe");

		//CanChoose =	GetComponent<GameManager>().CanChoose;


		//CanChoose =	gameObject.GetComponent<GameManager>().CanChoose;
//		Debug.Log ("Got CanChoose");
		if (! GameManager.instance.CanChoose)		
		{
			Debug.Log ("False");

			return;
		}
		//GameManager.GetComponent(bool CanChoose);
		//GameManager.CanChoose == false


			if (CanSelect == false) 
			{
				return;
			}
		Debug.Log ("Got CanSelect");

			int intrandnumber1 = Bonuses [0];
			Bonuses.RemoveAt (0);
			options [intrandnumber1].isOn = true;
			CanSelect = false;
//		gameObject.GetComponent<GameManager> ().CanChoose = false;	
			
			//CanChoose = false;


	}

	public void ResetBonuses ()

	{ 
		for (int i = 0; i < 12; i++) 
		{
			Bonuses.Add (i);
		}
		Bonuses.Shuffle ();

	}

	public void RollTheList (List <int> LBonus, Toggle[] Loptions, Text LText)

	{
		if (LBonus.Count == 0) {
			ResetBonuses (); 

		}



		Bonuses.Shuffle ();
		CanSelect = true;
		//Debug.Log ("Canselect");
		int intrandnumber1 = LBonus [0] +1;

		String randomnumber1 = intrandnumber1.ToString ();
		//.tostring represents an object as a string, in this case assigns the chosen int as a string.

		LText.text = randomnumber1;

	}
	public void Awake()
	{
		CanSelect = false;
		ResetBonuses ();
	}
}
