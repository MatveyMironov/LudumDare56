using Pause;
using UnityEngine;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    [SerializeField] private SampleCollector sampleCollector;

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
        narrativeWindows[_currentPanelIndex].SetActive(false);

        if (_currentPanelIndex + 1 < narrativeWindows.Length)
        {
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
        sampleCollector.OnSamplesCollected += Win;
    }

    private void OnDisable()
    {
        sampleCollector.OnSamplesCollected -= Win;
    }
}
