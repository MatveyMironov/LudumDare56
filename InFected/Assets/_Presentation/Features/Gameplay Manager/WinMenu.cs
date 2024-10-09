using Pause;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinMenu : MonoBehaviour
    {
        [SerializeField] private SamplesCollector sampleCollector;

        [SerializeField] private GamePause gamePause;
        [SerializeField] private Input.InputManager inputManager;
        [SerializeField] private SceneLoader sceneLoader;

        [Header("UI")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private Button quitButton;

        private void Win()
        {
            gamePause.Pause();
            inputManager.InputDisabled = true;
            winPanel.SetActive(true);
            quitButton.onClick.AddListener(Quit);
        }

        private void Quit()
        {
            sceneLoader.LoadScene();
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
}
