using Stoicode.UniLib.Gui;
using UnityEngine;

public class GuiCore : MonoBehaviour
{
    public GuiViewHandler Views { get; private set; }
    public GuiPopupHandler Popups { get; private set; }
        
        
    public void Initialize()
    {
        Views = new GuiViewHandler(ViewId.Start); // Add view id here for first window to open
        Popups = new GuiPopupHandler();
    }
}

