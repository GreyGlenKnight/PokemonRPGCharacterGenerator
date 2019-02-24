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

	public Image _TechSymbol;
	//This will be the artwork for the move

	public List <Sprite> _ElementType = new List <Sprite> ();
	public List <Sprite> _StatsToUse = new List <Sprite> ();

	public Text _TreeName;
	public Text _Header;
	public Text _Description;
	public Text _BaseDamage;
	public Text _BaseAccuracy;
	public Text _BaseStrain;
	public Text _Range;


	public void ChangeTechniqueDisplay (Technique ToDisplay)
	{
		CurrentTechnique = ToDisplay;

		if (ToDisplay == null) 
		{
			_TreeName.text = "";
			_BaseDamage.text = "";
			_BaseAccuracy.text = "";
			_Range.text = "";
			_BaseStrain.text = "";
			return;
		}

	_Header.text = CurrentTechnique.Name;
	_Description.text = CurrentTechnique.Description;
	_BaseDamage.text = CurrentTechnique.BaseDamage.ToString ();
	_BaseAccuracy.text = CurrentTechnique.BaseAccuracy.ToString ();
	_BaseStrain.text = CurrentTechnique.BaseStrain.ToString();
	_Range.text = CurrentTechnique.DisplayRange;
//	_TreeName.text = "";
		//The main sheet will not have any need for the tree name.


//		_StatsToUse = GetStatImages (CurrentTechnique.StatsUsed);
		_ElementType = GetElementTypeImages (CurrentTechnique.Types);
//
//		_StatImage.sprite = _StatsToUse [0];
		_TypeImage.sprite = _ElementType [0];
		//These only display first item, it should be list 
//		//there should be a sprite packing method
		_ElementType.Clear ();
//		_StatsToUse.Clear ();
//		//These lists should be dumped into the statimage and typeimage and cleared.
//		//clearing them prevents 50 sprites from being added when moves are swapped.

		if (ToDisplay.Types.Count == 0) 
		{
			_BackGround.color = TypeColors.NothingColor;
			//We can currently support typeless moves?
		} 
		else 
		{
			Color TempColor = TypeColors.GetColorForType (CurrentTechnique.Types [0]);
			TempColor.a = 0.8f;
			_BackGround.color = TempColor;

			if (ToDisplay.Types.Count > 1) 
			{
				Debug.Log ("Add Support for multiple types");
			}
		}
	}

	public void ChangeTechniqueDisplay (Technique ToDisplay, SkillTree _Tree)
	{
		CurrentTechnique = ToDisplay;

		if (ToDisplay == null) 
		{
			_BaseDamage.text = "";
			_BaseAccuracy.text = "";
			_Range.text = "";
			_BaseStrain.text = "";
			_TreeName.text = "";
			return;
		}

		_Header.text = CurrentTechnique.Name;
		_Description.text = CurrentTechnique.Description;
		_BaseDamage.text = CurrentTechnique.BaseDamage.ToString ();
		_BaseAccuracy.text = CurrentTechnique.BaseAccuracy.ToString ();
		_BaseStrain.text = CurrentTechnique.BaseStrain.ToString();
		_Range.text = CurrentTechnique.DisplayRange;
		_TreeName.text = _Tree.Name;
		//This version will give us the tree's title and tier.
		_ElementType = GetElementTypeImages (CurrentTechnique.Types);
		_TypeImage.sprite = _ElementType [0];
		_ElementType.Clear ();

		_BackGround.color = TypeColors.GetColorForTier (_Tree.Tier);
	}

	public void ChangeTechniqueDisplay (ILevelUpOption _Option, Technique ToDisplay)
	{
		CurrentTechnique = ToDisplay;

		if (ToDisplay == null) 
		{
			_TreeName.text = "";
			_BaseDamage.text = "";
			_BaseAccuracy.text = "";
			_Range.text = "";
			_BaseStrain.text = "";
			return;
		}

		_Header.text = CurrentTechnique.Name;
		_Description.text = CurrentTechnique.Description;
		_BaseDamage.text = CurrentTechnique.BaseDamage.ToString ();
		_BaseAccuracy.text = CurrentTechnique.BaseAccuracy.ToString ();
		_BaseStrain.text = CurrentTechnique.BaseStrain.ToString();
		_Range.text = CurrentTechnique.DisplayRange;
		_TreeName.text = _Option.Tree.Name;

		//		_StatsToUse = GetStatImages (CurrentTechnique.StatsUsed);
		_ElementType = GetElementTypeImages (CurrentTechnique.Types);
		//
		//		_StatImage.sprite = _StatsToUse [0];
		_TypeImage.sprite = _ElementType [0];
		//These only display first item, it should be list 
		//		//there should be a sprite packing method
		_ElementType.Clear ();
		//		_StatsToUse.Clear ();
		//		//These lists should be dumped into the statimage and typeimage and cleared.
		//		//clearing them prevents 50 sprites from being added when moves are swapped.

		_BackGround.color = TypeColors.GetColorForTier (ToDisplay.Tier);

	}


//	public void GetStatImages (List <MyStat> ToReturn) 
//	{
//		if (ToReturn == null) {return;}
//			
//		for (int i = 0; i < ToReturn.Count; i++) 
//		{
//			_StatsToUse.Add (TypeColors.GetSpriteForStat(ToReturn [i]));
//		}
//	}

	public List <Sprite> GetStatImages (List <IStat> _Images) 
	{
		List <Sprite> ToReturn = new List <Sprite> ();
		if (_Images == null) {return null;}
		_Images.Apply ((x)=>{ToReturn.Add (TypeColors.GetSpriteForStat(x));});
		return ToReturn;
	}

	public List <Sprite> GetElementTypeImages (List <ElementTypes> _Types) 
	{
		List <Sprite> ToReturn = new List <Sprite> ();
//	if (_Types == ElementTypes.Nothing) {return null;}
		_Types.Apply ((x)=> {ToReturn.Add (TypeColors.GetSpriteForType(x));});
		return ToReturn;
	}

//	public SkillTreeTier GetTreeTierForMove (SkillTreeData _TreeData)
//	{
//		return 
//	}

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