using UnityEngine;

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

    public bool HasChild(BreedSortedLinkedListNode Node)
    {
        return Node.Child != null;
    }

    public bool IsGreater(int _Value,
                           BreedSortedLinkedListNode ToCompare)
    {
        return _Value >= ToCompare.Value;
    }

    //new public void AddNode (BreedLinkedListNode NodeToAdd)
    //{
    //    Debug.Log("We don't want this function being called with the wrong type");
    //    return;
    //}

    public void AddNode(BreedSortedLinkedListNode NodeToAdd, int _Value)
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
            Head.SetChildNode(Temp);
            return;
        }

        BreedSortedLinkedListNode TempChild = Temp.Child;

        while (IsGreater(TempChild.Value,
                         NodeToAdd) == true)
        {
            Temp = TempChild;
            TempChild = Temp.Child;

            if (IsGreater(Temp.Value,
                          NodeToAdd) == true &&
                IsGreater(NodeToAdd.Value,
                          TempChild) == false)
            {
                Temp.SetChildNode(NodeToAdd);
                NodeToAdd.SetChildNode(TempChild);
            }
        }

        if (HasChild(NodeToAdd) == false)
        { NodeToAdd = LastNode; }
    }
}
