using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

//public enum FashionStyle
//{
//	None,
//	Cool,
//	Clever,
//	Cute,
//	Beauty,
//	Tough
//}

public class Doodad
{
	private Image BaseSprite;
	private string Name;
//	private FashionStyle StyleType;
	private Transform Position;
	private bool IsHeldItem;
//	private Color [] CustomPalette = new Color [];
//	private PolygonCollider2D TransparencyMask;
//	We want custom properties somehow, like matching sets and
//	NPC recognition.

	//We probably want an interface to allow these to stack on any object 
	//using the custom palette and transform 

	public Doodad ()
	{
	}

//	public Doodad (Image _BaseSprite)
//	{
//		BaseSprite = _BaseSprite;
//	}

//	public Doodad (HeldItem _HeldItem)
//	{
//		Name = _HeldItem.Name;
//		BaseSprite = _HeldItem.BaseSprite;
//		FashionStyle = FashionStyle.None;
//		IsHeldItem = true;
//	}

//	public void ApplyCustomColors (Color [] _CustomPalette)
//	{
//		CustomPalette = _CustomPalette;
//	}

//	public void RepositionDoodad (Transform _Transform)
//	{
//		Position = _Transform;
//	}
}


