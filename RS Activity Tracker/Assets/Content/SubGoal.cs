using MessagePack;

[MessagePackObject(true)]
public class SubGoal
{
    public bool Completed;
    public bool WillComplete = true;
    public int Index;
    public string Name;

    public SubGoal() { }
    
    public SubGoal(int index, string name)
    {
        Index = index;
        Name = name;
    }
}