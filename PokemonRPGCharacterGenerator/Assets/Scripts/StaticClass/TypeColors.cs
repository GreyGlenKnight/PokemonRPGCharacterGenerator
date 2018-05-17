using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TypeColors 
{
	public static Color NothingColor = new Color (1f, 1f, 1f, .25f);
    public static Color NormalColor = new Color(0.647f, 0.647f, 0.459f);
    public static Color FireColor = new Color(0.929f, 0.486f, 0.169f);
    public static Color WaterColor = new Color(0.380f, 0.545f, 0.937f);
    public static Color ElectricColor = new Color(0.969f, 0.812f, 0.173f);
    public static Color GrassColor = new Color(0.455f, 0.765f, 0.298f);
    public static Color IceColor = new Color(0.569f, 0.835f, 0.835f);
    public static Color FightingColor = new Color(0.741f, 0.184f, 0.153f);
    public static Color PoisonColor = new Color(0.616f, 0.247f, 0.616f);
    public static Color GroundColor = new Color(0.890f, 0.733f, 0.361f);
    public static Color FlyingColor = new Color(0.651f, 0.561f, 0.925f);
    public static Color PsychicColor = new Color(0.973f, 0.306f, 0.506f);
    public static Color BugColor = new Color(0.643f, 0.702f, 0.122f);
    public static Color RockColor = new Color(0.698f, 0.608f, 0.212f);
    public static Color GhostColor = new Color(0.424f, 0.333f, 0.573f);
    public static Color DragonColor = new Color(0.424f, 0.200f, 0.969f);
    public static Color DarkColor = new Color(0.427f, 0.337f, 0.275f);
    public static Color SteelColor = new Color(0.702f, 0.702f, 0.804f);
    public static Color FairyColor = new Color(0.906f, 0.580f, 0.906f);

	public static string Nothing = "";
    public static string Normal = "Normal";
    public static string Fire = "Fire";
    public static string Water = "Water";
    public static string Electric = "Electric";
    public static string Grass = "Grass";
    public static string Ice = "Ice";
    public static string Fighting = "Fighting";
    public static string Poison = "Poison";
    public static string Ground = "Ground";
    public static string Flying = "Flying";
    public static string Psychic = "Psychic";
    public static string Bug = "Bug";
    public static string Rock = "Rock";
    public static string Ghost = "Ghost";
    public static string Dragon = "Dragon";
    public static string Dark = "Dark";
    public static string Steel = "Steel";
    public static string Fairy = "Fairy";

	public static string [] TypeStringList = new string []
	{
		Nothing,
		Normal,
		Fire,
		Water,
		Electric,
		Grass,
		Ice,
		Fighting,
		Poison,
		Ground,
		Flying,
		Psychic,
		Bug,
		Rock,
		Ghost,
		Dragon,
		Dark,
		Steel,
		Fairy
	};

	public static Color [] TypeColorList = new Color []
	{
		NothingColor,
		NormalColor,
		FireColor,
		WaterColor,
		ElectricColor,
		GrassColor,
		IceColor,
		FightingColor,
		PoisonColor,
		GroundColor,
		FlyingColor,
		PsychicColor,
		BugColor,
		RockColor,
		GhostColor,
		DragonColor,
		DarkColor,
		SteelColor,
		FairyColor
	};

    public static Color RGBColor(float r, float g, float b)
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
}
