using UnityEngine;

namespace Pause
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private GamePause gamePause;
        [SerializeField] private PauseMenu pauseMenu;

        public bool IsPaused { get; private set; }

        private void Start()
        {
            ResumeGame();
        }

        [ContextMenu("Pause Game")]
        public void PauseGame()
        {
            if (IsPaused) { return; }

            gamePause.Pause();
            pauseMenu.OpenMenu();

            IsPaused = true;
        }

        [ContextMenu("Resume Game")]
        public void ResumeGame()
        {
            if (!IsPaused) { return; }

            gamePause.Resume();
            pauseMenu.CloseMenu();

            IsPaused = false;
        }
    }
}
