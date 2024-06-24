class Node
{
    int data;
    Node next;

    Node(int x)
    {
        data = x;
        next = null;
    }
}

class LinkedList
{
    Node head;

    // 1. void addToHead(int x)
    void addToHead(int x)
    {
        Node newNode = new Node(x);
        newNode.next = head;
        head = newNode;
    }

    // 2. void addToTail(int x)
    void addToTail(int x)
    {
        Node newNode = new Node(x);
        if (head == null)
        {
            head = newNode;
            return;
        }
        Node last = head;
        while (last.next != null)
        {
            last = last.next;
        }
        last.next = newNode;
    }

    // 3. void addAfter(Node p, int x)
    void addAfter(Node p, int x)
    {
        if (p == null)
        {
            return;
        }
        Node newNode = new Node(x);
        newNode.next = p.next;
        p.next = newNode;
    }

    // 4. void traverse()
    void traverse()
    {
        Node current = head;
        while (current != null)
        {
            System.out.print(current.data + " ");
            current = current.next;
        }
        System.out.println();
    }

    // 5. int deleteFromHead()
    int deleteFromHead()
    {
        if (head == null)
        {
            return -1;
        }
        int value = head.data;
        head = head.next;
        return value;
    }

    // 6. int deleteFromTail()
    int deleteFromTail()
    {
        if (head == null)
        {
            return -1;
        }
        if (head.next == null)
        {
            int value = head.data;
            head = null;
            return value;
        }
        Node current = head;
        while (current.next.next != null)
        {
            current = current.next;
        }
        int value = current.next.data;
        current.next = null;
        return value;
    }

    // 7. int deleteAfter(Node p)
    int deleteAfter(Node p)
    {
        if (p == null || p.next == null)
        {
            return -1;
        }
        int value = p.next.data;
        p.next = p.next.next;
        return value;
    }

    // 8. void delete(int x)
    void delete(int x)
    {
        if (head == null)
        {
            return;
        }
        if (head.data == x)
        {
            head = head.next;
            return;
        }
        Node current = head;
        while (current.next != null)
        {
            if (current.next.data == x)
            {
                current.next = current.next.next;
                return;
            }
            current = current.next;
        }
    }

    // 9. Node search(int x)
    Node search(int x)
    {
        Node current = head;
        while (current != null)
        {
            if (current.data == x)
            {
                return current;
            }
            current = current.next;
        }
        return null;
    }

    // 10. int count()
    int count()
    {
        int count = 0;
        Node current = head;
        while (current != null)
        {
            count++;
            current = current.next;
        }
        return count;
    }

    // 11. void delete(int i)
    void delete(int i)
    {
        if (head == null)
        {
            return;
        }
        if (i == 0)
        {
            head = head.next;
            return;
        }
        Node current = head;
        for (int j = 0; j < i - 1 && current.next != null; j++)
        {
            current = current.next;
        }
        if (current.next != null)
        {
            current.next = current.next.next;
        }
    }

    // 12. void sort()
    void sort()
    {
        Node current = head;
        while (current != null)
        {
            Node min = current;
            Node r = current.next;
            while (r != null)
            {
                if (r.data < min.data)
                {
                    min = r;
                }
                r = r.next;
            }
            int x = current.data;
            current.data = min.data;
            min.data = x;
            current = current.next;
        }
    }

    // 13. void delete(Node p)
    void delete(Node p)
    {
        if (head == null || p == null)
        {
            return;
        }
        if (head == p)
        {
            head = head.next;
            return;
        }
        Node current = head;
        while (current != null)
        {
            if (current.next == p)
            {
                current.next = p.next;
                return;
            }
            current = current.next;
        }
    }

    // 14. int[] toArray()
    int[] toArray()
    {
        int[] arr = new int[count()];
        Node current = head;
        int i = 0;
        while (current != null)
        {
            arr[i++] = current.data;
            current = current.next;
        }
        return arr;
    }

    // 15. Merge two sorted linked lists
    static LinkedList merge(LinkedList l1, LinkedList l2)
    {
        LinkedList result = new LinkedList();
        Node p1 = l1.head;
        Node p2 = l2.head;
        while (p1 != null && p2 != null)
        {
            if (p1.data < p2.data)
            {
                result.addToTail(p1.data);
                p1 = p1.next;
            }
            else
            {
                result.addToTail(p2.data);
                p2 = p2.next;
            }
        }
        while (p1 != null)
        {
            result.addToTail(p1.data);
            p1 = p1.next;
        }
        while (p2 != null)
        {
            result.addToTail(p2.data);
            p2 = p2.next;
        }
        return result;
    }

    // 16. void addBefore(Node p, int x)
    void addBefore(Node p, int x)
    {
        if (p == null || head == null)
        {
            return;
        }
        if (head == p)
        {
            addToHead(x);
            return;
        }
        Node newNode = new Node(x);
        Node current = head;
        while (current.next != null)
        {
            if (current.next == p)
            {
                newNode.next = p;
                current.next = newNode;
                return;
            }
            current = current.next;
        }
    }

    // 17. Concatenate two linked lists
    void concatenate(LinkedList l2)
    {
        if (head == null)
        {
            head = l2.head;
            return;
        }
        Node current = head;
        while (current.next != null)
        {
            current = current.next;
        }
        current.next = l2.head;
    }

    // 18. int max()
    int max()
    {
        if (head == null)
        {
            return -1;
        }
        int max = head.data;
        Node current = head.next;
        while (current != null)
        {
            if (current.data > max)
            {
                max = current.data;
            }
            current = current.next;
        }
        return max;
    }

    // 19. int min()
    int min()
    {
        if (head == null)
        {
            return -1;
        }
        int min = head.data;
    }
        return max;
    }
   //20.int min()
        int min()
        {
            Node current = head;
            int min = current.data;
            while (current != null)
            {
                if (current.data < min)
                {
                    min = current.data;
                }
                current = current.next;
            }
            return min;
        }
//21.int sum()
int sum()
{
    Node current = head;
    int sum = 0;
    while (current != null)
    {
        sum += current.data;
        current = current.next;
    }
    return sum;
}
//22.int avg()
int avg()
{
    int sum = sum();
    int count = 0;
    Node current = head;
    while (current != null)
    {
        count++;
        current = current.next;
    }
    return sum / count;
}
//23 boolean sorted()
boolean sorted()
{
    Node current = head;
    if (current == null || current.next == null)
    {
        return true; // Danh sách rỗng hoặc chỉ có 1 phần tử
    }
    while (current.next != null)
    {
        if (current.data > current.next.data)
        {
            return false;
        }
        current = current.next;
    }
    return true;
}
//24void insert(int x)
void insert(int x)
{
    Node newNode = new Node(x);
    if (head == null || x < head.data)
    {
        newNode.next = head;
        head = newNode;
        return;
    }
    Node current = head;
    while (current.next != null && x > current.next.data)
    {
        current = current.next;
    }
    newNode.next = current.next;
    current.next = newNode;
}
//25.Dao nguoc danh sach
void reverse()
{
    Node prev = null;
    Node curr = head;
    while (curr != null)
    {
        Node next = curr.next;
        curr.next = prev;
        prev = curr;
        curr = next;
    }
    head = prev;
}