using Pause;
using UnityEngine;
using UnityEngine.UI;

public class LossMenu : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private GamePause gamePause;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private SceneLoader sceneLoader;

    [Header("UI")]
    [SerializeField] private GameObject lossPanel;
    [SerializeField] private Button quitButton;

    private void OnEnable()
    {
        player.OnPlayerDeath += Loss;
    }

    private void OnDisable()
    {
        player.OnPlayerDeath -= Loss;
    }

    private void Loss()
    {
        gamePause.Pause();
        inputManager.InputDisabled = true;
        lossPanel.SetActive(true);
        quitButton.onClick.AddListener(sceneLoader.LoadScene);
    }
}
