using Pause;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private SamplesCollector sampleCollector;

    [SerializeField] private GamePause gamePause;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private SceneLoader sceneLoader;

    [Header("UI")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject[] narrativeWindows;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    private int _currentPanelIndex = 0;

    private void Win()
    {
        gamePause.Pause();
        inputManager.InputDisabled = true;
        winPanel.SetActive(true);
        narrativeWindows[_currentPanelIndex].SetActive(true);

        nextButton.onClick.AddListener(ShowNext);
        previousButton.onClick.AddListener(ShowPrevious);
    }

    private void ShowNext()
    {
        if (_currentPanelIndex + 1 < narrativeWindows.Length)
        {
            narrativeWindows[_currentPanelIndex].SetActive(false);
            _currentPanelIndex++;
            narrativeWindows[_currentPanelIndex].SetActive(true);
        }
        else
        {
            sceneLoader.LoadScene();
        }
    }

    private void ShowPrevious()
    {
        if (_currentPanelIndex - 1 >= 0)
        {
            narrativeWindows[_currentPanelIndex].SetActive(false);
            _currentPanelIndex--;
            narrativeWindows[_currentPanelIndex].SetActive(true);
        }
    }

    private void OnEnable()
    {
        sampleCollector.OnAllSamplesCollected += Win;
    }

    private void OnDisable()
    {
        sampleCollector.OnAllSamplesCollected -= Win;
    }
}
