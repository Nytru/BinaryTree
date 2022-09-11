namespace BinaryTree_Branch;

internal class Branch <T>
{
    public Branch()
    {
        Value = default;
    }

    internal void SetToParent(Branch<T> value)
    {
        if (Parent.LeftBranch != null && Parent.LeftBranch.Equals(this))
        {
            Parent.LeftBranch = value;
        }
        else if (Parent.RightBranch != null && Parent.RightBranch.Equals(this))
        {
            Parent.RightBranch = value;
        }
        else
        {
            throw new InvalidOperationException("SetToParent exception");
        }
    }

    internal void Delete()
    {
        SetToParent(null);
    }

    public Branch(T value)
    {
        Value = value;
    }
    public Branch<T>? Parent { get; set; } = null;

    public Branch<T>? LeftBranch { get; set; } = null;

    public Branch<T>? RightBranch { get; set; } = null;

    public T? Value { get; set; } = default;
}
