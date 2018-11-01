using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreeLineDisplay : MonoBehaviour 
{
	public Toggle BonusToggle;
	public Text BonusText;
	public Image BonusBG;
	public LevelUpBonus BonusToDisplay;

	public static Color LockTreeColor = Color.clear;

    private void Awake()
    {
        BonusText.text = "";
        BonusText.color = Color.black;
        BonusToggle.isOn = false;
        //BonusBG.color = LockTreeColor;
    }

    public void SetToggle(bool setTo)
    {
        if(setTo == true)
        {
            BonusText.color = ToInactive(BonusText.color);
            BonusToggle.isOn = true;
        }
        else
        {
            BonusText.color = ToActive(BonusText.color);
            BonusToggle.isOn = false;
        }
    }

    private Color ToActive(Color color)
    {
        return new Color(color.r, color.g, color.b, 1f);
    }

    private Color ToInactive(Color color)
    {
        return new Color(color.r, color.g, color.b, 0.5f);
    }

    public void DisplayBonusName(string name)
    {
        BonusText.text = name;
    }

}
