using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public PokeSheetSceneManager _PokeSheetSceneManager;
    public PokeSheetTreeManager _PokeSheetTreeManager;
	public PokeSheetHistoryManager _PokeSheetHistoryManager;
	public PokeSheetHistoryView _PokeSheetHistoryView;

    public void SwitchToTree()
    {
		_PokeSheetTreeManager.gameObject.SetActive(true);
		_PokeSheetSceneManager.gameObject.SetActive(false);
		_PokeSheetHistoryView.gameObject.SetActive (false);

    }

    public void SwitchToSheet()
    {
        _PokeSheetTreeManager.gameObject.SetActive(false);
        _PokeSheetSceneManager.gameObject.SetActive(true);
		_PokeSheetHistoryView.gameObject.SetActive (false);


    }

	public void SwitchToHistory()
	{
		_PokeSheetTreeManager.gameObject.SetActive(false);
		_PokeSheetSceneManager.gameObject.SetActive(false);
		_PokeSheetHistoryView.gameObject.SetActive (true);
		_PokeSheetHistoryManager.ChangeDisplay (GameManager.instance.CurrentPokemon);
	}

	void Awake ()
	{
		SwitchToSheet ();
	}

}
