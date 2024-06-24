using System.Text;

import java.util.EmptyStackException;

public class IntegerStack
{
    private int[] stack;
    private int top;

    public IntegerStack()
    {
        stack = new int[100]; // Khởi tạo ngăn xếp với kích thước 100
        top = -1; // Khởi tạo đỉnh ngăn xếp là -1 (rỗng)
    }

    // 1. boolean isEmpty() - trả về true nếu ngăn xếp là trống và false nếu ngược lại
    public boolean isEmpty()
    {
        return top == -1;
    }

    // 2. void clear() - xóa sạch ngăn xếp
    public void clear()
    {
        top = -1;
    }

    // 3. void push(int x) - chèn một nút có giá trị x vào đỉnh của ngăn xếp
    public void push(int x)
    {
        if (top >= stack.length - 1)
        {
            throw new StackOverflowError("Stack is full");
        }
        stack[++top] = x;
    }

    // 4. int pop() - loại bỏ phần tử ở đỉnh ngăn xếp và trả về giá trị của nó; ném ra EmptyStackException nếu ngăn xếp rỗng
    public int pop()
    {
        if (isEmpty())
        {
            throw new EmptyStackException();
        }
        return stack[top--];
    }

    // 5. int top() - trả về giá trị của một nút ở đỉnh của ngăn xếp; ném ra EmptyStackException nếu ngăn xếp rỗng
    public int top()
    {
        if (isEmpty())
        {
            throw new EmptyStackException();
        }
        return stack[top];
    }

    // 6. void traverse() - hiển thị tất cả các giá trị trong ngăn xếp từ đỉnh đến đáy
    public void traverse()
    {
        if (isEmpty())
        {
            System.out.println("Stack is empty");
        }
        else
        {
            System.out.print("Stack: ");
            for (int i = top; i >= 0; i--)
            {
                System.out.print(stack[i] + " ");
            }
            System.out.println();
        }
    }

    // 7. Sử dụng một ngăn xếp để chuyển đổi một số nguyên từ hệ thập phân sang hệ nhị phân và hiển thị trên màn hình
    public static void convertToBinary(int decimal)
    {
        IntegerStack stack = new IntegerStack();
        while (decimal > 0)
        {
            stack.push(decimal % 2);
            decimal /= 2;
        }
        System.out.print("Binary representation: ");
        while (!stack.isEmpty())
        {
            System.out.print(stack.pop());
        }
        System.out.println();
    }

    // 8. Sử dụng một ngăn xếp thực hiện đảo ngược một xâu ký tự
    public static String reverseString(String input)
    {
        IntegerStack stack = new IntegerStack();
        for (int i = 0; i < input.length(); i++)
        {
            stack.push(input.charAt(i));
        }
        StringBuilder output = new StringBuilder();
        while (!stack.isEmpty())
        {
            output.append((char)stack.pop());
        }
        return output.toString();
    }

    public static void main(String[] args)
    {
        // Ví dụ sử dụng các phương thức của ngăn xếp
        IntegerStack stack = new IntegerStack();
        stack.push(1);
        stack.push(2);
        stack.push(3);
        stack.traverse(); // Output: Stack: 3 2 1
        System.out.println("Top element: " + stack.top()); // Output: Top element: 3
        System.out.println("Popped element: " + stack.pop()); // Output: Popped element: 3
        stack.traverse(); // Output: Stack: 2 1

        // Chuyển đổi số 2024 từ hệ thập phân sang hệ nhị phân
        convertToBinary(2024); // Output: Binary representation: 11111100000

        // Đảo ngược chuỗi "CNTT"
        String input = "CNTT";
        String reversed = reverseString(input);
        System.out.println("Reversed string: " + reversed); // Output: Reversed string: TTNC
    }
}