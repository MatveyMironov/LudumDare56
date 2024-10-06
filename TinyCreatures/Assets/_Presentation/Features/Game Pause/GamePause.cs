using UnityEngine;

namespace Pause
{
    public class GamePause : MonoBehaviour
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Resume()
        {
            Time.timeScale = 1;
        }
    }
}
