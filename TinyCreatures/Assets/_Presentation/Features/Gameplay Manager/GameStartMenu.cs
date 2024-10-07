using Pause;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [SerializeField] private GamePause gamePause;
    [SerializeField] private InputManager inputManager;

    [Header("UI")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject[] narrativeWindows;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    private int _currentPanelIndex = 0;

    private void Awake()
    {
        gamePause.Pause();
        inputManager.InputDisabled = true;
        startPanel.SetActive(true);
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
            startPanel.SetActive(false);
            inputManager.InputDisabled = false;
            gamePause.Resume();
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
}
