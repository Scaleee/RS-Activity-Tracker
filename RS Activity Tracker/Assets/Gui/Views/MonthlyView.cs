using Stoicode.UniLib.Gui;
using UnityEngine;

public class MonthlyView : GuiView
{
    public Transform Content;

    public override void Initialize()
    {
        Identifier = ViewId.Monthly;
    }

    public override void Open()
    {
        CreateList();
    }

    public override void Close()
    {
    }

    public override void CreateList()
    {
        ActivityCore.CreateList(TypeId.Monthly, Content);
    }
}