using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;
using System.Linq;

public class TowersProblemTests

{
	[Test]
    public void CreatesSingleStone ()
    {
        TowersProblem Puzzle = new TowersProblem (1);
		Debug.Assert (Puzzle != null);
		Debug.Assert (Puzzle.TowerOne != null);
		Debug.Assert (Puzzle.TowerTwo != null);
		Debug.Assert (Puzzle.TowerThree != null);
		Debug.Assert (Puzzle.TowerOne.Stones != null);
		Debug.Assert (Puzzle.TowerTwo.Stones != null);
		Debug.Assert (Puzzle.TowerThree.Stones != null);
		Debug.Assert (Puzzle.TowerOne.TopStone != null);
		Debug.Assert (Puzzle.TowerOne.Stones.Count == 1);
//the second 2 towers should be empty
		//Debug.Assert (Puzzle.TowerTwo.TopStone == null);
		//Debug.Assert (Puzzle.TowerThree.TopStone == null);
		Debug.Assert (Puzzle.TowerTwo.Stones.Count == 0);
		Debug.Assert (Puzzle.TowerThree.Stones.Count == 0);
//
    }

	[Test]
    public void MoveSingleStone ()
    {
        TowersProblem Puzzle = new TowersProblem (1);
		Puzzle.MoveStone (Puzzle.TowerOne, Puzzle.TowerTwo);
		Debug.Assert (Puzzle.TowerTwo.TopStone != null);
		Debug.Assert (Puzzle.TowerOne.TopStone == null);
    }

	[Test]
    public void MoveMultipleStones ()
    {
        TowersProblem Puzzle = new TowersProblem (2);
		Puzzle.MoveStone (Puzzle.TowerOne, Puzzle.TowerTwo);
		try
		{Puzzle.MoveStone (Puzzle.TowerOne, Puzzle.TowerTwo);}
		catch (Exception e)
		{Debug.Assert (e != null);}

		Debug.Assert (Puzzle.TowerTwo.Stones.Count == 1);
    }

	
	//[Test]
  //  public void PuzzleCompleted ()
  //  {
  //      TowersProblem Puzzle = new TowersProblem (5);
		//Puzzle.Solve ();

		//Debug.Assert (Puzzle.TowerOne.Stones.Count == 0);
		//Debug.Assert (Puzzle.TowerTwo.Stones.Count == 0);
		//Debug.Assert (Puzzle.TowerThree.Stones.Count == 5);

		
    //}


[Test]
    public void PuzzleCompleted ()
    {
		TowersProblem Puzzle = new TowersProblem (5);
		List <Move> Temp = Puzzle.Solve (5, Move.TowerID.Middle, Move.TowerID.Right);

		{Debug.Log (Temp.Count);}

		for (int i = 0; i < Temp.Count; i++)
{Debug.Log (Temp[i].Instruction);}
    }
}