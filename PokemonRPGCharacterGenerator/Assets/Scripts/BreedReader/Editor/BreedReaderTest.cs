using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;

public class BreedReaderTest 
{

    [Test]
    public void RejectsIndex0()
    {
        PokemonFileReader BreedReader = new PokemonFileReader();
        Pokemon.Breed Bulbasaur = BreedReader.GetItemByID(0);
        Debug.Assert(Bulbasaur == null);
    }

    [Test]
    public void CanReadFile ()
    {
        PokemonFileReader BreedReader = new PokemonFileReader ();
        Pokemon.Breed Bulbasaur = BreedReader.GetItemByID (1);
      
        Debug.Assert (Bulbasaur != null);

    }

    [Test]
    public void First150()
    {
        PokemonFileReader BreedReader = new PokemonFileReader();

        for (int i = 1; i < 151; i++)
        {
            Pokemon.Breed Bulbasaur = BreedReader.GetItemByID(i);

            Debug.Log(Bulbasaur.BreedName);
            Debug.Log(Bulbasaur.Type1.ToString());
            Debug.Log(Bulbasaur.Type2.ToString());
            Debug.Log(Bulbasaur.BreedStatBlock.Attack.RoundedValue);
        }
        //Debug.Assert (Bulbasaur.BreedName != "Bulbasaur");
    }

    //[Test]
    //public void First150LinkedList()
    //{
    //    PokemonFileReader BreedReader = new PokemonFileReader ();
    //    BreedLinkedList list = new BreedLinkedList ();

    //    for (int i = 1; i < 151; i++)
    //    {
        
    //        Pokemon.Breed Ivysaur = BreedReader.GetItemByID (i);
    //        BreedLinkedListNode NodeToAdd = new BreedLinkedListNode (Ivysaur);
    //        list.AddNode (NodeToAdd);
    //        Debug.Log (NodeToAdd.ThisData.BreedName);
    //    }

    //    Debug.Assert (list.Head.ThisData != null);
    //    Debug.Assert(list.Head.ThisData.BreedName == "Bulbasaur");

    //    Debug.Assert (list.LastNode.ThisData.BreedName == "Mewtwo");
    //    Debug.Assert (list.Head.Child.Child.Child.ThisData.BreedName == "Charmander");
    //}

    [Test]
    public void First150SortedLinkedList()
    {
        PokemonFileReader BreedReader = new PokemonFileReader();
        Pokemon.Breed Ivysaur = BreedReader.GetItemByID(1);
        List <Pokemon.Breed> ToPrint = new List<Pokemon.Breed> ();
        SortedLinkedListNode <Pokemon.Breed> _Node = new SortedLinkedListNode <Pokemon.Breed> (Ivysaur, Ivysaur.BreedStatBlock.Attack.RawValue);
        for (int i = 2; i < 152; i++)
        {
           	Ivysaur = BreedReader.GetItemByID(i);                         
             _Node.AddData(Ivysaur, Ivysaur.BreedStatBlock.Attack.RawValue);
		}
		Debug.Log(_Node.ThisData.BreedName);
		_Node.AddToList (ToPrint);
		
		foreach (Pokemon.Breed Mons in ToPrint)
		{		
		Debug.Log(Mons.BreedStatBlock.Attack.RawValue+Mons.BreedName);
		}
		Debug.Log (ToPrint.Count);
	}
    
	[Test]
	public void First150LinkedListReturnsList ()
	{
	 PokemonFileReader BreedReader = new PokemonFileReader();
	 Pokemon.Breed Ivysaur = BreedReader.GetItemByID(1);

	 LinkedListNode <Pokemon.Breed> OGPokemon = new LinkedListNode <Pokemon.Breed> (Ivysaur);
        for (int i = 2; i < 152; i++)
        {
            Ivysaur = BreedReader.GetItemByID(i);
            OGPokemon.AddData(Ivysaur);
        }
        List <Pokemon.Breed> ToPrint = new List <Pokemon.Breed> ();
        OGPokemon.AddToList(ToPrint);
        
		foreach(Pokemon.Breed Mon in ToPrint)
		{		
		Debug.Log (Mon.BreedName);
		}
	}
	
	[Test]
	public void First150LinkedListReturnsRecursiveList ()
	{
	 PokemonFileReader BreedReader = new PokemonFileReader();
	 Pokemon.Breed Mewtwo = BreedReader.GetItemByID(151);

	 LinkedListNode <Pokemon.Breed> OGPokemon = new LinkedListNode <Pokemon.Breed> (Mewtwo);
        for (int i = 150; i > 0; i--)
        {
            Mewtwo = BreedReader.GetItemByID(i);
            OGPokemon.AddData(Mewtwo);
        }
        List <Pokemon.Breed> ToPrint = new List <Pokemon.Breed> ();
        OGPokemon.AddToListRecursive(ToPrint);
        
		foreach(Pokemon.Breed Mon in ToPrint)
		{		
		Debug.Log (Mon.BreedName);
		}
	}

	[Test]
	public void First150LinkedListEnumerator ()
	{
	 PokemonFileReader BreedReader = new PokemonFileReader();
	 Pokemon.Breed Ivysaur = BreedReader.GetItemByID(1);

	 LinkedListNode <Pokemon.Breed> OGPokemon = new LinkedListNode <Pokemon.Breed> (Ivysaur);
        for (int i = 2; i < 152; i++)
        {
            Ivysaur = BreedReader.GetItemByID(i);
            OGPokemon.AddData(Ivysaur);
        }
        
		foreach(Pokemon.Breed Mon in OGPokemon)
		{		
		Debug.Log (Mon.BreedName);
		}
	}

	[Test]
	public void First150BinarySearchTree ()
	{
	PokemonFileReader BreedReader = new PokemonFileReader();
	Pokemon.Breed Ivysaur = BreedReader.GetItemByID(1);
	BinarySearchNode <Pokemon.Breed> OGPokemon = new BinarySearchNode <Pokemon.Breed> (Ivysaur, Ivysaur.BreedStatBlock.Attack.RawValue);
	Debug.Log (OGPokemon.Value+OGPokemon.ThisData.BreedName);


        for (int i = 2; i < 152; i++)
        {
            Ivysaur = BreedReader.GetItemByID(i);
            OGPokemon.AddData (Ivysaur, Ivysaur.BreedStatBlock.Attack.RawValue);
			Debug.Log (Ivysaur.BreedName+Ivysaur.BreedStatBlock.Attack.RawValue);
        }
	List <Pokemon.Breed> BreedList = OGPokemon.GetList();
	foreach (Pokemon.Breed _Breed in BreedList)
		{ 
		Debug.Log (_Breed.BreedName+_Breed.BreedStatBlock.Attack.RawValue);
		}	
	}
	
}
