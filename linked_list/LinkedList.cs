using System;

namespace linked_list
{
    class Node
    {
        internal int data;
        internal Node next;

        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }

    class LinkedList
    {
        Node head;

        internal void InsertFront(int data)
        {
            Node node = new Node(data);
            node.next = head;
            head = node;
        }

        internal void InsertLast(int data)
        {
            Node node = new Node(data);

            if (head == null)
            {
                head = node;
                return;
            }
            Node lastNode = GetLastNode();
            lastNode.next = node;
        }

        internal Node GetLastNode()
        {
            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        internal void InsertAfter(int key, int data)
        {
            Node prevNode = null;

            for (Node temp = head; temp != null; temp = temp.next)
            {
                if (temp.data == key)
                {
                    prevNode = temp;
                    break;
                }
            }
            if (prevNode == null)
            {
                Console.WriteLine("Data is not in the list.");
                return;
            }
            Node node = new Node(data);
            node.next = prevNode.next;
            prevNode.next = node;
        }

        internal Node FindNode(int key)
        {
            Node node = null;

            for (Node temp = head; temp.next != null; temp = temp.next)
            {
                if (temp.data == key)
                {
                    node = temp;
                    return node;
                }
            }
            Console.WriteLine("Data is not in the list.");
            return null;
        }

        internal void DeleteNode(int key)
        {
            Node temp = head;
            Node prev = null;

            //if head.data == key
            if (temp != null && temp.data == key)
            {
                head = temp.next;
                return;
            }

            while (temp != null && temp.data != key)
            {
                prev = temp;
                temp = temp.next;
            }

            //끝까지 찾는 값이 없는 경우
            if (temp == null)
            {
                Console.WriteLine("Data: {0} is not in the list.", key);
                return;
            }

            prev.next = temp.next;
        }

        internal void Reverse()
        {
            Node prev = null;
            Node current = head;
            Node temp = null;

            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            head = prev;
        }

        internal void Print()
        {
            for (Node node = head; node != null; node = node.next)
            {
                Console.Write(node.data + " -> ");
            }
            Console.WriteLine();
        }
    }
}