using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubGoalItem : MonoBehaviour
{
    public Button CompletedButton;
    public Image CompletedButtonImage;
    public Image CompletedImage;
    
    public Button WillCompleteButton;
    public Image WillCompleteButtonImage;

    public TMP_Text SubGoalName;
    
    public SubGoal SubGoalData;
    
    public void SetListener()
    {
        CompletedButton.onClick.AddListener(() => SetCompleted(true));
        WillCompleteButton.onClick.AddListener(() => { SetWillComplete(true); });
    }
    
    public void SetName()
    {
        name = SubGoalData.Name;
        SubGoalName.text = SubGoalData.Name;
    }

    public void SetWillComplete(bool manualClick = false)
    {
        // If manually pressed to hide or unhide 
        if (manualClick)
        {
            var current = SubGoalData.WillComplete;
            
            // Set WillComplete to opposite 
            SubGoalData.WillComplete = !SubGoalData.WillComplete;

            // If it is set to WillComplete from !WillComplete set SubGoal to not complete and change color of button
            if (!current && SubGoalData.WillComplete)
            {
                SubGoalData.Completed = false;
                CompletedButtonImage.color = ColorId.Status[ColorId.FalseCheck];
            }

            // Saves after recreating list with updated info
            App.Activity.Save();
        }
        
        // Sets complete button active or inactive depending on if user will or will not complete
        CompletedButton.gameObject.SetActive(SubGoalData.WillComplete);

        CompletedImage.color = !SubGoalData.WillComplete
            ? ColorId.Status[ColorId.WillComplete]
            : ColorId.Status[ColorId.NotCompleted];
        
        WillCompleteButtonImage.color = SubGoalData.WillComplete
            ? ColorId.Status[ColorId.HideGoal]
            : ColorId.Status[ColorId.ShowGoal];
        
        SubGoalName.color = SubGoalData.WillComplete
            ? ColorId.Status[ColorId.HideGoal]
            : ColorId.Status[ColorId.ShowGoal];
    }

    public void SetCompleted(bool manualClick = false)
    {
        // if manually pressed set Completed to the opposite
        if (manualClick)
            SubGoalData.Completed = !SubGoalData.Completed;

        CompletedImage.color = SubGoalData.Completed
            ? ColorId.Status[ColorId.Completed]
            : ColorId.Status[ColorId.NotCompleted];
        
        CompletedButtonImage.color = SubGoalData.Completed
            ? ColorId.Status[ColorId.TrueCheck]
            : ColorId.Status[ColorId.FalseCheck];
    }
}
