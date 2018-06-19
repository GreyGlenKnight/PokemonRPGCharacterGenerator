using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class LevelUpOptionDisplay : MonoBehaviour 
{
	public Text _Header;
	public Text _Description;
	public Image _Symbol;
	public Image _BackGround;
	public TechniqueDisplay _TechniqueVertical;
	public StatUpChoice _StatUpChoice;

//This class is driven by InterruptDialogue, has minimal logic

	public void DisplayLevelUpOption (IOption _Bonus, SkillTreeData _Tree)
	{
		if ((int)_Bonus.TypeOfBonus < 4)
			{
			DisplayLevelUpOption (_Bonus, 
				_Tree.TechniquesOnTree [(int)_Bonus.TypeOfBonus]);
			_TechniqueVertical._BackGround.color = TypeColors.GetColorForTier (_Tree.Tier);

			return;
			}

//		if ((int)_Bonus.TypeOfBonus == 6)
//			{
//			DisplayLevelUpOption (_Bonus, 
//				LevelUpChooser.RollForStats (_Tree.FavoredStatOnTree));
//			_StatUpChoice._BackGround.color = TypeColors.GetColorForTier (_Tree.Tier);
//			return;
//			}

		_BackGround.color = TypeColors.GetColorForTier (_Tree.Tier);
		_Header.text = _Bonus.BonusName;
		_Description.text = _Bonus.OptionDescription;
		_TechniqueVertical.gameObject.SetActive (false);
		_StatUpChoice.gameObject.SetActive (false);
	}

	public void DisplayLevelUpOption (IOption _Bonus, Technique _Technique)
	{
		_TechniqueVertical.gameObject.SetActive (true);
		_StatUpChoice.gameObject.SetActive (false);
		_TechniqueVertical.ChangeTechniqueDisplay (_Bonus, _Technique);
	}



	public void DisplayLevelUpOption (IOption _Bonus, MyStat _Stat)
	{
		_TechniqueVertical.gameObject.SetActive (false);
		_StatUpChoice.gameObject.SetActive (true);
		_StatUpChoice.DisplayStatUpChoice (_Bonus, _Stat);
	}

	//Could use MaturityBonus as input parameter if Maturity Up would yield a bonus.

	void Awake ()
	{
		
	}

}
