using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using MessagePack;
using UnityEngine;

public class ActivityCore : MonoBehaviour
{
    public List<Activity> Activities;
    
    public GameObject ListItemPrefab;
    
    public static ActivityCore Instance { get; set; }
    
    private void Awake()
    {
        Instance ??= this;
    }

    public void Initialize()
    {
        // Creates save path for user specific changes (Favorites/Completed/WillComplete)
        var dirPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/RS3 Activity Tracker/";
        Directory.CreateDirectory(dirPath);

        dataFilePath = $"{dirPath}/data.dat";
        
        Load();
        
        // All data for app, organized my TypeId (Daily, Weekly, Monthly)
        Activities ??= new List<Activity>
        {
            #region Dailies
            
            new Activity(TypeId.Daily, ActivityId.AnaBaseCamp, "Anachronia Base Camp", new List<SubGoal>
                {
                    new SubGoal(1, "Check One"),
                    new SubGoal(2, "Check Two"),
                }),

            new Activity(TypeId.Daily, ActivityId.UnchartedIsles, "Uncharted Isles", new List<SubGoal>
                {
                    new SubGoal(1, "Collected Supplies"),
                }),

            new Activity(TypeId.Daily, ActivityId.BigChin, "Big Chin", new List<SubGoal>
                {
                    new SubGoal(1, "Game One"),
                    new SubGoal(2, "Game Two")
                },
                new List<DateTime>
                {
                    new DateTime(1, 1, 1, 0, 30, 0)
                }),

            new Activity(TypeId.Daily, ActivityId.BwTree, "Bloodwood Tree Run", new List<SubGoal>
                {
                    new SubGoal(1, "Pirates' Hideout"),
                    new SubGoal(2, "Demonic Ruins"),
                    new SubGoal(3, "Chaos Temple"),
                    new SubGoal(4, "Manor Farm"),
                    new SubGoal(5, "Soul Wars"),
                    new SubGoal(6, "Ritual Plateau"),
                    new SubGoal(7, "Darkmeyer"),
                    new SubGoal(8, "Gorajo Resource Dungeon")
                    
                }),

            new Activity(TypeId.Daily, ActivityId.Bork, "Bork", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),

            new Activity(TypeId.Daily, ActivityId.Caches, "Guthixian Caches", new List<SubGoal>
                {
                    new SubGoal(1, "Game One"),
                    new SubGoal(1, "Game Two")
                },
                new List<DateTime>
                {
                    new DateTime(1, 1, 1, 0, 0, 0)
                }),
            
            new Activity(TypeId.Daily, ActivityId.CorScarab, "Corrupted Scarabs", new List<SubGoal>
                {
                    new SubGoal(1, "Limit Reached"),
                }),

            new Activity(TypeId.Daily, ActivityId.CrystalTree, "Crystal Tree", new List<SubGoal>
                {
                    new SubGoal(1, "Picked Blossom"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.OutfitClaims, "Skilling Outfit Claims", new List<SubGoal> 
                {
                    new SubGoal(1, "Cooking Outfit"),
                    new SubGoal(2, "Crafting Outfit"),
                    new SubGoal(3, "Divination Outfit"),
                    new SubGoal(4, "Farming Outfit"),
                    new SubGoal(5, "Herblore Outfit"),
                    new SubGoal(6, "Prayer Outfit"),
                    new SubGoal(7, "Smithing Outfit"),
                    new SubGoal(8, "Summoning Outfit"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.Merchant, "Deep Sea Merchant", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.DivLoc, "Divine Locations", new List<SubGoal>
                {
                    new SubGoal(1, "Limit Reached"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.EvilTree, "Evil Tree", new List<SubGoal>
                {
                    new SubGoal(1, "Spawned Daily Tree"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.HerbShop, "Herblore Shop Run", new List <SubGoal>
            {
                new SubGoal(1, "Jatix's Herblore Shop (Taverly)"),
            }),
            
            new Activity(TypeId.Daily, ActivityId.Goebiebands, "Goebie Supply Runs", new List<SubGoal>
                {
                    new SubGoal(1, "Run Completed"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.JackOfTrades, "Jack of Trades", new List<SubGoal>
                {
                    new SubGoal(1, "First Completed"),
                    new SubGoal(1, "Second Completed"),
                    new SubGoal(1, "Third Completed"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.Maw, "Motherload Maw", new List<SubGoal>
                {
                    new SubGoal(1, "Looted"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.Kingdom, "Managing Miscellania", new List<SubGoal>
                {
                    new SubGoal(1, "Upkeep Met"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.NemiForest, "Nemi Forest", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),

            new Activity(TypeId.Daily, ActivityId.NpcRuns, "NPC Runs", new List <SubGoal>
                {
                    new SubGoal(1, "Flax (Geoffrey)"),
                    new SubGoal(2, "Logs (Coeden)"),
                    new SubGoal(3, "Potato Cactus (Weird Old Man)"),
                    new SubGoal(4, "Buckets of Sand (Bert)")
                }),
            
            new Activity(TypeId.Daily, ActivityId.Sandstone, "Sandstone", new List <SubGoal>
                {
                    new SubGoal(1, "Red Sandstone (Sophanem)"),
                    new SubGoal(2, "Red Sandstone (Oo'glog)"),
                    new SubGoal(3, "Crystal-Flecked Sandstone (Prifddinas)")
                }),
            
            new Activity(TypeId.Daily, ActivityId.Ports, "Player-Owned Ports", new List<SubGoal>
                {
                    new SubGoal(1, "Check One"),
                    new SubGoal(1, "Check Two"),
                    new SubGoal(1, "Check Three"),
                    new SubGoal(1, "Check Four")
                    
                }),

            new Activity(TypeId.Daily, ActivityId.Reaper, "Reaper Task", new List<SubGoal>
                {
                    new SubGoal(1, "Task Completed"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.RuneShop, "Rune Shop Run", new List<SubGoal>
            {
                new SubGoal(1, "Magic Guild Store - Runes and Staves (Yanille)"),
                new SubGoal(2, "Baba Yaga's Magic Shop (Lunar Isle)"),
                new SubGoal(3, "Ali's Discount Wares (Al Kharid)"),
                new SubGoal(4, "Lundail's Arena-side Rune Shop (Mage Bank)"),
                new SubGoal(5, "Void Knight Magic Store (Void Knights' Outpost)"),
                new SubGoal(6, "Battle Runes (Near Edgeville Ditch)"),
                new SubGoal(7, "Tutab's Magical Market (Ape Atoll)"),
                new SubGoal(8, "Carwen Essencebinder Magical Runes Shop (Burthorpe)"),
                new SubGoal(9, "Aubury's Rune Shop (Varrock)"),
                new SubGoal(10, "Betty's Magic Emporium (Port Sarim)"),
                new SubGoal(11, "Rune Shop (Anachronia)"),
            }),
            
            new Activity(TypeId.Daily, ActivityId.Runesphere, "Runesphere", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.Sinkholes, "Sinkholes", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),

            new Activity(TypeId.Daily, ActivityId.MeatShop, "Meat Shop Run", new List <SubGoal>
                {
                    new SubGoal(1, "Fresh Meat (Chargurr in Oo'glog)"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.SlayerShop, "Slayer Shop Run", new List <SubGoal>
            {
                new SubGoal(1, "Slayer Equipment Shop (Burthorpe)"),
                new SubGoal(2, "Slayer Equipment Shop (Other)"),
            }),
            
            new Activity(TypeId.Daily, ActivityId.ShootingStar, "Shooting Star", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.SoulObelisk, "Soul Obelisk", new List<SubGoal>
                {
                    new SubGoal(1, "Daily Cap Hit"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.VisWax, "Vis Wax", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.Warbands, "Wilderness Warbands", new List<SubGoal>
                {
                    new SubGoal(1, "25/75 Resources"),
                    new SubGoal(2, "50/75 Resources"),
                    new SubGoal(3, "75/75 Resources"),
                }),
            
            new Activity(TypeId.Daily, ActivityId.WickedHood, "WickedHood", new List<SubGoal>
                {
                    new SubGoal(1, "Free Runes"),
                    new SubGoal(2, "Free Essence"),
                    new SubGoal(3, "Free Teleports")
                }),
        
            #endregion
            
            #region Weeklies

            new Activity(TypeId.Weekly, ActivityId.Agoroth, "Agoroth", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Weekly, ActivityId.Aquarium, "Aquarium", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Weekly, ActivityId.Circus, "Circus", new List <SubGoal>
                {
                    new SubGoal(1, "Agility"),
                    new SubGoal(2, "Magic"),
                    new SubGoal(3, "Ranged"),
                    new SubGoal(4, "Firemaking")
                }),
            
            new Activity(TypeId.Weekly, ActivityId.CourtCases, "Court Cases", new List <SubGoal>
            {
                new SubGoal(1, "Completed"),
            }),
            
            new Activity(TypeId.Weekly, ActivityId.Familiarization, "Famaliarization", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Weekly, ActivityId.HerbyWerby, "Herby Werby", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Weekly, ActivityId.Meg, "Meg", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Weekly, ActivityId.Nomad, "Memory of Nomad", new List<SubGoal>
            {
                new SubGoal(1, "Completed"),
            }),
            
            new Activity(TypeId.Weekly, ActivityId.Penguins, "Penguin Hide n'Seek", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Weekly, ActivityId.PhoenixLair, "Phoenix Lair", new List<SubGoal>
            {
                new SubGoal(1, "Completed"),
            }),
            
            new Activity(TypeId.Weekly, ActivityId.RushOfBlood, "Rush Of Blood", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Weekly, ActivityId.SkeletalHorror, "Skeletal Horror", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Weekly, ActivityId.Statue, "Statue of Dahmaroc", new List<SubGoal>
            {
                new SubGoal(1, "Completed"),
            }),
            
            new Activity(TypeId.Weekly, ActivityId.Tears, "Tears of Guthix", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Weekly, ActivityId.Totems, "Totems of Anachronia", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Weekly, ActivityId.Wisps, "Wisps of the Grove", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),

            #endregion
            
            #region Monthlies
            
            new Activity(TypeId.Monthly, ActivityId.EffigyIncubator, "Effigy Incubator", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),

            new Activity(TypeId.Monthly, ActivityId.GodStatues, "God Statues", new List <SubGoal>
                {
                    new SubGoal(1, "Lumbridge"),
                    new SubGoal(2, "Canifis"),
                    new SubGoal(3, "Yanille"),
                    new SubGoal(4, "Taverly"),
                    new SubGoal(5, "Prifddinas")
                }),
            
            new Activity(TypeId.Monthly, ActivityId.Oyster, "Tutorial Island Oyster", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Monthly, ActivityId.PremierVault, "Premier Vault", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            new Activity(TypeId.Monthly, ActivityId.TrollInvasion, "Troll Invasion", new List<SubGoal>
                {
                    new SubGoal(1, "Completed"),
                }),
            
            #endregion
        };
    }

    public void TimeCheck(DateTime oldTime, DateTime newTime, byte type)
    {
        switch (type)
        {
            // Method is called and calls the same method to check activity type
            case TypeId.All:
                TimeCheck(oldTime, newTime, TypeId.Daily);
                TimeCheck(oldTime, newTime, TypeId.Weekly);
                TimeCheck(oldTime, newTime, TypeId.Monthly);
                break;
            
            // When the method is called again it uses the times and type to check which one needs to
            // or doesnt need to be reset
            default:
                if (App.Time.ResetCheck(oldTime, newTime, type))
                {
                    App.Time.SetSavedTime(newTime);
                    ResetCompleted(type);
                }

                break;
        }
    }

    public void ResetCompleted(byte type)
    {
        // Resets all activities var completed to false
        foreach (var d in Activities.Where(d => d.Type == type))
        {
            d.Completed = false;
            foreach (var s in d.SubGoal)
                s.Completed = false;
        }
        
        // Recreates list with updates values
        App.Gui.Views.Get(App.Gui.Views.ActiveView).CreateList();
    }

    public List<Activity> Generate(byte type)
    {
        // If All page is selected (TypeId.All) print all Activities, else print specific Type activity
        var list = type == TypeId.All
            ? Activities
            : Activities.Where(x => x.Type == type).ToList();

        if (!string.IsNullOrWhiteSpace(TabsMenu.SearchText))
            list = SearchUtils.GetByName(list, TabsMenu.SearchText);
        
        if (TabsMenu.ShowFavorite)
            list = SearchUtils.GetFavorited(list);
        
        if (TabsMenu.ShowCompleted)
            list = SearchUtils.GetCompleted(list);
        
        foreach(var l in list)
            Debug.Log($"{l.Name} : {l.Completed}");

        return list;
    }

    public static void CreateList(byte type, Transform content)
    {
        // Creates a var list organized by name
        var list = App.Activity.Generate(type).OrderBy(x => x.Name).ToList();
        
        // Deletes old list posted in content when clicked back
        if (content.childCount > 0)
            for (var i = 0; i < content.childCount; i++) 
                Destroy(content.GetChild(i).gameObject);
        
        foreach (var a in list)
        {
            var o = Instantiate(Instance.ListItemPrefab, content, false);
            
            var listItem = o.GetComponent<ListItem>();
            
            listItem.ActivityData = a;
            
            listItem.SetName();
            listItem.SetType(a.Type);
            listItem.SetCompleted();
            listItem.SetFavorite();
            listItem.SetListener();
        }
    }
    
    private string dataFilePath;

    public void Load()
    {
        if (!File.Exists(dataFilePath))
            return;

        var raw = File.ReadAllBytes(dataFilePath);
        Activities = MessagePackSerializer.Deserialize<List<Activity>>(raw);
    }

    public void Save()
    {
        var bw = new BackgroundWorker
        {
            WorkerReportsProgress = false,
            WorkerSupportsCancellation = false
        };

        bw.DoWork += (sender, args) =>
        {
            var serialized = MessagePackSerializer.Serialize(Activities);

            File.WriteAllBytes(dataFilePath, serialized);
        };

        bw.RunWorkerAsync();
    }
}