using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Menu Panels")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    [Header("Main Menu Buttons")]
    public Button playButton;
    public Button settingsButton;
    public Button exitButton;

    [Header("Settings Buttons")]
    public Button backFromSettingsButton;
    public Slider volumeSlider;
    public Toggle soundToggle;

    [Header("Game Settings")]
    public string gameSceneName = "GameScene";

    private void Start()
    {
        // Initialize menu
        ShowMainMenu();
        SetupButtonListeners();
        LoadSettings();
    }

    private void SetupButtonListeners()
    {
        // Main menu buttons
        playButton.onClick.AddListener(PlayGame);
        settingsButton.onClick.AddListener(ShowSettings);
        exitButton.onClick.AddListener(ExitGame);

        // Settings buttons
        backFromSettingsButton.onClick.AddListener(ShowMainMenu);
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        soundToggle.onValueChanged.AddListener(OnSoundToggled);
    }

    public void PlayGame()
    {
        // Add fade out animation here if desired
        SceneManager.LoadScene(gameSceneName);
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;
        SaveSettings();
    }

    private void OnSoundToggled(bool isOn)
    {
        AudioListener.pause = !isOn;
        SaveSettings();
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
        PlayerPrefs.SetInt("SoundEnabled", AudioListener.pause ? 0 : 1);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        bool soundEnabled = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;

        AudioListener.volume = savedVolume;
        AudioListener.pause = !soundEnabled;

        if (volumeSlider != null)
            volumeSlider.value = savedVolume;

        if (soundToggle != null)
            soundToggle.isOn = soundEnabled;
    }
}