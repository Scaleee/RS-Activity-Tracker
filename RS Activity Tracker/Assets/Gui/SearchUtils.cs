using System.Collections.Generic;
using System.Linq;

public static class SearchUtils
{
    public static List<Activity> GetFavorited(List<Activity> target)
    { 
        return target.Where(x => x.Favorite).ToList();
    }
    
    public static List<Activity> GetCompleted(List<Activity> target)
    { 
        return target.Where(x => !x.Completed).ToList(); 
    }

    public static List<Activity> GetByName(List<Activity> target, string name)
    {
        return target.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
    }
}