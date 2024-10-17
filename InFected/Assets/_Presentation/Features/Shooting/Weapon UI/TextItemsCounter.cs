using TMPro;
using UnityEngine;

namespace UI
{
    public class TextLoadCapacity : LoadCapacityDisplayer
    {
        [SerializeField] private TextMeshProUGUI loadText;
        [SerializeField] private TextMeshProUGUI capacityText;

        public override void DisplayCapacity(int capacity)
        {
            capacityText.text = capacity.ToString();
        }

        public override void HideCapacity()
        {

        }

        public override void DisplayLoad(int load)
        {
            loadText.text = load.ToString();
        }

        public override void HideLoad()
        {

        }
    }
}
