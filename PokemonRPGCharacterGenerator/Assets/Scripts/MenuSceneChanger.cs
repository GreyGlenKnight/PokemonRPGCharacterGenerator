using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum TreeRowView 
{
	Baby, Mid, Last
}


public class MenuSceneChanger : MonoBehaviour 
{
	
//	//public PokeSheetSceneManager _PokeSheetSceneManager;
//	//public PokeSheetTreeManager _PokeSheetTreeManager;
//	public TreeRowView ActiveView = TreeRowView.Baby;
//	public Canvas row1;
//	public Canvas row2;
//	public Canvas row3;
////	public SkillTree [] Row1 = new SkillTree [4];
////	public SkillTree [] Row2 = new SkillTree [4];
////	public SkillTree [] Row3 = new SkillTree [4];

//	//public void SwitchToTree ()
//	//{
//	//	_PokeSheetSceneManager.gameObject.SetActive (false);
//	//	_PokeSheetTreeManager.gameObject.SetActive (true);
//	//}

//	//public void SwitchToSheet ()
//	//{
//	//	_PokeSheetTreeManager.gameObject.SetActive (false);
//	//	_PokeSheetSceneManager.gameObject.SetActive (true);

//	//}

//	public void ChangeVisibleTrees ()
//	{

//		if (ActiveView == TreeRowView.Baby) 
//		{
//			row1.gameObject.SetActive (true);
//			row2.gameObject.SetActive (false);
//			row3.gameObject.SetActive (false);
//			ActiveView = TreeRowView.Mid;
//				return;
//		}
//		if (ActiveView == TreeRowView.Mid) 
//		{
//			row1.gameObject.SetActive (false);
//			row2.gameObject.SetActive (true);
//			row3.gameObject.SetActive (false);
//			ActiveView = TreeRowView.Last;
//			return;
//		}
//		if (ActiveView == TreeRowView.Last) 
//		{
//			row1.gameObject.SetActive (false);
//			row2.gameObject.SetActive (false);
//			row3.gameObject.SetActive (true);
//			ActiveView = TreeRowView.Baby;
//			return;
//		}
//	}

//	void Awake ()
//	{
//		ChangeVisibleTrees ();
//	}
}
