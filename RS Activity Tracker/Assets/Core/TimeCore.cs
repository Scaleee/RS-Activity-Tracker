using System;
using System.Globalization;
using UnityEngine;

public class TimeCore : MonoBehaviour
{
    
    public void SetSavedTime(DateTime time)
    {
        // This can be a public class var too or in a class that holds all save keys
        var key = "time-data"; 
        
        // Converts DateTime type to String type
        var timeString = $"{time}"; 
        
        // Savse the converted string to playerprefs using a string key
        PlayerPrefs.SetString(key, timeString); 
    }

    public DateTime GetSavedTime()
    {
        // This can be a public class var too or in a class that holds all save keys
        var key = "time-data";
        var time = DateTime.UtcNow;
        
        if (PlayerPrefs.HasKey(key))
        {
            // Gets converted string from playerprefs using string key
            var timeString = PlayerPrefs.GetString(key); 
            
            // Converts the string back to DateTime type format
            time = Convert.ToDateTime(timeString); 
        }

        return time;
    }

    public bool ResetCheck(DateTime oldTime, DateTime newTime, byte type)
    {
        switch (type)
        {
            // If oldTime.Day is a different day than the current day then return true
            case TypeId.Daily:
                return oldTime.Day != newTime.Day;
            
            // If it is wednesday and it is a different week, then return true
            case TypeId.Weekly:
                var ci = new CultureInfo("en-US");
                var calendar = ci.Calendar;
                var rule = ci.DateTimeFormat.CalendarWeekRule;
                var fdow = ci.DateTimeFormat.FirstDayOfWeek;

                var oldWeek = calendar.GetWeekOfYear(oldTime, rule, fdow);
                var newWeek = calendar.GetWeekOfYear(newTime, rule, fdow);

                return newTime.DayOfWeek == DayOfWeek.Wednesday && oldWeek != newWeek;
            
            // If it is a new month then return true
            case TypeId.Monthly:
                return oldTime.Month != newTime.Month;
            
            default:
                return false;
        }
    }
}
