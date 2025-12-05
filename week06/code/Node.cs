public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // If the value already exists in the tree, don't insert it
        if (value == Data)
        {
            return;
        }
        
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }
        
        if (value < Data)
        {
            // Search in the left subtree
            return Left?.Contains(value) ?? false;
        }
        else
        {
            // Search in the right subtree
            return Right?.Contains(value) ?? false;
        }
    }

    public int GetHeight()
    {
        // Base case: if this is a leaf node, return 1
        if (Left is null && Right is null)
        {
            return 1;
        }
        
        // Recursive case: 1 + maximum height of left or right subtree
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}