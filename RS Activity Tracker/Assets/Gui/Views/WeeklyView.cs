using Stoicode.UniLib.Gui;
using UnityEngine;

public class WeeklyView: GuiView
{
    public Transform Content;

    public override void Initialize()
    {
        Identifier = ViewId.Weekly;
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
        ActivityCore.CreateList(TypeId.Weekly, Content);
    }
}