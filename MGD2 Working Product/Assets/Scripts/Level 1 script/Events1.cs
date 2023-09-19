using UnityEngine.SceneManagement;
using UnityEngine;

public class Events1 : MonoBehaviour
{
    
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
