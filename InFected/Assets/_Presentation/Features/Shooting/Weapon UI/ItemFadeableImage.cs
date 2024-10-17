using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemFadeableImage : MonoBehaviour
    {
        [SerializeField] private Image background;
        [SerializeField] private Image fadeable;

        public void SetSprite(Sprite sprite)
        {
            background.sprite = sprite;
            fadeable.sprite = sprite;
        }

        public void FadeOut()
        {
            fadeable.enabled = false;
        }

        public void FadeIn()
        {
            fadeable.enabled = true;
        }
    }
}
