using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject buttonsWindow;

    [Header("Start Game")]
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private Button startButton;

    [Header("Settings")]
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private Button openSettingsButton;
    [SerializeField] private Button closeSettingsButton;

    [Header("Authors")]
    [SerializeField] private GameObject authorsWindow;
    [SerializeField] private Button openAuthorsButton;
    [SerializeField] private Button closeAuthorsButton;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);

        openSettingsButton.onClick.AddListener(() => OpenWindow(settingsWindow));
        closeSettingsButton.onClick.AddListener(() => CloseWindow(settingsWindow));

        openAuthorsButton.onClick.AddListener(() => OpenWindow(authorsWindow));
        closeAuthorsButton.onClick.AddListener(() => CloseWindow(authorsWindow));
    }

    private void StartGame()
    {
        sceneLoader.LoadScene();
    }

    private void OpenWindow(GameObject window)
    {
        buttonsWindow.SetActive(false);

        window.SetActive(true);
    }

    private void CloseWindow(GameObject window)
    {
        window.SetActive(false);

        buttonsWindow.SetActive(true);
    }
}
