using UnityEngine;
using System;
public static class ArenaManager
{
    public static int currentArena = 1;
    public static int maxArena = 1;

    // public static event Action OnArenaCleared;
    // public static event Action OnGameWin;

    public static void ClearArena()
    {
        currentArena++;
        if (currentArena > maxArena)
        {
            //OnGameWin?.Invoke();
            UIScreenManager.Instance?.HandleGameWin();
            Debug.Log($"Game Won!");
        }
        else
        {
            Debug.Log($"Cleared arena {currentArena - 1}!");
            //OnArenaCleared?.Invoke();
            UIScreenManager.Instance?.HandleArenaCleared();
        }
    }


}
