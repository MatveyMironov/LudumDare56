using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ImageLoadCapacityDisplayer : LoadCapacityDisplayer
    {
        [SerializeField] private ItemFadeableImage fadeableImagePrefab;
        [SerializeField] private Transform content;

        private List<ItemFadeableImage> fadeableImages = new();

        public override void DisplayCapacity(int capacity)
        {
            HideCapacity();

            for (int i = 0; i < capacity; i++)
            {
                ItemFadeableImage fadeableImage = Instantiate(fadeableImagePrefab, content);
                fadeableImages.Add(fadeableImage);
            }

            HideLoad();
        }

        public override void HideCapacity()
        {
            for (int i = fadeableImages.Count - 1; i >= 0; i--)
            {
                Destroy(fadeableImages[i]);
                fadeableImages.RemoveAt(i);
            }
        }

        public override void DisplayLoad(int load)
        {
            HideLoad();

            for (int i = 0; i < load; i++)
            {
                fadeableImages[i].FadeIn();
            }
        }

        public override void HideLoad()
        {
            foreach (var fadeableImage in fadeableImages)
            {
                fadeableImage.FadeOut();
            }
        }
    }
}
