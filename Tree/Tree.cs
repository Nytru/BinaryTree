using BinaryTree_Branch;

namespace BinaryTree;

public sealed class Tree<T>
    where T : IComparable<T>
{
    public Tree(){}

    public long Count { get; private set; }

    internal Branch<T>? _root = null;
    public void Add(T value)
    {
        if (_root == null)
        {
            Count = 1;
            _root = new Branch<T>();
            _root.Value = value;
        }
        else
            Add(value, _root);
        return;
    }

    private void Add(T value, Branch<T> currentBranch)
    {
        switch (currentBranch.Value!.CompareTo(value))
        {
            case 0:
                break;
            case > 0:
                if (currentBranch.LeftBranch == null)
                {
                    Count++;
                    currentBranch.LeftBranch = new Branch<T>(value);
                    currentBranch.LeftBranch.Parent = currentBranch;
                }
                else
                    Add(value, currentBranch.LeftBranch);
                break;
            case < 0:
                if (currentBranch.RightBranch == null)
                {
                    Count++;
                    currentBranch.RightBranch = new Branch<T>(value);
                    currentBranch.RightBranch.Parent = currentBranch;
                }
                else
                    Add(value, currentBranch.RightBranch);
                break;
        }
        return;
    }

    public bool Contains(T value)
    {
        if (_root == null)
            return false;
        else 
            return Contains(value, _root);
    }

    private bool Contains(T value, Branch<T> currentBranch)
    {
        switch (value.CompareTo(currentBranch.Value))
        {
            case 0:
                return true;
            case > 0:
                if (currentBranch.RightBranch != null)
                    return Contains(value, currentBranch.RightBranch);
                else
                    return false;                    
            case < 0:
                if (currentBranch.LeftBranch != null)
                    return Contains(value, currentBranch.LeftBranch);
                else
                    return false;
        }
    }

    /// <summary>
    /// Removes element equals to input value
    /// </summary>
    /// <param name="value">Input value to remove</param>
    /// <returns>Returns positive if remove sucsessfull. Zero if tree is empty. Negative if there was an error (less probably)</returns>
    /// <exception cref="Exception"></exception>
    public int Remove(T value)
    {
        if (_root == null)
        {
            return 0;
        }
        if (value.Equals(_root.Value))
        {
            _root = null;
            Count = 0;
            return 0;
        }

        var currentBranch = Find(value, _root);
        if (currentBranch != null)
        {
            if (currentBranch.LeftBranch == null && currentBranch.RightBranch == null)
            { 
                currentBranch.Delete();
                Count--;
            }
            else if (currentBranch.LeftBranch == null && currentBranch.RightBranch != null)
            {
                currentBranch.RightBranch.Parent = currentBranch.Parent;
                currentBranch.SetToParent(currentBranch.RightBranch);
                Count--;
            }
            else if (currentBranch.RightBranch == null && currentBranch.LeftBranch != null)
            {
                currentBranch.LeftBranch.Parent = currentBranch.Parent;
                currentBranch.SetToParent(currentBranch.LeftBranch);
                Count--;
            }
            else if (currentBranch.RightBranch != null && currentBranch.LeftBranch != null)
            {
                var last = FindLastLeft(currentBranch.RightBranch);
                if (last.RightBranch == null)
                {
                    currentBranch.Value = last.Value;
                    last.Delete();
                }
                else
                {
                    last.RightBranch.Parent = last.Parent;
                    last.SetToParent(last.RightBranch);
                    currentBranch.Value = last.Value;
                }
                Count--;
            }
            else
            {
                throw new Exception("Removing cases exeption");
            }
            return 1;
        }
        else
        {
            return -1;
        }
    }

    private Branch<T> FindLastLeft(Branch<T> rightBranchOfDelitingItem)
    {
        if (rightBranchOfDelitingItem.LeftBranch == null)
        {
            return rightBranchOfDelitingItem;
        }
        return FindLastLeft(rightBranchOfDelitingItem.LeftBranch);
    }

    private Branch<T>? Find(T value, Branch<T> currentBranch)
    {
        switch (value.CompareTo(currentBranch.Value))
        {
            case 0:
                return currentBranch;
            case > 0:
                if (currentBranch.RightBranch != null)
                    return Find(value, currentBranch.RightBranch);
                else
                    return null;
            case < 0:
                if (currentBranch.LeftBranch != null)
                    return Find(value, currentBranch.LeftBranch);
                else
                    return null;
        }
    }
}
