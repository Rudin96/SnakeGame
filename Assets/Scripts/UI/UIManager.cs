using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text deathText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;

    private SnakeController snakeController;

    private void Start()
    {
        snakeController = GameObject.FindGameObjectWithTag("Player")?.GetComponent<SnakeController>();
        SetPointsText(0, snakeController.Points);
        snakeController.onKilled += EnableDeathUI;
        snakeController.onPointsChanged += SetPointsText;
        restartButton.onClick.AddListener(RestartLevel);
        menuButton.onClick.AddListener(LoadMainMenu);
        quitButton.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void SetPointsText(int prevValue, int nextValue)
    {
        pointsText.text = $"Points: {nextValue}";
    }

    async void EnableDeathUI()
    {
        highScoreText.text = $"Current High Score: {await ScoreManager.Instance.GetHighScore()}";
        highScoreText.gameObject.SetActive(true);
        deathText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
