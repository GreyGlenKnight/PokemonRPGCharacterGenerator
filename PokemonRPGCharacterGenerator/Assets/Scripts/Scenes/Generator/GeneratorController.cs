using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneratorController
{
    GeneratorDisplay Display;
    public SkillTreeBlockController Treeblock;
    Pokemon CurrentPokemon;

    public GeneratorController(
        GeneratorDisplay generatorDisplay,
        Pokemon pokemon,
        BadgeLevelGenerator generator,
        SceneChanger sceneChanger)
    {
        Display = generatorDisplay;
        Treeblock = new SkillTreeBlockController(
            Display.Load(),
            pokemon._SkillTreeBlock, pokemon,
            sceneChanger._InterruptDialog);

        AddSceneChanger(sceneChanger);
        AddGenerator(generator);
        Display.SetToggleBlockAction(Treeblock.ChangeVisibleTrees);
        SetPokemon(pokemon);
    }

    internal void Destroy()
    {
        RemoveEvents();
    }

    private void RemoveEvents()
    {
        if (CurrentPokemon == null)
            return;
        CurrentPokemon.OnBreakTree -= OnPokemonUpdate;
        CurrentPokemon.OnActivateTree -= OnPokemonUpdate;
        CurrentPokemon.OnTradeSkill -= OnPokemonUpdate;
        CurrentPokemon.OnAddXP -= OnPokemonUpdate;
    }

    #region Event Handlers
    public void OnPokemonUpdate(object Caller, EventArgs E)
    {
        Refresh((Pokemon)Caller);
    }

    #endregion

    public void Refresh(Pokemon toRefresh)
    {
        Treeblock.Refresh();
        Display.UpdateXPDisplay(toRefresh.XP,toRefresh.Level,toRefresh.Level);
    }

    public void SetPokemon(Pokemon pokemon)
    {
        RemoveEvents();
        CurrentPokemon = pokemon;
        pokemon.OnBreakTree += OnPokemonUpdate;
        pokemon.OnActivateTree += OnPokemonUpdate;
        pokemon.OnTradeSkill += OnPokemonUpdate;
        pokemon.OnAddXP += OnPokemonUpdate;
        pokemon.OnChooseLevelUpBonus += OnPokemonUpdate;
        
        Display.SetXPAction(() =>
        {
            pokemon.AddXP();
            GameManager.instance._BadgeLevelGenerator._BadgeLevelDisplay.UpdateDisplay(pokemon);
        });
        Debug.Log(pokemon.XP);
        Display.UpdateXPDisplay(pokemon.XP, pokemon.Level, pokemon.Level);
    }

    public void AddSceneChanger(SceneChanger sceneChanger)
    {
        Display.SetLevelupAction(sceneChanger.SwitchToInterrupt);
        Display.SetReturnAction(sceneChanger.SwitchToSheet);
    }

    public void AddGenerator(BadgeLevelGenerator generator)
    {
        Display.SetDropdownAction(generator.OnBadgeLevelSelect);
        Display.SetGenerateAction(()=> 
        {
            generator.OnGenerateMonClick();
            Refresh(CurrentPokemon);
        } );
    }


}
