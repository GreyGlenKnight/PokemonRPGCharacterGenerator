using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TypeAssigner : MonoBehaviour
	{
		public string PokemonType1;
		public string PokemonType2;
		public Color NormalColor;
		public Color FireColor;
		public Color WaterColor;
		public Color ElectricColor;
		public Color GrassColor;
		public Color IceColor;
		public Color FightingColor;
		public Color PoisonColor;
		public Color GroundColor;
		public Color FlyingColor;
		public Color PsychicColor;
		public Color BugColor;
		public Color RockColor;
		public Color GhostColor;
		public Color DragonColor;
		public Color DarkColor;
		public Color SteelColor;
		public Color FairyColor;
		public string Normal;
		public string Fire;
		public string Water;
		public string Electric;
		public string Grass;
		public string Ice;
		public string Fighting;
		public string Poison;
		public string Ground;
		public string Flying;
		public string Psychic;
		public string Bug;
		public string Rock;
		public string Ghost;
		public string Dragon;
		public string Dark;
		public string Steel;
		public string Fairy;
		public int ListPos = 0;
	List <Color> TypeColorList = new List <Color> ();
	List <string> TypeStringList = new List <string> ();


		Color RGBColor(float r, float g, float b)
		{
			if (r > 255)
				r = 255f;
			if (g > 255)
				g = 255f;
			if (b > 255)
				b = 255f;
			r /= 255f;
			g /= 255f;
			b /= 255f;
			return new Color(r, g, b);
		}

		void Awake () 
		{

			NormalColor = RGBColor (165, 165, 117);
			FireColor = RGBColor (237, 124, 43);
			WaterColor = RGBColor (97, 139, 239);
			ElectricColor = RGBColor (247, 207, 44);
			GrassColor = RGBColor (116, 195, 76);
			IceColor = RGBColor (145, 213, 213);
			FightingColor = RGBColor (189, 47, 39);
			PoisonColor = RGBColor (157, 63, 157);
			GroundColor = RGBColor (227, 187, 92);
			FlyingColor = RGBColor (166, 143, 236);
			PsychicColor = RGBColor (248, 78, 129);
			BugColor = RGBColor (164, 179, 31);
			RockColor = RGBColor (178, 155, 54);
			GhostColor = RGBColor (108, 85, 146);
			DragonColor = RGBColor (108, 51, 247);
			DarkColor = RGBColor (109, 86, 70);
			SteelColor = RGBColor (179, 179, 205);
			FairyColor = RGBColor (231, 148, 231);

			List <Color> TypeColorList = new List <Color> ();

			TypeColorList.Add(NormalColor);
			TypeColorList.Add(FireColor);
			TypeColorList.Add(WaterColor);
			TypeColorList.Add(ElectricColor);
			TypeColorList.Add(GrassColor);
			TypeColorList.Add(IceColor);
			TypeColorList.Add(FightingColor);
			TypeColorList.Add(PoisonColor);
			TypeColorList.Add(GroundColor);
			TypeColorList.Add(FlyingColor);
			TypeColorList.Add(PsychicColor);
			TypeColorList.Add(BugColor);
			TypeColorList.Add(RockColor);
			TypeColorList.Add(GhostColor);
			TypeColorList.Add(DragonColor);
			TypeColorList.Add(DarkColor);
			TypeColorList.Add(SteelColor);
			TypeColorList.Add(FairyColor);

			List <string> TypeStringList = new List <string> ();

			TypeStringList.Add(Normal);
			TypeStringList.Add(Fire);
			TypeStringList.Add(Water);
			TypeStringList.Add(Electric);
			TypeStringList.Add(Grass);
			TypeStringList.Add(Ice);
			TypeStringList.Add(Fighting);
			TypeStringList.Add(Poison);
			TypeStringList.Add(Ground);
			TypeStringList.Add(Flying);
			TypeStringList.Add(Psychic);
			TypeStringList.Add(Bug);
			TypeStringList.Add(Rock);
			TypeStringList.Add(Ghost);
			TypeStringList.Add(Dragon);
			TypeStringList.Add(Dark);
			TypeStringList.Add(Steel);
			TypeStringList.Add(Fairy);



		}

	public void	CycleColors()
	{
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				ListPos = TypeColorList.Count;
				ListPos++;
			}
			Image Background =  GameObject.Find("Background").GetComponent<Image>();
			Background.color = TypeColorList[ListPos];
		}	
	}

	}
