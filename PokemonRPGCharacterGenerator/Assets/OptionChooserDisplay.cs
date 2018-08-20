using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum CurrentChoiceType
{
	SkillTree,
	Technique,
	Stat
//	Pokemon
//	Item,
//
}

public class OptionChooserDisplay : MonoBehaviour 
{
//	public Text _Header;
//	public Text _Description;
//	public Image _Symbol;
//	public Image _BackGround;
	public TechniqueDisplay _TechniqueVertical;
//	public StatUpChoice _StatUpChoice;
	public SkillTree _SkillTree;
	public OptionPanel _OptionPanel;
	public CurrentChoiceType _CurrentChoiceType;

//This class is driven by InterruptDialogue, has minimal logic

//	public void OnClick ()
//	{
//		//Change scene, call event.
//		Debug.Log (_SkillTree.Name);
//		switch (_CurrentChoiceType) 
//		{
//		case CurrentChoiceType.SkillTree:
//			_SkillTree.OnManualSelectClick ();
////			GameManager.instance.SceneChanger.SwitchToTree();
//			break;
//		case CurrentChoiceType.Stat:	
//			_SkillTree.OnManualSelectClick ();
//			break;
//		case CurrentChoiceType.Technique:
//			_SkillTree.OnManualSelectClick ();
//			break;
//		default:
//			throw new NotImplementedException ();
//		}
//	}

	public void DisplayLevelUpOption (ILevelUpOption _Bonus)
	{
		if (_Bonus == null) 
		{
			return;
		}

		_CurrentChoiceType = CurrentChoiceType.SkillTree;
		_SkillTree = _Bonus.Tree;
		_OptionPanel._BackGround.color = TypeColors.GetColorForTier (_Bonus.Tree.Tier);


		if ((_Bonus.TypeOfBonus) == BonusAtIndex.Technique) {
			DisplayLevelUpOption (_Bonus, 
				_Bonus.Tree._TechniquesOnTree [((int)_Bonus.TypeOfBonus)]);
			_TechniqueVertical._BackGround.color = TypeColors.GetColorForTier (_Bonus.Tree.Tier);
			return;
		}
		_OptionPanel._Header.text = _Bonus.BonusName;
		_OptionPanel._Description.text = _Bonus.OptionDescription;
		_OptionPanel.gameObject.SetActive (true);
		_TechniqueVertical.gameObject.SetActive (false);
	}

	public void DisplayLevelUpOption (ILevelUpOption _Bonus, SkillTree _Tree)
	{
		if (_Tree == null || _Bonus == null) {
			return;
		}

		_CurrentChoiceType = CurrentChoiceType.SkillTree;
		_SkillTree = _Tree;
		_OptionPanel._BackGround.color = TypeColors.GetColorForTier (_Tree.Tier);


		if (((int)_Bonus.TypeOfBonus) < 4) {
			DisplayLevelUpOption (_Bonus, 
				_Tree._TechniquesOnTree [((int)_Bonus.TypeOfBonus)]);
			_TechniqueVertical._BackGround.color = TypeColors.GetColorForTier (_Tree.Tier);
			return;
		}
//
//		if (_Bonus.TypeOfBonus == BonusAtIndex.StatUp) {
//			Debug.Log ("OptionChooserDisplay 6");
//			DisplayLevelUpOption (_Bonus, 
//				MyStat.RollStatChoices (_Tree.FavoredStatOnTree) [0]);
//			_StatUpChoice._BackGround.color = TypeColors.GetColorForTier (_Tree.Tier);
//			return;
//		}

		//		_OptionPanel._Symbol;
		_OptionPanel._Header.text = _Bonus.BonusName;
		_OptionPanel._Description.text = _Bonus.OptionDescription;
		_OptionPanel.gameObject.SetActive (true);
		_TechniqueVertical.gameObject.SetActive (false);
//		_StatUpChoice.gameObject.SetActive (false);
	}

	public void DisplayLevelUpOption (ILevelUpOption _Bonus, Technique _Technique)
	{
		_CurrentChoiceType = CurrentChoiceType.Technique;
//		this.gameObject.SetActive (false);
		_TechniqueVertical.gameObject.SetActive (true);
		_OptionPanel.gameObject.SetActive (false);
//		_StatUpChoice.gameObject.SetActive (false);
		_TechniqueVertical.ChangeTechniqueDisplay (_Bonus, _Technique);
	}
		
//	public void DisplayLevelUpOption (IOption _Bonus, MyStat _Stat)
//	{
//		_CurrentChoiceType = CurrentChoiceType.Stat;
//		_TechniqueVertical.gameObject.SetActive (false);
//		_OptionPanel.gameObject.SetActive (false);
//		_StatUpChoice.gameObject.SetActive (true);
//		_StatUpChoice.DisplayStatUpChoice (_Bonus, _Stat);
//	}

	//Could use MaturityBonus as input parameter if Maturity Up would yield a bonus.
}
