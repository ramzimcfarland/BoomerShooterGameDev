using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("Arena" + ArenaManager.currentArena);
    }
}
