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

//public class BinarySearchNode <T>
//{
//    public T Parent { get; private set; }

//    public T ThisNode { get; private set; }

//    public T ChildLower { get; private set; }

//    public T ChildHigher { get; private set; }

//public int Value {get; private set;}


//    public BinarySearchNode (T StartingData)
//    {
//        ThisNode = StartingData;
//    }

//    public void SetParentNode (T ParentNode)
//    {
//        Parent = ParentNode;
//    }

//    public void SetLesserChildNode (T LesserChildNode)
//    {

//    }

//    public void SetGreaterChildNode (T GreaterChildNode)
//    {

//    }
//}

//public class BinarySearchTree <T>
//{
//    public BinarySearchNode <T> Head { get; private set; }



//    public BinarySearchTree (T StartingNode)
//    {
//        Head = new BinarySearchNode (StartingNode.ThisNode);
//    }

//    public void AddNode (BinarySearchNode NodeToAdd, 
//                         BinarySearchNode ParentNode)
//    {
//        NodeToAdd.SetParentNode (ParentNode);
//    }

//    public BinarySearchNode FindValidNode ()
//    {
//        return Head;
//    }
//}



public class BreedSortedLinkedListNode : BreedLinkedListNode
{
    public int Value { get; private set; }
    new public BreedSortedLinkedListNode Child { get; private set; }


    new public void SetChildNode(BreedLinkedListNode ToSet)
    {
        Debug.Log("Don't call this function, it has the wrong parameters");
        return;
    }

    public void SetChildNode(BreedSortedLinkedListNode ToSet)
    {
        Child = ToSet;
    }

    public BreedSortedLinkedListNode (Pokemon.Breed _Data, int _Value) : base (_Data)
    {
        Value = _Value;
    }
}

public class BreedSortedLinkedList : BreedLinkedList
{
    new public BreedSortedLinkedListNode Head;
    new public BreedSortedLinkedListNode LastNode;

    public BreedSortedLinkedList()
    {

    }

    new public BreedSortedLinkedListNode FindEmptyNode()
    {
        Debug.Log("Attempting to Find Empty Node");
        return LastNode;
    }

    public bool HasChild (BreedSortedLinkedListNode Node)
    {
        return Node.Child != null;
    }

    public bool IsGreater (int _Value, 
                           BreedSortedLinkedListNode ToCompare)
    {
        return _Value >= ToCompare.Value;
    }

    //new public void AddNode (BreedLinkedListNode NodeToAdd)
    //{
    //    Debug.Log("We don't want this function being called with the wrong type");
    //    return;
    //}

    public void AddNode (BreedSortedLinkedListNode NodeToAdd, int _Value)
    {
        //We want to iterate through the list until a node returns greater, then add node in place. The node with no child is LastNode;
        Debug.Log("Attempting to add node" + NodeToAdd.ToString());

        if (Head == null)
        {
            Head = NodeToAdd;
            LastNode = Head;
            Debug.Log("Assigning the Head");
            return;
        }

        BreedSortedLinkedListNode Temp = Head;

        if (IsGreater(Temp.Value, 
                      NodeToAdd))
        {
            Head = NodeToAdd;
            Head.SetChildNode (Temp);
            return;
        }

        BreedSortedLinkedListNode TempChild = Temp.Child;

        while (IsGreater(TempChild.Value, 
                         NodeToAdd) == true)
        {
            Temp = TempChild;
            TempChild = Temp.Child;

            if (IsGreater(Temp.Value,
                          NodeToAdd)== true && 
                IsGreater(NodeToAdd.Value,
                          TempChild) == false)
            {
                Temp.SetChildNode(NodeToAdd);
                NodeToAdd.SetChildNode(TempChild);
            }
        }

        if (HasChild (NodeToAdd) == false)
        { NodeToAdd = LastNode; }
    }
}


public class BreedLinkedListNode
{
    public Pokemon.Breed ThisData { get; private set; }
    public BreedLinkedListNode Child { get; private set; }

    public BreedLinkedListNode (Pokemon.Breed Data)
    {
        ThisData = Data;
    }

    public void SetChildNode (BreedLinkedListNode ToSet)
    {
        Child = ToSet;
    }
}



public class BreedLinkedList
{
    public BreedLinkedListNode Head;
    public BreedLinkedListNode LastNode;

    public BreedLinkedList ()
    {
     
    }


    public BreedLinkedListNode FindEmptyNode()
    {

        Debug.Log("Attempting to Find Empty Node");
        return LastNode;

    }

    public bool HasChild (BreedLinkedListNode Node)
    {
        return Node.Child != null;
    }

    public void AddNode (BreedLinkedListNode NodeToAdd)
    {
        Debug.Log("Attempting to add node"+NodeToAdd.ToString());

        if (Head == null)
        {
            Head = NodeToAdd;
            Debug.Log("Assigning the Head");
            LastNode = Head;
            return;
        }

        BreedLinkedListNode Temp = FindEmptyNode();
        Temp.SetChildNode(NodeToAdd);
        LastNode = NodeToAdd;
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