using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TypeAssigner : MonoBehaviour
{
	public Text TypeText1;
	public Text TypeText2;
	public GameObject PanelType1;
	public GameObject PanelType2;
	public Image Background1;	
	public Image Background2;

	public int ListPos1;
	public int ListPos2;
	List <Color> TypeColorList = new List <Color> ();
	List <string> TypeStringList = new List <string> ();

	void Awake () 
    {
		TypeColorList.Add(TypeColors.NormalColor);
		TypeColorList.Add(TypeColors.FireColor);
		TypeColorList.Add(TypeColors.WaterColor);
		TypeColorList.Add(TypeColors.ElectricColor);
		TypeColorList.Add(TypeColors.GrassColor);
		TypeColorList.Add(TypeColors.IceColor);
		TypeColorList.Add(TypeColors.FightingColor);
		TypeColorList.Add(TypeColors.PoisonColor);
		TypeColorList.Add(TypeColors.GroundColor);
		TypeColorList.Add(TypeColors.FlyingColor);
		TypeColorList.Add(TypeColors.PsychicColor);
		TypeColorList.Add(TypeColors.BugColor);
		TypeColorList.Add(TypeColors.RockColor);
		TypeColorList.Add(TypeColors.GhostColor);
		TypeColorList.Add(TypeColors.DragonColor);
		TypeColorList.Add(TypeColors.DarkColor);
		TypeColorList.Add(TypeColors.SteelColor);
		TypeColorList.Add(TypeColors.FairyColor);

		TypeStringList.Add(TypeColors.Normal);
		TypeStringList.Add(TypeColors.Fire);
		TypeStringList.Add(TypeColors.Water);
		TypeStringList.Add(TypeColors.Electric);
		TypeStringList.Add(TypeColors.Grass);
		TypeStringList.Add(TypeColors.Ice);
		TypeStringList.Add(TypeColors.Fighting);
		TypeStringList.Add(TypeColors.Poison);
		TypeStringList.Add(TypeColors.Ground);
		TypeStringList.Add(TypeColors.Flying);
		TypeStringList.Add(TypeColors.Psychic);
		TypeStringList.Add(TypeColors.Bug);
		TypeStringList.Add(TypeColors.Rock);
		TypeStringList.Add(TypeColors.Ghost);
		TypeStringList.Add(TypeColors.Dragon);
		TypeStringList.Add(TypeColors.Dark);
		TypeStringList.Add(TypeColors.Steel);
		TypeStringList.Add(TypeColors.Fairy);
		ListPos1 = 17;
		ListPos2 = 17;
		CycleColors();
		CycleColors2();
	}

	public void	CycleColors()
	{
		ListPos1++;

		if (ListPos1 == 18) 
		    {ListPos1 = 0;}

		Background1.color = TypeColorList.ElementAt (ListPos1);
		TypeText1.text = TypeStringList.ElementAt (ListPos1);
		TypeText1.color = TypeColorList.ElementAt (ListPos1);
	}

    public void	CycleColors2()
    {
		ListPos2++;
		if (ListPos2 == 18) 
		{ListPos2 = 0;}
		Background2.color = TypeColorList.ElementAt (ListPos2);
		TypeText2.color = TypeColorList.ElementAt (ListPos2);
		TypeText2.text = TypeStringList.ElementAt (ListPos2);
    }

}
	