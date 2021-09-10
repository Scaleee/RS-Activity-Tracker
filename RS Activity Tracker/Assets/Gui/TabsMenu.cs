using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabsMenu : MonoBehaviour
{
    public Button[] menuButton = new Button[5];
    public TMP_Text[] menuButtonText = new TMP_Text[5];
    public Image[] menuButtonImage = new Image[5];
    public Image[] menuButtonSelected = new Image[5];

    public TMP_InputField SearchBar;
    
    public Button filterFavorite;
    public Image favorite;
    
    public Button filterCompleted;
    public Image completed;

    public static bool ShowFavorite;
    public static bool ShowCompleted;
    public static string SearchText;
    
    private void Start()
    {
        // Add listener to onclick method of each button so that when it clicks a method is called
        // Syntax: buttonvariable.OnClick.AddListener(method);
        // A way of writing a method without writing a full class method is like this: () => { }
        for (int i = 0; i < menuButton.Length; i++)
        { 
            var index = i;
            menuButton[index].onClick.AddListener(() => { ButtonClick(index); });
        }

        SearchBar.onValueChanged.AddListener(SearchEdit);
        filterFavorite.onClick.AddListener(ToggleFavorite);
        filterCompleted.onClick.AddListener(ToggleCompleted);
    }
    
    // When any of the buttons are pressed, this method is called
    private void ButtonClick(int targetViewId)
    {
        App.Gui.Views.Open(targetViewId + 2);

        for (int i = 0; i < menuButton.Length; i++)
        {
            var button = menuButton[i] == menuButton[targetViewId];

            menuButtonText[i].color = button
                ? ColorId.MenuButtons[ColorId.Selected]
                : ColorId.MenuButtons[ColorId.Default];
            
            menuButtonImage[i].color = button 
                ? ColorId.MenuButtons[ColorId.Selected]
                : ColorId.MenuButtons[ColorId.Default];
            
            menuButtonSelected[i].gameObject.SetActive(button);
        }
    }

    public void ToggleFavorite()
    {
        ShowFavorite = !ShowFavorite;
        
        favorite.color = ShowFavorite
            ? ColorId.Status[ColorId.Favorited]
            : ColorId.Status[ColorId.DefaultButton];
        
        App.Gui.Views.Get(App.Gui.Views.ActiveView).CreateList();
    }

    public void ToggleCompleted()
    {
        ShowCompleted = !ShowCompleted;
        
        completed.color = ShowCompleted
            ? ColorId.Status[ColorId.HideCompleted]
            : ColorId.Status[ColorId.DefaultButton];
        
        App.Gui.Views.Get(App.Gui.Views.ActiveView).CreateList();
    }

    public void SearchEdit(string text)
    {
        SearchText = text.ToLower();
        
        App.Gui.Views.Get(App.Gui.Views.ActiveView).CreateList();
    }
}