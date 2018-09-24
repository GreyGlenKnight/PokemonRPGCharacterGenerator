using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public PokeSheetSceneManager _PokeSheetSceneManager;
    public PokeSheetTreeManager _PokeSheetTreeManager;
	public PokeSheetHistoryManager _PokeSheetHistoryManager;
	public InterruptDialog _InterruptDialog;


    public void SwitchToTree()
    {
		_PokeSheetTreeManager.gameObject.SetActive(true);
		_PokeSheetSceneManager.gameObject.SetActive(false);
		_PokeSheetHistoryManager.gameObject.SetActive (false);
		_InterruptDialog.gameObject.SetActive (false);

    }

	public void SwitchToInterrupt()
	{
		_PokeSheetTreeManager.gameObject.SetActive(true);
		_PokeSheetSceneManager.gameObject.SetActive(false);
		_PokeSheetHistoryManager.gameObject.SetActive (false);
		_InterruptDialog.gameObject.SetActive (true);

	}

    public void SwitchToSheet()
    {
        _PokeSheetTreeManager.gameObject.SetActive(false);
        _PokeSheetSceneManager.gameObject.SetActive(true);
		_PokeSheetHistoryManager.gameObject.SetActive (false);
		_InterruptDialog.gameObject.SetActive (false);


    }

	public void SwitchToHistory()
	{
		_PokeSheetTreeManager.gameObject.SetActive(false);
		_PokeSheetSceneManager.gameObject.SetActive(false);
		_PokeSheetHistoryManager.gameObject.SetActive (true);
		_InterruptDialog.gameObject.SetActive (false);

        _PokeSheetHistoryManager.ChangeDisplay (GameManager.instance.CurrentPokemon._HistoryBlock.BonusHistory);
	}

}
