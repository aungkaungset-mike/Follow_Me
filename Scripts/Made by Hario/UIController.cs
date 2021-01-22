using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// UI Controller made by HarioGames
/// </summary>
public class UIController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button pauseButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button replayButton;
    [SerializeField] Button quitButton;

    [Header("Texts")]
    [SerializeField] Text mainScoreText;
    [SerializeField] Text currentScoreText;
    [SerializeField] Text highScoreText;

    [Header("Panels")]
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;

    private void Start()
    {
        if (pauseButton != null)
            pauseButton.onClick.AddListener(Pause);
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(GoToMainMenu);
        if (resumeButton != null)
            resumeButton.onClick.AddListener(Resume);
        if (restartButton != null)
            restartButton.onClick.AddListener(Replay);
        if (replayButton != null)
            replayButton.onClick.AddListener(Replay);
        if (quitButton != null)
            quitButton.onClick.AddListener(Quit);
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    private void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Load MainMenu
    /// </summary>
    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Pause the game
    /// </summary>
    private void Pause()
    {
        Time.timeScale = 0;

        pauseUI.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    private void Resume()
    {
        pauseButton.gameObject.SetActive(true);
        pauseUI.SetActive(false);

        Time.timeScale = 1;
    }

    /// <summary>
    /// Replay the game
    /// </summary>
    private void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Load active scene
    }

    /// <summary>
    /// Update score text
    /// </summary>
    /// <param name="score">Score</param>
    public void UpdateScoreText(float score)
    {
        mainScoreText.text = "Score : " + score;
    }

    /// <summary>
    /// Show Gameover UI and save highscore
    /// </summary>
    /// <param name="score">Score</param>
    public void ShowGameOverUI(float score)
    {
        float highscore = PlayerPrefs.GetFloat(GamePreferences.HIGHSCORE_KEY);

        if(score > highscore)
        {
            PlayerPrefs.SetFloat(GamePreferences.HIGHSCORE_KEY, score);
            highscore = PlayerPrefs.GetFloat(GamePreferences.HIGHSCORE_KEY);
        }

        currentScoreText.text = "Score : " + score;
        highScoreText.text = "Highscore : " + highscore;
        mainUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
}
