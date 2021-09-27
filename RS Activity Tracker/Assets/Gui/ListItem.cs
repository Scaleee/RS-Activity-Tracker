using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListItem : MonoBehaviour
{
    public TMP_Text Name;
    public Image TypeBox;
    
    public Button PopUpButton;
    public TMP_Text SubGoalText;

    public Button FavoritedButton;
    public Image FavoritedImage;

    public Button CompletedButton;
    public Image CompletedImage;
    
    public Activity ActivityData;

    public void SetListener()
    {
        PopUpButton.onClick.AddListener(CreatePopUp);
        CompletedButton.onClick.AddListener(() => { SetCompleted(true); });
        FavoritedButton.onClick.AddListener(() => { SetFavorite(true); });
    }

    public void CreatePopUp()
    {
        var popup = (SubGoalPopup) App.Gui.Popups.Toggle(PopupId.SubGoal, true);

        popup.Populate(ActivityData, this);
    }
    
    public void SetName()
    {
        name = ActivityData.Name;
        Name.text = ActivityData.Name;
    }
    
    public void SetType(int type)
    {
        TypeBox.color = ColorId.MenuButtons[type + 2];
    }
    
    public void SetCompleted(bool manualClick = false)
    {
        // Creates list and organizes it by name
        //ActivityData = App.Activity.Activities.First(x => x.Name.Equals(Name.text));

        // Might be useless code
        if (ActivityData.SubGoal != null && ActivityData.SubGoal.Count > 1) 
            PopUpButton.gameObject.SetActive(true);

        // If manually pressed button to set goal to complete
        //     - Checks if SubGoal will be completed continue if not
        //     - If it will be, then set it to completed if its not already, break loop once one is updated.
        if (manualClick)
        {
            foreach (var s in ActivityData.SubGoal)
            {
                if (!s.WillComplete)
                    continue;

                if (!s.Completed)
                {
                    s.Completed = true;
                    break;
                }
            }
        }
        // Calls method to update the completed activities displayed (x / y)
        TotalGoals(manualClick);
    }

    public void TotalGoals(bool manualClick)
    {
        int totalGoals = 0;
        int currentGoals = 0;
        bool started = false;

        // Checks total number of goals that will be completed and number of completed goals
        foreach (var s in ActivityData.SubGoal)
        {
            if (s.WillComplete)
            {
                totalGoals++;

                if (s.Completed)
                    currentGoals++;
            }
        }
        
        // If the total goals and current goals are the same set activity to completed
        //     - Disable the button to adjust numbers
        //     - If it was manually pressed create new list in case it is filtered
        // else if more than one goal is complete set it to started (e.g. 1/5)
        // else set it to not started

        ActivityData.Completed = currentGoals >= totalGoals;
        CompletedButton.interactable = !ActivityData.Completed;
        started = currentGoals != totalGoals && currentGoals > 0;

        CompletedImage.color = ActivityData.Completed
            ? ColorId.Status[ColorId.Completed]
            : started
                ? ColorId.Status[ColorId.InProgress]
                : ColorId.Status[ColorId.NotCompleted];

        SubGoalText.text = currentGoals + " / " + totalGoals;
        
        // Saves data after adjusting the goals
        if (manualClick)
        {
            App.Gui.Views.Get(App.Gui.Views.ActiveView).CreateList();
            App.Activity.Save();
        }
    }
    
    public void SetFavorite(bool justCompleted = false)
    {
        // Turns favorite on or off and recreates list when called
        // Recreates list if manually pressed in case it is filtered
        if (justCompleted)
        {
            ActivityData.Favorite = !ActivityData.Favorite;
            App.Gui.Views.Get(App.Gui.Views.ActiveView).CreateList();
        }

        FavoritedImage.color = ActivityData.Favorite
            ? ColorId.Status[ColorId.Favorited]
            : ColorId.Status[ColorId.NotFavorited];

        // Saves data after favoriting or unfavoriting
        App.Activity.Save();
    }
}

