using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private InputReader inputReader;
    [SerializeField] private Canvas pauseMenu;

    private bool isPaused;

    #endregion

    #region Unity Event Funtions

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        inputReader.PauseEvent += HandlePause;
        inputReader.ResumeEvent += HandleResume;
    }

    #endregion

    #region Input Reader Handles

    private void HandlePause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = .0f;
    }

    private void HandleResume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    #endregion
}
