using System;
using System.Collections.Generic;
using MessagePack;

[MessagePackObject(true)]
public class Activity
    {
        public bool Favorite;
        public bool Completed;
        public int Id;
        public string Name;
        public byte Type;
        public List<SubGoal> SubGoal;
        public List<DateTime> GameTime;
        
        public Activity() { }

        public Activity(byte type, int id, string name, List<SubGoal> subGoal)
        {
            Type = type;
            Id = id;
            Name = name;
            SubGoal = subGoal;
        }

        public Activity(byte type, int id, string name, List<SubGoal> subGoal, List<DateTime> gameTime)
        {
            Type = type;
            Id = id;
            Name = name;
            SubGoal = subGoal;
            GameTime = gameTime;
        }
    }