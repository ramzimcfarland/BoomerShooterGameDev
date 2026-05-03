using UnityEngine;
using System;
public static class ArenaManager
{
    public static int currentArena = 1;
    public static int maxArena = 3;

    [SerializeField]private static LightTrigger lightTrigger;

    public static void ClearArena()
    {
        currentArena++;
        //win game
        if (LightTrigger.isTriggered)
        {
            Debug.Log("won!");
            //OnGameWin?.Invoke();
            UIScreenManager.Instance?.HandleGameWin();
            Debug.Log($"Game Won!");
            SoundManager.StopMusic();
            SoundManager.PlaySound(SoundType.WINGAME);
        }
        // clear arena but not win game
        else if (currentArena <= maxArena)
        {
            Debug.Log($"Cleared arena {currentArena - 1}!");
            //OnArenaCleared?.Invoke();
            UIScreenManager.Instance?.HandleArenaCleared();
            SoundManager.StopMusic();
            SoundManager.PlaySound(SoundType.WINLEVEL);
        }
    }


}
