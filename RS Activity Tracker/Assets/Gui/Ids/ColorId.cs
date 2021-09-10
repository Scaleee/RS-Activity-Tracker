using System.Collections.Generic;
using UnityEngine;

public static class ColorId
{
    public const int Default = 10;
    public const int Selected = 11;

    public static readonly Dictionary<int, Color> MenuButtons = new Dictionary<int, Color>()
    {
        {ViewId.Main, new Color(1f, .645f, .306f, 1f)},
        {ViewId.Daily, new Color(.291f, .783f, .449f, 1f)},
        {ViewId.Weekly, new Color(.233f, .37f, .867f, 1f)},
        {ViewId.Monthly, new Color(.5f, .3f, .9f, 1f)},
        {ViewId.Settings, new Color(1f, 1f, 1f, 1f)},
        {Default, new Color(.545f, .569f, .659f, .3f)},
        {Selected, UniColor.HexToColor("FFAE62", 200)},
    };


    public const int WillComplete = 0;
    public const int Completed = 1;
    public const int NotCompleted = 2;
    public const int InProgress = 3;
    public const int Favorited = 4;
    public const int NotFavorited = 5;
    public const int TrueCheck = 6;
    public const int FalseCheck = 7;
    public const int HideGoal = 8;
    public const int ShowGoal = 9;
    public const int DefaultButton = 10;
    public const int HideCompleted = 11;

    public static readonly Dictionary<int, Color> Status = new Dictionary<int, Color>()
    {
        {WillComplete, UniColor.HexToColor("AAAAB0", 25)},
        {Completed, UniColor.HexToColor("66CC66", 50)},
        {NotCompleted, UniColor.HexToColor("BE1515D", 25)},
        {InProgress, UniColor.HexToColor("D0961D", 50)},
        {Favorited, UniColor.HexToColor("FFAE62", 160)},
        {NotFavorited, UniColor.HexToColor("33334C", 255)},
        {TrueCheck, UniColor.HexToColor("66CC66", 50)},
        {FalseCheck, UniColor.HexToColor("E06767", 50)},
        {HideGoal, UniColor.HexToColor("B2B2C1", 255)},
        {ShowGoal, UniColor.HexToColor("454D5E", 255)},
        {DefaultButton, UniColor.HexToColor("5D5E66", 255)},
        {HideCompleted, UniColor.HexToColor("8A3B3C", 255)},
    };
}
