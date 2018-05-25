using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class TechniqueDisplay : MonoBehaviour 
{
	public Technique CurrentTechnique;

	public Image _BackGround;

	public List <Image> _ElementType = new List <Image> ();
	public List <Image> _StatsToUse = new List <Image> ();

	public Text _Header;
	public Text _Description;
	public Text _BaseDamage;
	public Text _BaseAccuracy;
	public Text _BaseStrain;
	public Text _Range;

	public static Image AttackSprite;
	public static Image DefenseSprite;
	public static Image SpecialAttackSprite;
	public static Image SpecialDefenseSprite;
	public static Image SpeedSprite;
	public static Image EnduranceSprite;

	public void ChangeTechniqueDisplay (Technique ToDisplay)
	{
		CurrentTechnique = ToDisplay;
		_Header.text = CurrentTechnique.Name;
		_Description.text = CurrentTechnique.Description;

		if (CurrentTechnique.BaseDamage != null) {
			_BaseDamage.text = CurrentTechnique.BaseDamage.ToString ();} 
		else {_BaseDamage.text = "";}

		if (CurrentTechnique.BaseAccuracy != null) {
			_BaseAccuracy.text = CurrentTechnique.BaseAccuracy.ToString ();} 
		else {_BaseAccuracy.text = "";}

		_BaseStrain.text = CurrentTechnique.BaseStrain.ToString();
		_Range.text = CurrentTechnique.DisplayRange;
//		_StatsToUse.Add ();	
		GetStatImages (CurrentTechnique.StatsUsed);

		if (ToDisplay.Types.Count == 0) 
		{
			_BackGround.color = TypeColors.NothingColor;
		} 
		else 
		{
			int Temp = (int) CurrentTechnique.Types [0];
			Color TempColor = TypeColors.TypeColorList [Temp];
			TempColor.a = 0.8f;
			_BackGround.color = TempColor;

			if (ToDisplay.Types.Count > 1) 
			{
				Debug.Log ("Add Support for multiple types");
			}
		}
	}

	public void GetStatImages (List <MyStat> ToReturn) 
	{
		if (ToReturn == null) {return;}

		for (int i = 0; i < ToReturn.Count; i++) 
		{
			if (ToReturn [i].GetType().Equals (typeof (AttackStat)))
			{
				_StatsToUse.Add (AttackSprite);
			}
			if (ToReturn [i].GetType().Equals (typeof (DefenseStat)))
			{
				_StatsToUse.Add (DefenseSprite);
			}
			if (ToReturn [i].GetType().Equals (typeof (SpecialAttackStat)))
			{
				_StatsToUse.Add (SpecialAttackSprite);
			}
			if (ToReturn [i].GetType ().Equals (typeof (SpecialDefenseStat)))
			{
				_StatsToUse.Add (SpecialDefenseSprite);
			}
			if (ToReturn [i].GetType ().Equals (typeof (SpeedStat))) 
			{
				_StatsToUse.Add (SpeedSprite);
			}
			if (ToReturn [i].GetType ().Equals (typeof ( EnduranceStat)))
			{
				_StatsToUse.Add (EnduranceSprite);
			}

		}
	}


//	public void ScaleToFitPanel (List <Image> ToDisplay)
//	{
//		if (ToDisplay == null) 
//		{
//			return;
//		}
//
//		if (ToDisplay.Count > 4) 
//		{
//			Debug.Log ("Error, over 4 things");
//		}
//		//Get the multiple images to display correctly, 0-4 per panel
//		//If it goes over, maybe add scrolling and use modulus to
//		//group in rows of 2
//		if (ToDisplay.Count == 1)
//		{
//			
//			return;
//		}
//
//		for (int i = 0; i < ToDisplay.Count; i++) 
//		{
//			if (i % 2 == 0) {} 
//			else {}
//		}
//	}

}