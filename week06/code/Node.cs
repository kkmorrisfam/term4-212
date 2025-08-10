using System.ComponentModel.DataAnnotations;

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
        // TODO Start Problem 1
        if (value == Data) return;
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
        // TODO Start Problem 2
        //base case
        if (value == Data)         
            return true;
        
        if (value < Data) //call Contains to run check on value == Data
        {
            //check left            
            if (Left is not null)
            {
                return Left.Contains(value); 
            }
            else
            {
                return false;
            }
            // if (Left is null) return false;
            // else Left.Contains(value);       
        
        }
        else if (value > Data)
        {
            //check right side
            if (Right is not null)
            {
                return Right.Contains(value);
            }
            else
            {
                return false;
            }
        }
       return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        //base case - if the tree has no children, height = 1; return 1
        if ((Left is null) && (Right is null)) return 1;

        int leftHeight = 0;
        int rightHeight = 0;
        //if left node is not null, call height on left node, store height, call contains?
        if (Left is not null)
        {
            //ask child for height;
            leftHeight = Left.GetHeight();
            
        }

        //if right node is not null, call height on right node, store height? 

        if (Right is not null)
        {
            rightHeight = Right.GetHeight();
        }

        //compare right and left height to see which is bigger and keep the larger
        // add 1, then return the number

        return 1 + Math.Max(leftHeight, rightHeight);

            //return 0; // Replace this line with the correct return statement(s)
    }
}