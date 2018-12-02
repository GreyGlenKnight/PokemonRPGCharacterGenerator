using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public class FileReader <T>
{
    public List <T> DataItems = new List <T> ();

    public FileReader (string path, 
        string FileName,
            Func <string [], T> FactoryMethod)
    {
        string [] Lines = File.ReadAllLines (Path.Combine (path, FileName));

        foreach (string Line in Lines)
        {
            string [] Tokens = Line.Split(',');
            DataItems.Add (FactoryMethod (Tokens));
        }
    }

    public T GetItemByID (int IDNumber)
    {
        return DataItems [IDNumber];
    }
}

public class PokedexLinkedList
{
    public BreedLinkedList Pokedex;

    public void First150()
    {
        PokemonFileReader BreedReader = new PokemonFileReader();

        for (int i = 1; i < 151; i++)
        {
            Pokemon.Breed Bulbasaur = BreedReader.GetItemByID(i);
            Pokedex.AddNode (new BreedLinkedListNode(Bulbasaur));
        }
    }
}

public class BreedBinarySearchNode
{
    public BreedBinarySearchNode Parent { get; private set; }

    public Pokemon.Breed ThisData { get; private set; }

    public int Value { get; private set; }

    public BreedBinarySearchNode ChildLower { get; private set; }

    public BreedBinarySearchNode ChildHigher { get; private set; }



    public BreedBinarySearchNode (Pokemon.Breed _StartingData, int _Value)
    {
        ThisData = _StartingData;
        Value = _Value;
    }

    public void SetChildNode (BreedBinarySearchNode NodeToAdd)
    {
        if (NodeToAdd.Value > Value)
        {
            SetGreaterChildNode (NodeToAdd);
            NodeToAdd.SetParentNode (this);
        }
        else
        {
            SetLesserChildNode (NodeToAdd);
            NodeToAdd.SetParentNode (this);
        }
    }


    public void SetParentNode(BreedBinarySearchNode ParentNode)
    {
        Parent = ParentNode;
    }

    public void SetLesserChildNode (BreedBinarySearchNode LesserChildNode)
    {
        ChildLower = LesserChildNode;
    }

    public void SetGreaterChildNode (BreedBinarySearchNode GreaterChildNode)
    {
        ChildHigher = GreaterChildNode;
    }
}

public class BreedBinarySearchTree
{
    public BreedBinarySearchNode Head { get; private set; }

    public BreedBinarySearchTree ()
    { 
    
    }

    public void AddNode (BreedBinarySearchNode ToAdd)
    {
        //BreedBinarySearchNode Temp = Head;
        //while (Temp != null)
        //{ 
        //    Temp = Temp.ChildNode(); 
        //    if (Temp == null)
        //    {
        //        (ToAdd);
        //    }
        //}
    }
}

public class PokeDexSearchTree
{
    public List <Pokemon.Breed> BreedsToDisplay = new List <Pokemon.Breed>();
    public BreedBinarySearchTree PokedexTree;

    public PokeDexSearchTree ()
    {
        First150 ();
    }

    public void First150 ()
    {
        PokemonFileReader BreedReader = new PokemonFileReader();

        for (int i = 1; i < 151; i++)
        {
            Pokemon.Breed Bulbasaur = BreedReader.GetItemByID(i);
            PokedexTree.AddNode (new BreedBinarySearchNode (Bulbasaur, Bulbasaur.BreedStatBlock.Attack.RawValue));
        }
    }
    
    public void DisplayHighestAttack ()
    {
        
    }
}





public class PokemonFileReader : FileReader <Pokemon.Breed>
{
    private const string path = "Assets/BreedData";
    private const string FileName = "Breeds.csv";

    public PokemonFileReader () : base (path, FileName, FactoryMethod)
    {

    }

    private static Pokemon.Breed FactoryMethod (string [] Tokens)
    {
        if (Tokens [0].Equals ("Pokemon"))
        {
            return null;
        }
        
        string _BreedName = Tokens[0];
        int NationalPokedexNumber = int.Parse(Tokens[1]);
        ElementTypes ElementType1 = (ElementTypes) int.Parse(Tokens[3]);
        ElementTypes ElementType2 = (ElementTypes) int.Parse(Tokens[4]);
        int Endurance = int.Parse(Tokens[5]);
        int Attack = int.Parse(Tokens[6]);
        int Defense = int.Parse(Tokens[7]);
        int SpecialAttack = int.Parse(Tokens[8]);
        int SpecialDefense = int.Parse(Tokens[9]);
        int Speed = int.Parse(Tokens[10]);

        Pokemon.Breed ToReturn = new Pokemon.Breed (ElementType1,
                        ElementType2)
        {
            BreedName = _BreedName,

            BreedStatBlock = new BreedStatBlock(Endurance,
                                                      Attack,
                                                      Defense,
                                                      SpecialAttack,
                                                      SpecialDefense,
                                                      Speed)
        };

        return ToReturn;
    }
}