using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField] private Scene _mainScene;

    public void ResumeTime()
    {
        Time.timeScale = 1.0f;
    }

    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
