using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ImageLoadCapacityDisplayer : LoadCapacityDisplayer
    {
        [SerializeField] private Image imagePrefab;
        [SerializeField] private Transform content;

        [SerializeField] private Color filledColor;
        [SerializeField] private Color emptyColor;

        private List<Image> _images = new();
        public override void DisplayCapacity(int capacity)
        {
            HideCapacity();

            for (int i = 0; i < capacity; i++)
            {
                Image image = Instantiate(imagePrefab, content);
                image.color = emptyColor;
                _images.Add(image);
            }

            HideLoad();
        }

        public override void HideCapacity()
        {
            /*
            for (int i = _images.Count - 1; i >= 0; i--)
            {
                Destroy(_images[i].gameObject);
            }*/

            foreach (Image image in _images)
            {
                Destroy(image.gameObject);
            }

            _images.Clear();
        }

        public override void DisplayLoad(int load)
        {
            HideLoad();

            for (int i = 0; i < load; i++)
            {
                _images[i].color = filledColor;
            }
        }

        public override void HideLoad()
        {
            foreach (var image in _images)
            {
                image.color = emptyColor;
            }
        }
    }
}
