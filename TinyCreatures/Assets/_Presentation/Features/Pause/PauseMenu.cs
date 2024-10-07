using UnityEngine;
using UnityEngine.UI;

namespace Pause
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private GameObject buttonsWindow;

        [Header("Start Game")]
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private Button quitButton;

        [Header("Settings")]
        [SerializeField] private GameObject settingsWindow;
        [SerializeField] private Button openSettingsButton;
        [SerializeField] private Button closeSettingsButton;

        private bool _isOpened = false;

        private void Awake()
        {
            quitButton.onClick.AddListener(QuitGame);

            openSettingsButton.onClick.AddListener(() => OpenWindow(settingsWindow));
            closeSettingsButton.onClick.AddListener(() => CloseWindow(settingsWindow));
        }

        public void OpenMenu()
        {
            if (_isOpened) { return; }

            panel.SetActive(true);

            _isOpened = true;
        }

        public void CloseMenu()
        {
            if (!_isOpened) { return; }

            panel.SetActive(false);

            _isOpened = false;
        }

        private void QuitGame()
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
}
