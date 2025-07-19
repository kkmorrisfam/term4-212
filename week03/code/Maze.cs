/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        //get the value for left        
        bool[] directions = _mazeMap[(_currX, _currY)];  // Get the bool[] array for the key (X, Y)
        bool nextDirection = directions[0]; // Access the first element of the array for left
        // if value is true
        if (nextDirection)
        {
            // decrement x
            _currX -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }       
        
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        //get the value for right        
        bool[] directions = _mazeMap[(_currX, _currY)];  // Get the bool[] array for the key (X, Y)
        bool nextDirection = directions[1]; // Access the 2nd element of the array for right
        //if value is true....
        if (nextDirection)
        {
            //increment x
            _currX += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {

        //get the value for Up        
        bool[] directions = _mazeMap[(_currX, _currY)];  // Get the bool[] array for the key (X, Y)
        bool nextDirection = directions[2]; // Access the element in array for Up
        //if value is true....
        if (nextDirection)
        {
            //decrement Y
            _currY -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }


    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        //get the value for Down        
        bool[] directions = _mazeMap[(_currX, _currY)];  // Get the bool[] array for the key (X, Y)
        bool nextDirection = directions[3]; // Access the element in array for Down
        //if value is true....
        if (nextDirection)
        {
            //Increment Y
            _currY += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }

    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}