using UnityEngine.SceneManagement;
using UnityEngine;

public class Events3 : MonoBehaviour
{
    
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
