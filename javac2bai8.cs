using System.Linq;

import java.util.LinkedList;
import java.util.Queue;

public class IntegerQueue
{
    private Queue<Integer> queue;

    public IntegerQueue()
    {
        queue = new LinkedList<>();
    }

    public boolean isEmpty()
    {
        return queue.isEmpty();
    }

    public void clear()
    {
        queue.clear();
    }

    public void enqueue(int x)
    {
        queue.offer(x);
    }

    public int dequeue()
    {
        if (queue.isEmpty())
        {
            throw new IllegalStateException("Queue is empty");
        }
        return queue.poll();
    }

    public int first()
    {
        if (queue.isEmpty())
        {
            throw new IllegalStateException("Queue is empty");
        }
        return queue.peek();
    }

    public void traverse()
    {
        for (int value : queue)
        {
            System.out.print(value + " ");
        }
        System.out.println();
    }

    public static void convertToBinary(double num)
    {
        if (num < 0 || num >= 1)
        {
            System.out.println("Error: The input number must be between 0 and 1.");
            return;
        }

        Queue<Integer> binaryQueue = new LinkedList<>();
        while (num > 0)
        {
            num *= 2;
            int bit = (int)num;
            binaryQueue.offer(bit);
            num -= bit;
        }

        System.out.print("Binary representation: ");
        while (!binaryQueue.isEmpty())
        {
            System.out.print(binaryQueue.poll());
        }
        System.out.println();
    }

    public static void main(String[] args)
    {
        IntegerQueue queue = new IntegerQueue();

        // Test the queue operations
        System.out.println("Is the queue empty? " + queue.isEmpty());
        queue.enqueue(10);
        queue.enqueue(20);
        queue.enqueue(30);
        System.out.println("Traversing the queue: ");
        queue.traverse();
        System.out.println("First element: " + queue.first());
        System.out.println("Dequeued element: " + queue.dequeue());
        System.out.println("Traversing the queue: ");
        queue.traverse();
        queue.clear();
        System.out.println("Is the queue empty? " + queue.isEmpty());

        // Convert a decimal number to binary
        convertToBinary(0.625);
    }
}