using System;
using System.Globalization;
using UnityEngine;

public class TimeCore : MonoBehaviour
{
    public void SetSavedTime(DateTime time)
    {
        var key = "time-data"; // This can be a public class var too or in a class that holds all save keys
        var timeString = $"{time}"; // Convert DateTime type to String type
        PlayerPrefs.SetString(key, timeString); // Save the converted string to playerprefs using a string key
    }

    public DateTime GetSavedTime()
    {
        var key = "time-data"; // This can be a public class var too or in a class that holds all save keys
        var time = DateTime.UtcNow;
        if (PlayerPrefs.HasKey(key))
        {
            var timeString = PlayerPrefs.GetString(key); // Get converted string from playerprefs using string key
            time = Convert.ToDateTime(timeString); // Convert the string back to DateTime type format
        }

        return time; // Return the saved DateTime object
    }

    public bool ResetCheck(DateTime oldTime, DateTime newTime, byte type)
    {
        switch (type)
        {
            case TypeId.Daily:
                return oldTime.Day != newTime.Day;
            
            case TypeId.Weekly:
                var ci = new CultureInfo("en-US");
                var calendar = ci.Calendar;
                var rule = ci.DateTimeFormat.CalendarWeekRule;
                var fdow = ci.DateTimeFormat.FirstDayOfWeek;

                var oldWeek = calendar.GetWeekOfYear(oldTime, rule, fdow);
                var newWeek = calendar.GetWeekOfYear(newTime, rule, fdow);
                
                return oldWeek != newWeek;
            
            case TypeId.Monthly:
                return oldTime.Month != newTime.Month;
            
            default:
                return false;
        }
    }
}
