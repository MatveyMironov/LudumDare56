using AudioSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Pause
{
    public class MainPauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menuObject;

        [Space]
        [SerializeField] private Button resumeButton;
        [SerializeField] private PauseManager pauseManager;

        [Space]
        [SerializeField] private Button settingsButton;
        [SerializeField] private AudioSettingsMenu audioSettingsMenu;

        [Space]
        [SerializeField] private Button quitButton;

        private bool _isOpened = false;

        private void Awake()
        {
            resumeButton.onClick.AddListener(pauseManager.ResumeGame);
            resumeButton.onClick.AddListener(audioSettingsMenu.CloseMenu);

            settingsButton.onClick.AddListener(audioSettingsMenu.OpenMenu);
            settingsButton.onClick.AddListener(CloseMenu);
        }

        public void OpenMenu()
        {
            if (_isOpened) { return; }

            menuObject.SetActive(true);

            _isOpened = true;
        }

        public void CloseMenu()
        {
            if (!_isOpened) { return; }

            menuObject.SetActive(false);

            _isOpened = false;
        }
    }
}
