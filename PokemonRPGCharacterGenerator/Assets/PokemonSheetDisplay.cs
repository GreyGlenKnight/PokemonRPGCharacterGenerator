using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class PokemonSheetDisplay : MonoBehaviour 
{
	public int Level;
	public string _HeldItem;
	public int BaseMaturity;
	public int CurrentMaturity;
	public int MaturityBonus;
	public Image Portrait;
	public float Rate;



	public void SetPortrait ()
	{
		Debug.Log ("Set Portrait");
		if (GameManager.instance.CurrentPokemon.IsShiny == true) 
		{
			Debug.Log ("Shiny Portrait");
		}
	}


}
