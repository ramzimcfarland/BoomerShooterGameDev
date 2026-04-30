public static class GameState
{
    private static bool isPaused = false;

    public static void pause(bool paused)
    {
        isPaused = paused;
    }

    public static bool IsGamePaused()
    {
        return isPaused;
    }
}
