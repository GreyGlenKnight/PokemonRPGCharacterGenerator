using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class Move
{ 
public enum TowerID { Left, Middle, Right}
public TowerID Start;
public TowerID End;
public string Instruction;

public Move (TowerID _Start, TowerID _End)
{
Start = _Start;
End = _End;
Instruction = _Start.ToString()+" to "+_End.ToString();
}

}



public class TowersProblem

{
	public Tower TowerOne;
	public Tower TowerTwo;
	public Tower TowerThree;
	
	private int NumberOfStones;
	public int Counter;

	public TowersProblem (int numberOfStones)
	{	
		TowerOne = new Tower ();
		TowerTwo = new Tower ();
		TowerThree = new Tower ();
		TowerOne.SpawnStones (numberOfStones);
		NumberOfStones = numberOfStones;
	}


	public void MoveStone (Tower Source, 
		Tower Recipient)
	{
		try
		{Recipient.PlaceStone (Source); }
		catch (Exception e) 
		{Debug.Log ("Exception!!!" + e.ToString()); return; }	
		Counter++;
	}	

	public bool IsSolved ()
	{
		if (TowerOne.Stones.Count == 0 && TowerTwo.Stones.Count == 0)
		return true;
		else return false;
	}

	public void MoveBiggest ()
	{ 
		if (TowerOne.TopStone == null || TowerTwo.TopStone == null || TowerThree.TopStone == null)
		{
			if (NumberOfStones % 2 == 0)
			{MoveStone (LargestStone().GetTower, TowerTwo); }
			else 
			{MoveStone (LargestStone().GetTower, TowerThree); }

		}
	}

	public Stone LargestStone ()
	{
		List <Stone> temp = new List <Stone> ();
		if (TowerOne.TopStone != null)
		{temp.Add(TowerOne.TopStone);}
		if (TowerTwo.TopStone != null)
		{temp.Add(TowerTwo.TopStone);}
		if (TowerThree.TopStone != null)
		{temp.Add(TowerThree.TopStone);}
		
		if (temp.Count == 0)
			{
			Debug.Log ("There are no stones!");
			throw new Exception ();
			}

		Stone LargestAvailable = temp [0];
		
		for (int i = 0; i < temp.Count; i++)
		{
			if (temp[i].Size > LargestAvailable.Size)
			{LargestAvailable = temp [i];}
		}

		return LargestAvailable;
	}

	public void MoveOther ()
	{
		


	}

	public List <Move> Solve (int _NumberOfStones, 
									Move.TowerID _Start, 
										Move.TowerID _End)
	{ 
		List <Move> ToReturn = new List <Move> ();

		if (_NumberOfStones <= 0)
			{return ToReturn; }

		
		int Number = _NumberOfStones -1;

		ToReturn.AddRange (Solve (Number,
								_Start,
									NotThis (_Start, _End)));

		ToReturn.Add (new Move (_Start, _End));

		ToReturn.AddRange (Solve (Number,
								NotThis (_Start, _End),
									_End));
		return ToReturn;
	}



	public Move.TowerID NotThis (Move.TowerID _One, 
										Move.TowerID _Two)
	{
		if (_One != Move.TowerID.Left && _Two != Move.TowerID.Left)
			{return Move.TowerID.Left; }

		if (_One != Move.TowerID.Middle && _Two != Move.TowerID.Middle)
			{return Move.TowerID.Middle; }

		if (_One != Move.TowerID.Right && _Two != Move.TowerID.Right)
			{return Move.TowerID.Right; }
		else throw new Exception ();
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
		foreach (Stone stone in stones)
		{stone.SetTower (this);}
	}

	public void PlaceStone (Tower Source)
	{
		if (TopStone == null && Source.TopStone != null)
		{
			Stone temp = Source.TopStone;
			Source.stones.Remove (Source.TopStone);
			stones.Add (temp); 
			temp.SetTower (this);
			return;
		}
		
		if (Source.TopStone.IsSmaller (TopStone))
		{
			Stone temp = Source.TopStone;
			Source.stones.Remove (Source.TopStone);
			stones.Add (temp); 
			temp.SetTower (this);
			return;
		}
		else {throw new Exception();}
	}

	//We want to use a stack structure for the stones
	
}

public class Stone
{
private int size;
private Tower tower;

	public Stone (int _Size)
	{
		size = _Size;
	}

	public Tower GetTower
	{
		get	
		{
			return tower;
		} 
	}

	public int Size
	{
		get
		{
			return size;
		}
	}

	public void SetTower (Tower ToSet)
	{tower = ToSet;}

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

}