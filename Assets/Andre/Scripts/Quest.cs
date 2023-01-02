using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    // Properties
    public string objective;
    public Vector2 objectiveLocation;
    public Dialog[] initialDialogs;
    private int currentDialog = 0;

    public void GoNextDialog() => currentDialog++;

    public void GoPreviousDialog() => currentDialog--;

    public Dialog GetCurrentDialog() => initialDialogs[currentDialog];

    public string GetPageCounter() => $"{currentDialog + 1}/{initialDialogs.Length}";

    public bool IsLastDialog() => currentDialog == initialDialogs.Length - 1;

    public bool IsFirstDialog() => currentDialog == 0;

    public void ResetQuest() => currentDialog = 0;
}
