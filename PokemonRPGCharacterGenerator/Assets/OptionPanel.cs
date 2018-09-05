using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class OptionPanel : MonoBehaviour
{
	public Text _Header;
	public Text _Description;
	public Image _Symbol;
	public Image _BackGround;

    public void DisplayOption (IChoosable _Choice)
    {
        _BackGround.color = TypeColors.NormalColor;
        _Header.text = _Choice.Name;
        _Description.text = _Choice.Description;
    }
}



