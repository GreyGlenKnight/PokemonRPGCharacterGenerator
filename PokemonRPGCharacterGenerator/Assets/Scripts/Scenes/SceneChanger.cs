using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    //public PokeSheetSceneManager _PokeSheetSceneManager;
    //public PokeSheetTreeManager _PokeSheetTreeManager;

    public PokemonSheetDisplay _PokemonSheet;
	public PokeSheetHistoryManager _PokeSheetHistoryManager;
	public InterruptDialog _InterruptDialog;
    public Transform RootDisplay;

    [SerializeField] private GeneratorDisplay GeneratorGUIPrefab;
    private GeneratorDisplay GeneratorDisplay;
    private GeneratorController GeneratorController;
    
    private void ClosePokemonGenerationGUI()
    {
        if (GeneratorDisplay == null)
            return;
        GeneratorController.Destroy();
        Destroy(GeneratorDisplay.gameObject);
        GeneratorController = null;
    }

    private void OpenPokemonGenerationGUI()
    {
        Debug.Log("Trying to create Pokemon generation scene");
        if (GeneratorGUIPrefab == null)
            throw new System.Exception(
                "GeneratorGUIPrefab is null, " +
                "Assign in inspector!");

        if (GeneratorDisplay != null)
            throw new System.Exception(
                "Unable to open generator GUI, " +
                "an instance already exists");

        GeneratorDisplay = Instantiate(GeneratorGUIPrefab);
        GeneratorDisplay.transform.SetParent(RootDisplay,false);
        GeneratorController = new GeneratorController(
            GeneratorDisplay,
            GameManager.instance.CurrentPokemon,
            GameManager.instance._BadgeLevelGenerator,
            this);


    }

    public void SwitchToTree()
    {
        OpenPokemonGenerationGUI();

        _PokemonSheet.gameObject.SetActive(false);
		_PokeSheetHistoryManager.gameObject.SetActive (false);
		_InterruptDialog.gameObject.SetActive (false);
    }

	public void SwitchToInterrupt()
	{
        ClosePokemonGenerationGUI();
        _PokemonSheet.gameObject.SetActive(false);
		_PokeSheetHistoryManager.gameObject.SetActive (false);
		_InterruptDialog.gameObject.SetActive (true);

	}

    public void SwitchToSheet()
    {
        ClosePokemonGenerationGUI();
        _PokemonSheet.gameObject.SetActive(true);
		_PokeSheetHistoryManager.gameObject.SetActive (false);
		_InterruptDialog.gameObject.SetActive (false);
    }

	public void SwitchToHistory()
	{
        ClosePokemonGenerationGUI();

        _PokemonSheet.gameObject.SetActive(false);
		_PokeSheetHistoryManager.gameObject.SetActive (true);
		_InterruptDialog.gameObject.SetActive (false);

        _PokeSheetHistoryManager.ChangeDisplay (GameManager.instance.CurrentPokemon._HistoryBlock.BonusHistory);
	}

}
