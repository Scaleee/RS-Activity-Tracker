using Stoicode.UniLib.Gui;
using UnityEngine;

public class MainView : GuiView
{
    public Transform Content;

    public override void Initialize()
    {
        Identifier = ViewId.Main;
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
        ActivityCore.CreateList(TypeId.All, Content);
    }
}