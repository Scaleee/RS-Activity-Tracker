using Stoicode.UniLib.Gui;
using UnityEngine;

public class DailyView : GuiView
{    
    public Transform Content;

    public override void Initialize()
    {
        Identifier = ViewId.Daily;
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
        ActivityCore.CreateList(TypeId.Daily, Content);
    }
}

