using UnityEngine;

public class BreedLinkedList
{
    public BreedLinkedListNode Head;
    public BreedLinkedListNode LastNode;

    public BreedLinkedList()
    {

    }


    public BreedLinkedListNode FindEmptyNode()
    {

        Debug.Log("Attempting to Find Empty Node");
        return LastNode;

    }

    public bool HasChild(BreedLinkedListNode Node)
    {
        return Node.Child != null;
    }

    public void AddNode(BreedLinkedListNode NodeToAdd)
    {
        Debug.Log("Attempting to add node" + NodeToAdd.ToString());

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
