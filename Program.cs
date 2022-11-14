using System.Text.RegularExpressions;

namespace LinkedList
{
    class Node
    {
        /*Node class reperesents the node of doubly linked list.
          it consist of the information part and links to
          it's succeedind and precceeding
          in terms of next and previous*/
        public int noMhs;
        public string name;
        // poinnt to the succeeding node
        public Node next;
        // poinnt to the precceeding node
        public Node prev;

    }
    class DoubleLinkedList
    {
        Node START;

        // constructor
        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNode()
        {
            int nim;
            string nm;
            Console.Write("Enter the roll number of the sudent: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the ame of the student: ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.noMhs = nim;
            newNode.name = nm;

            // check if the list empty
            if(START == null || nim <= START.noMhs)
            {
                if((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if(START != null)
                    START.prev = newNode;
                newNode.prev = null;
                return;
            }
            /*if the node is to be inserted at between two node*/
            Node previous, current;
            for(current = previous = START;
                current != null && nim >= current.noMhs;
                previous = current, current = current.next)
            {
                if(nim == current.noMhs)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            /*On the execution of the above for loop, prev and
              current will point to those nodes
              between wich the new node is to be inserted*/
            newNode.next = current;
            newNode.prev = previous;

            // if the node is to be inserted at the end of the list
            if(current == null)
            {
                newNode.next = null;
                newNode.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public void search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = START;
                current != null && rollNo != current.noMhs;
                previous = current, current = current.next) { }
            return (current != null);
        }
        public bool dellNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if(search(rollNo, ref previous, ref current) == false)
                return false;
            // the beginning of data
            if(current.next == null)
            {
                previous.next = null;
                return true;
            }
            // node between two nodes in the list 
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}