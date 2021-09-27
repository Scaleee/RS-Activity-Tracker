using Stoicode.UniLib.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubGoalPopup : GuiPopup
{
    public Transform Content;
    public GameObject SubGoalPrefab;
    public TMP_Text ActivityName;
    
    public Transform CloseObject;
    public Button CloseButton;
    public Button Background;

    private ListItem ListItem;

    public void SetListener()
    {
        CloseButton.onClick.AddListener(() => { App.Gui.Popups.Toggle(PopupId.SubGoal, false); });
        Background.onClick.AddListener(() => { App.Gui.Popups.Toggle(PopupId.SubGoal, false); });
    }
    
    public override void Initialize()
    {
        Identifier = PopupId.SubGoal;
        SetListener();
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            App.Gui.Popups.Toggle(PopupId.SubGoal, false);
    }

    public override void Open()
    {
        
    }

    public override void Close()
    {
        // Deletes pop up children so when new one is opened it is not shared/duplicated
        for (var i = 1; i < Content.transform.childCount - 1; i++)
            Destroy(Content.transform.GetChild(i).gameObject);
        
        // Calls TotalGoals to update the counter for tasks completed (x / y)
        // Also calls method to update list regardless if changes are made or not
        ListItem.TotalGoals(true);        
    }

    public void Populate(Activity data, ListItem listItem)
    {
        ActivityName.text = data.Name;

        this.ListItem = listItem; // Not used, need to look into
        
        // Instantiates unity objects for each piece of data in list
        foreach (var s in data.SubGoal)
        {
            var o = Instantiate(SubGoalPrefab, Content, false);
            var subGoalItem = o.GetComponent<SubGoalItem>();
            
            subGoalItem.SubGoalData = s;
            
            subGoalItem.SetListener();
            subGoalItem.SetName();
            subGoalItem.SetWillComplete();
            
            if (s.WillComplete == false)
                continue;
            
            subGoalItem.SetCompleted();
        }
        CloseObject.SetAsLastSibling();
    }
}
