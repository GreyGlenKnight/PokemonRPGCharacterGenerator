using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class MenuSceneChanger : MonoBehaviour 
{
	public PokeSheetSceneManager _PokeSheetSceneManager;
	public PokeSheetTreeManager _PokeSheetTreeManager;
//	public SkillTreeDisplay Row1;
//	public SkillTreeDisplay Row2;
//	public SkillTreeDisplay Row3;

	public void SwitchToTree ()
	{
		_PokeSheetSceneManager.gameObject.SetActive (false);
		_PokeSheetTreeManager.gameObject.SetActive (true);
	}

	public void SwitchToSheet ()
	{
		_PokeSheetTreeManager.gameObject.SetActive (false);
		_PokeSheetSceneManager.gameObject.SetActive (true);

	}

	public void ChangeVisibleTrees ()
	{
		Debug.Log ("Switch Trees");
		//This probably doesn't go here, but this class knows all the trees for now.
//		Row1.gameObject.SetActive (false);
//		Row2.gameObject.SetActive (true);
//
	}

}
