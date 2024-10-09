using Pause;
using UnityEngine;
using UnityEngine.UI;
using Input;

namespace UI
{
    public class GameStartMenu : MonoBehaviour
    {
        [SerializeField] private GamePause gamePause;
        [SerializeField] private InputManager inputManager;

        [Header("UI")]
        [SerializeField] private GameObject startPanel;
        [SerializeField] private Button startButton;

        private void Awake()
        {
            gamePause.Pause();
            inputManager.InputDisabled = true;
            startPanel.SetActive(true);
            startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            startPanel.SetActive(false);
            inputManager.InputDisabled = false;
            gamePause.Resume();
        }
    }
}
