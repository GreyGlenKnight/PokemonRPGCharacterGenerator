using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class TowersProblem

{
	public Tower TowerOne;
	public Tower TowerTwo;
	public Tower TowerThree;

	public TowersProblem (int NumberOfStones)
	{	
		TowerOne = new Tower ();
		TowerTwo = new Tower ();
		TowerThree = new Tower ();
		TowerOne.SpawnStones (NumberOfStones);
	}

	public void MoveStone (Tower Source, 
		Tower Recipient)
	{
		try
		{Recipient.PlaceStone (Source); }
		catch (Exception e) 
		{Debug.Log ("Exception!!!" + e.ToString()); return; }	 
	}	
}

public class Tower
{
	private List <Stone> stones;
	public List <Stone> Stones {get {return stones; } }

	public Stone TopStone 
	{ 
		get {if (Stones.Count < 1)
		{return null;} 
		else return stones [stones.Count -1];}
	}

	public Tower ()
	{
		stones = new List<Stone> ();
	}

	public void SpawnStones (int StoneCount)
	{
		for (int i = StoneCount; i > 0; i--)
			{
				stones.Add (new Stone (i));
			}
	}

	public void PlaceStone (Tower Source)
	{
		if (TopStone == null && Source.TopStone != null)
		{
			Stone temp = Source.TopStone;
			Source.stones.Remove (Source.TopStone);
			stones.Add (temp); 
			return;
		}
		
		if (Source.TopStone.IsSmaller (TopStone))
		{
			Stone temp = Source.TopStone;
			Source.stones.Remove (Source.TopStone);
			stones.Add (temp); 
			return;
		}
		else {throw new Exception();}
	}

	//We want to use a stack structure for the stones
	
}

public class Stone
{
private int size;

	public Stone (int _Size)
	{
		size = _Size;
	}

	public int Size
	{
		get
		{
			return size;
		}
	}


	public bool IsSmaller (Stone Other)
	{
		if (Other.Size > Size)
		{return true;}
		else return false;
	}

	//public void Place ()
	//{
		
	//}
}

