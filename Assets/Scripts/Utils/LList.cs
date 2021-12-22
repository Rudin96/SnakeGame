using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LList<T> : IEnumerable<T>
{
    private T [] items;

    private LListNode<T> head;

    private int count;
    public int Count { get => count; }
    public T Last => GetLastNode().Value;

    public void AddLast(T data)
    {
        LListNode<T> node = new LListNode<T> (data);
        if(head == null)
        {
            head = node;
            count++;
            return;
        }
        LListNode<T> lastNode = GetLastNode();
        lastNode.NextItem = node;
        count++;
    }

    public void AddFirst(T data)
    {
        LListNode<T> tempNode = new LListNode<T>(data);
        tempNode.NextItem = head;
        head = tempNode;
        count++;
    }

    public void Remove(T key)
    {
        LListNode<T> tempNode = head;
        LListNode<T> prevNode = null;

        if(tempNode != null && tempNode.Value.Equals(key))
        {
            head = tempNode.NextItem;
            count--;
            return;
        }
        while(tempNode != null && !tempNode.Value.Equals(key))
        {
            prevNode = tempNode;
            tempNode = tempNode.NextItem;
        }
        if (tempNode == null) return;

        prevNode.NextItem = tempNode.NextItem;
        count--;
    }

    public void AddAfter(LListNode<T> prevNode, T data)
    {
        if(prevNode == null)
        {
            Debug.Log("Previous Node can not be null!");
            return;
        }
        LListNode<T> newNode = new LListNode<T>(data);
        newNode.NextItem = prevNode.NextItem;
        prevNode.NextItem = newNode;
        count++;
    }

    public LListNode<T> GetLastNode()
    {
        LListNode<T> nextNode = head;
        while (nextNode.NextItem != null)
        {
            nextNode = nextNode.NextItem;
        }
        return nextNode;
    }

    private void GetAndExportAllNodes()
    {
        items = new T[count];
        int counter = 0;
        LListNode<T> nextNode = head;
        if(nextNode == null) return;

        if (nextNode.NextItem == null)
        {
            items[counter] = nextNode.Value;
            return;
        }

        while (nextNode.NextItem != null)
        {
            if(counter == 0)
            {
                items[counter] = head.Value;
            }
            items[++counter] = nextNode.NextItem.Value;
            nextNode = nextNode.NextItem;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        GetAndExportAllNodes();
        return ((IEnumerable<T>)items).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        GetAndExportAllNodes();
        return items.GetEnumerator();
    }
}

public class LListNode<T>
{
    public LListNode(T data)
    {
        Value = data;
    }
    public T Value { get; set; }
    public LListNode<T> NextItem { get; set; }
}