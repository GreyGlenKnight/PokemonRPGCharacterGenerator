using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class StatUpChoice : MonoBehaviour {

	public Image _BackGround;
	public Image _StatImage1;
	public Image _StatImage2;
//	public List <Sprite> _StatsToUse = new List <Sprite> ();

	public Text _TreeName;
	public Text _Stat1Header;
	public Text _Stat2Header;

	public Text _Stat1Description;
	public Text _Stat2Description;

//	public Button _Button1;
//	public Button _Button2;

	public void DisplayStatUpChoice (IOption _IOption, 
		MyStat _Stat)
	{
//		_Button1.
		_TreeName.text = _IOption.TreeName;
		_StatImage1.sprite = TypeColors.GetSpriteForStat (_Stat);
		_Stat1Header.text = _Stat.ToString();
		_Stat1Description.text = _Stat.ToString()+" +.5";

		_StatImage2.sprite = TypeColors.GetSpriteForStat (_Stat);
		_Stat2Header.text = _Stat.ToString();
		_Stat2Description.text = _Stat.ToString()+" +.5";
	}

	//

}
