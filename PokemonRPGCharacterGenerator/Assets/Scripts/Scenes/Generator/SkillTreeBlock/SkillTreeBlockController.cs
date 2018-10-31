using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum TreeRowState
{
    First,
    Last,
}

public class SkillTreeBlockController 
{
	public const int BONUSES_ON_TREE = 12;
    private const int TREES_PER_BLOCK = 6;
    public SkillTreeBlockDisplay Display;
    private SkillTreeBlock Data;

    //public List <SkillTreeDisplay> TreeDisplays = new List <SkillTreeDisplay> ();

    private Pokemon _CurrentPokemon;
    
	public TreeRowState _TreeRowState;

	public InterruptDialog _InterruptDialog;


    public SkillTreeBlockController (
        SkillTreeBlockDisplay display,
        SkillTreeBlock data,
        Pokemon pokemon,
        InterruptDialog interruptDialog)
    {
        Display = display;
        Data = data;

        _TreeRowState = TreeRowState.First;

        SetPokemon(pokemon);
        _InterruptDialog = interruptDialog;
    }

    public void ChangeVisibleTrees()
    {
        ToggleBlock();
    }

    private void ToggleBlock()
    {
        if (_TreeRowState == TreeRowState.First)
            _TreeRowState = TreeRowState.Last;
        else
            _TreeRowState = TreeRowState.First;
        Refresh();
    }

    public void SetPokemon(Pokemon pokemon)
    {
        _CurrentPokemon = pokemon;
        // TODO BadgeLevelGenerator to subscribe to event

        _TreeRowState = TreeRowState.First;

        Data = _CurrentPokemon._SkillTreeBlock;
        Refresh();
    }

    public void ChangeDisplayPokemon(Pokemon ToDisplay)
    {
        SetPokemon(ToDisplay);
    }

    public void Refresh()
    {
        GameManager.instance._BadgeLevelGenerator._BadgeLevelDisplay.UpdateDisplay(_CurrentPokemon);

        List<SkillTree> Temp = (Data.SortSkillTreeList());

        Display.Clear();

        int startIndex = ((int)_TreeRowState * TREES_PER_BLOCK);

        for (int i = 0; i < TREES_PER_BLOCK; i++)
        {
            if (i + startIndex > Temp.Count)
                break;

            new SkillTreeController(Display.AddTree(),Temp[i + startIndex]);
        }
    }



	public void OnCallTreeRoll ()
	{
        List <ILevelUpOption> TreeRolls = Data.RollOnTrees ();
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

        ILevelUpOption Temp = GenerateLevelUpChoice (Data.RollOnTrees() ,
                               PriorityList);
        Temp.Tree.OnSelected(Temp);
	}

    public List <ILevelUpOption> CheckForBonusType (
        BonusAtIndex _Bonus, 
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
