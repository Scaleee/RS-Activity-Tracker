using System;
using System.Collections;
using UnityEngine;

// TODO:
//    Add Penguin locations, possibly sync up to W60Pengs website
//    Auto Updater
//    Add more ways to sort
//        - By Name, Type, Completed
//    Detailed popup for when information is updated
//    Reset Button
//    Safety net for edge cases like opened in a month on same day etc.
//    Create Text File

public class App : MonoBehaviour
{
    public static GuiCore Gui;
    public static ActivityCore Activity;
    public static TimeCore Time;

    public static DateTime StartTime;
    public static DateTime PreviousTime;

    // Start is called before the first frame update
    private void Start()
    {
        Gui = GetComponent<GuiCore>();
        Gui.Initialize();

        Activity = GetComponent<ActivityCore>();
        Activity.Initialize();

        Time = GetComponent<TimeCore>();
        
        PreviousTime = Time.GetSavedTime();
        StartTime = DateTime.UtcNow;
        Activity.TimeCheck(PreviousTime, DateTime.UtcNow, TypeId.All);

        StartCoroutine(nameof(Tick));
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    public IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.6f);

            Activity.TimeCheck(StartTime, DateTime.UtcNow, TypeId.All);
            StartTime = DateTime.UtcNow;
        }
    }

    private void OnApplicationQuit()
    {
        Time.SetSavedTime(DateTime.UtcNow);
    }
}