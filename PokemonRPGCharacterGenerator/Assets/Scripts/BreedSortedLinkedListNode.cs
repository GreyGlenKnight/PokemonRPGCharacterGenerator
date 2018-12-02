using UnityEngine;
public class BinarySearchNode <T>
{
    public T Parent { get; private set; }

    public T ThisNode { get; private set; }

    public T ChildLower { get; private set; }

    public T ChildHigher { get; private set; }

public int Value {get; private set;}


    public BinarySearchNode (T StartingData)
    {
        ThisNode = StartingData;
    }

    public void SetParentNode (T ParentNode)
    {
        Parent = ParentNode;
    }

    public void SetLesserChildNode (T LesserChildNode)
    {

    }

    public void SetGreaterChildNode (T GreaterChildNode)
    {

    }
}

public class BinarySearchTree <T>
{
    public BinarySearchNode <T> Head { get; private set; }



    public BinarySearchTree (T StartingNode)
    {
        Head = new BinarySearchNode (StartingNode.ThisNode);
    }

    public void AddNode (BinarySearchNode NodeToAdd, 
                         BinarySearchNode ParentNode)
    {
        NodeToAdd.SetParentNode (ParentNode);
    }

    public BinarySearchNode FindValidNode ()
    {
        return Head;
    }
}



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

    public BreedSortedLinkedListNode(Pokemon.Breed _Data, int _Value) : base(_Data)
    {
        Value = _Value;
    }
}
