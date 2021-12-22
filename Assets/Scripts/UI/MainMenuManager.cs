using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuUI;
    [SerializeField] private Canvas optionsUI;

    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private Button optBackButton;
    [SerializeField] private Dropdown resDropdown;
    [SerializeField] private Dropdown qualityDropdown;
    [SerializeField] private Toggle fullscreenToggle;

    List<Resolution> resolutions;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(ShowOptionsMenu);
        quitButton.onClick.AddListener(QuitGame);
        optBackButton.onClick.AddListener(ShowMainMenu);

        resDropdown.onValueChanged.AddListener(UpdateResolution);
        qualityDropdown.onValueChanged.AddListener(ChangeQuality);
        fullscreenToggle.onValueChanged.AddListener(ChangeFullscreenState);

        InitGraphicsSettings();
    }

    private void ChangeFullscreenState(bool val)
    {
        Settings.FullScreen = val;
    }

    private void ChangeQuality(int index)
    {
        Settings.SetQualityLevel(index);
    }

    private void UpdateResolution(int index)
    {
        Settings.SetResolution(resolutions[index].width, resolutions[index].height);
    }

    void InitGraphicsSettings()
    {
        resolutions = Screen.resolutions.ToList();
        List<Dropdown.OptionData> resOptions = new List<Dropdown.OptionData>();
        resolutions.ForEach(resolution => resOptions.Add(new Dropdown.OptionData(resolution.ToString())));
        resDropdown.AddOptions(resOptions);
        resDropdown.value = resOptions.FindIndex(r => r.text.Contains($"{Settings.ResX} x {Settings.ResY}"));
        qualityDropdown.value = Settings.GetSettings().GraphicsQuality;
        fullscreenToggle.isOn = Settings.FullScreen;
        Settings.InitSettings();
    }

    void StartGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void ShowOptionsMenu()
    {
        mainMenuUI.gameObject.SetActive(false);
        optionsUI.gameObject.SetActive(true);
    }

    void ShowMainMenu()
    {
        mainMenuUI.gameObject.SetActive(true);
        optionsUI.gameObject.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
