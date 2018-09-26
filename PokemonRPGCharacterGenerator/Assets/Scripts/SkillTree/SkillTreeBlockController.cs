using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum TreeRowState
{
    Baby,
    Mid,
    Adult
}

public class SkillTreeBlockController 
{
	public const int NUMBER_OF_TREES = 4;
	public const int BONUSES_ON_TREE = 12;

    public SkillTreeBlockDisplay _SkillTreeBlockDisplay;
    //public List <SkillTreeDisplay> TreeDisplays = new List <SkillTreeDisplay> ();

    private Pokemon _CurrentPokemon;
    private SkillTreeBlock _SkillTreeBlock;
	public TreeRowState _TreeRowState;

	public InterruptDialog _InterruptDialog;
    public SceneChanger _SceneChanger;


    public SkillTreeBlockController ()
    {
    }

    //public void ChangeDisplayPokemon ()
    //{

    //}


	public void OnBreakTree (object Caller, EventArgs E)
	{
		Refresh ();
 	}

	public void OnActivateTree (object Caller, EventArgs E)
	{
		Refresh ();
	}

	public void OnTradeSkill (object Caller, EventArgs E)
	{
		Refresh ();
	}

	public void OnSelectOption (object Caller, EventArgs E)
	{
		Refresh ();
	}

	public void SceneUpdate ()
	{
        _SceneChanger.SwitchToTree();
		Refresh ();	
	}


	public void OnAddXPClick ()
	{
		_CurrentPokemon.AddXP ();
		GameManager.instance._BadgeLevelGenerator._BadgeLevelDisplay.UpdateDisplay (_CurrentPokemon);
	}

//	public Pokemon CopyCurrentPokemon {get {return new Pokemon (_CurrentPokemon);}}
		
	public void ChangeDisplayPokemon (Pokemon ToDisplay)
	{
        _SkillTreeBlockDisplay.Clear ();
		_TreeRowState = TreeRowState.Baby;

		_CurrentPokemon = ToDisplay;
        _SkillTreeBlock = ToDisplay._SkillTreeBlock;
		ToDisplay.OnBreakTree += OnBreakTree;
		ToDisplay.OnActivateTree += OnActivateTree;
		ToDisplay.OnTradeSkill += OnTradeSkill;
		Refresh ();
	}

    public void AssignDisplay(SkillTreeBlockDisplay _Display)
    {
        _SkillTreeBlockDisplay = _Display;
        _SkillTreeBlockDisplay.Clear();
    }

	public void Refresh ()
	{
		GameManager.instance._BadgeLevelGenerator._BadgeLevelDisplay.UpdateDisplay (_CurrentPokemon);
       
       List <SkillTree> Temp = (_SkillTreeBlock.SortSkillTreeList());
        
        _SkillTreeBlockDisplay.Clear ();

        int i = ((int)_TreeRowState * 4);

        for (int x = 0; x < 4; x++)
        {
            if (x + i > Temp.Count)
                break;

            _SkillTreeBlockDisplay.AddNewSkillTree (
                new SkillTreeController (Temp[x + i]));
        }
	}

	public void ChangeVisibleTrees ()
	{
		switch (_TreeRowState)
		{
		case TreeRowState.Baby:
			_TreeRowState = TreeRowState.Mid;
			Refresh ();
			break;
		case TreeRowState.Mid:
			_TreeRowState = TreeRowState.Adult;
			Refresh ();
			break;
		case TreeRowState.Adult:
			_TreeRowState = TreeRowState.Baby;
			Refresh ();
			break;
		default:
			Debug.Log("There is a new View add logic here. view name is " + _TreeRowState);
			break;
		}
	}

	//public void TreeSwap (int TreeToChange, int TreeDataIndex)
	//{
	//	if (_SkillTreeBlock.Count <= TreeToChange) 
	//	{
	//		return;
	//	}

	//	if (_SkillTreeBlock._SkillTrees.Count <= TreeDataIndex) 
	//	{
	//		TreeDisplays [TreeToChange].ChangeDisplayData (null);
	//		return;
	//	}

	//	TreeDisplays [TreeToChange].ChangeDisplayData (_CurrentPokemon._SkillTreeBlock._SkillTrees [TreeDataIndex]);
	//}

	public void OnCallTreeRoll ()
	{
        List <ILevelUpOption> TreeRolls = _SkillTreeBlock.RollOnTrees ();
		if (TreeRolls == null)
			{return;}

        _InterruptDialog.DisplayOptionsList (TreeRolls);
	}


    public ILevelUpOption GenerateLevelUpChoice (
        List <ILevelUpOption> Choices,
        List <BonusAtIndex> Priority)
    {

        foreach (BonusAtIndex CurrentBonusType in Priority)
        {
            List<ILevelUpOption> Temp = CheckForBonusType (CurrentBonusType,
                                                          Choices);
            if (Temp.Count > 0)
            {
                Temp.Shuffle();
                return Temp[0];
            }
        }
        throw new Exception("Invalid choices at levelup");
    }

    public void OnAutoSelectClick()
    {
        List<BonusAtIndex> PriorityList = new List<BonusAtIndex> 
        {
        BonusAtIndex.StatUp,
        BonusAtIndex.MoveMod,
        BonusAtIndex.Technique,
        BonusAtIndex.SkillUp,
        BonusAtIndex.Ability,
        BonusAtIndex.Endurance,
        BonusAtIndex.Maturity,
        BonusAtIndex.TreeUp,
        BonusAtIndex.CrossTree
        };

        ILevelUpOption Temp = GenerateLevelUpChoice (_SkillTreeBlock.RollOnTrees() ,
                               PriorityList);
        Temp.Tree.OnSelected(Temp);
	}


    public List <ILevelUpOption> CheckForBonusType (BonusAtIndex _Bonus, 
                                 List <ILevelUpOption> _Choices)
    {
        List <ILevelUpOption> TempRolls = new List<ILevelUpOption> ();

        for (int i = 0; i < _Choices.Count; i++)
        {
            if (_Choices[i].TypeOfBonus == _Bonus)
            {
                TempRolls.Add(_Choices[i]);
            }
        }
        return TempRolls;
    }
}