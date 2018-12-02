using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

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

    [Test]
    public void First150LinkedList()
    {
        PokemonFileReader BreedReader = new PokemonFileReader ();
        BreedLinkedList list = new BreedLinkedList ();

        for (int i = 1; i < 151; i++)
        {
        
            Pokemon.Breed Ivysaur = BreedReader.GetItemByID (i);
            BreedLinkedListNode NodeToAdd = new BreedLinkedListNode (Ivysaur);
            list.AddNode (NodeToAdd);
            Debug.Log (NodeToAdd.ThisData.BreedName);
        }

        Debug.Assert (list.Head.ThisData != null);
        Debug.Assert(list.Head.ThisData.BreedName == "Bulbasaur");

        Debug.Assert (list.LastNode.ThisData.BreedName == "Mewtwo");
        Debug.Assert (list.Head.Child.Child.Child.ThisData.BreedName == "Charmander");
    }

    [Test]
    public void First150SortedLinkedList()
    {
        PokemonFileReader BreedReader = new PokemonFileReader();
        BreedSortedLinkedList list = new BreedSortedLinkedList();

        for (int i = 1; i < 151; i++)
        {
            Pokemon.Breed Ivysaur = BreedReader.GetItemByID(i);
            BreedSortedLinkedListNode NodeToAdd = new BreedSortedLinkedListNode(Ivysaur,
                                                                                Ivysaur.BreedStatBlock.Attack.RawValue);
            list.AddNode(NodeToAdd);
        }
        Debug.Log(list.Head.Value + list.LastNode.Value);

    }
}
