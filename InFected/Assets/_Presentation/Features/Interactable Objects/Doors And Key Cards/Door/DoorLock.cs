using InventorySystem;
using UnityEngine;

namespace Door
{
    public class DoorLock : MonoBehaviour, IInteractable
    {
        [SerializeField] private DoorMotor doorMotor;

        [Space]
        [SerializeField] private InteractionIndicator indicator;

        [Space]
        [SerializeField] private ItemDataSO requiredKeyCard;

        private void Start()
        {
            if (requiredKeyCard != null)
            {
                indicator.SetInteractionInformation($"You need\r\n{requiredKeyCard.Name}\r\nto pass");
            }
            indicator.HideIndicator();
        }

        public void ShowInteraction()
        {
            if (doorMotor.IsOpened || doorMotor.IsOpening) { return; }

            indicator.ShowIndicator();
        }

        public void HideInteraction()
        {
            if (doorMotor.IsOpened) { return; }

            indicator.HideIndicator();
        }

        public void Interact(InteractionController interactionController)
        {
            if (doorMotor.IsOpened || doorMotor.IsOpening) { return; }

            if (requiredKeyCard == null)
            {
                doorMotor.StartOpeningDoor();
                HideInteraction();
                return;
            }

            if (interactionController.Inventory.GetItemCount(requiredKeyCard) > 0)
            {
                doorMotor.StartOpeningDoor();
                HideInteraction();
            }
        }
    }
}
