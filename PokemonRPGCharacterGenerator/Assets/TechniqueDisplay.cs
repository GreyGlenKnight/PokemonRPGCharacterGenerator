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
	public Image _StatImage;
	public Image _TypeImage;


	public List <Sprite> _ElementType = new List <Sprite> ();
	public List <Sprite> _StatsToUse = new List <Sprite> ();

	public Text _Header;
	public Text _Description;
	public Text _BaseDamage;
	public Text _BaseAccuracy;
	public Text _BaseStrain;
	public Text _Range;


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
		GetElementTypeImages (CurrentTechnique.Types);
		_StatImage.sprite = _StatsToUse [0];
		_TypeImage.sprite = _ElementType [0];

		if (ToDisplay.Types.Count == 0) 
		{
			_BackGround.color = TypeColors.NothingColor;
		} 
		else 
		{
			Color TempColor = TypeColors.GetColorForType (CurrentTechnique.Types [0]);
//			int Temp = (int) CurrentTechnique.Types [0];
//			Color TempColor = TypeColors.TypeColorList [Temp];
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
			_StatsToUse.Add (TypeColors.GetSpriteForStat(ToReturn [i]));
		}
	}

	public void GetElementTypeImages (List <ElementTypes> ToReturn) 
	{
		if (ToReturn == null) {return;}

		for (int i = 0; i < ToReturn.Count; i++) 
		{
			_StatsToUse.Add (TypeColors.GetSpriteForType(ToReturn [i]));
		}
	}

	public void ExpandMoveView ()
	{
		this.gameObject.SetActive (true);
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