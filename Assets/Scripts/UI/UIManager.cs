using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text deathText;
    [SerializeField] private Button restartButton;

    private SnakeController snakeController;

    private void Start()
    {
        snakeController = GameObject.FindGameObjectWithTag("Player")?.GetComponent<SnakeController>();
        SetPointsText(0, snakeController.Points);
        snakeController.onKilled += EnableDeathUI;
        snakeController.onPointsChanged += SetPointsText;
        restartButton.onClick.AddListener(RestartLevel);
    }

    void SetPointsText(int prevValue, int nextValue)
    {
        pointsText.text = $"Points: {nextValue}";
    }

    void EnableDeathUI()
    {
        highScoreText.text = $"High Score: {ScoreManager.Instance.GetHighScore()}";

        highScoreText.gameObject.SetActive(true);
        deathText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
