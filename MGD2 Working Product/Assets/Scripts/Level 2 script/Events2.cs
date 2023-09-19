using UnityEngine.SceneManagement;
using UnityEngine;

public class Events2 : MonoBehaviour
{
    
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
