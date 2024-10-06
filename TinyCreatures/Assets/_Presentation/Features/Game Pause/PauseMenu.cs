using UnityEngine;

namespace Pause
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menuObject;

        private bool _isOpened = false;

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
