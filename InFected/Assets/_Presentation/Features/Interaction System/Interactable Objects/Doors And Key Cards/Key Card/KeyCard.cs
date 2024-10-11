using UnityEngine;

namespace Door
{
    public class KeyCard : MonoBehaviour, IInteractable
    {
        [Space]
        [SerializeField] private InteractionIndicator indicator;

        [Space]
        [SerializeField] private KeyCardDataSO storedKeyCard;

        private void Start()
        {
            indicator.SetInteractionInformation($"{storedKeyCard.Name}");
            indicator.HideIndicator();
        }

        public void ShowInteraction()
        {
            indicator.ShowIndicator();
        }

        public void HideInteraction()
        {
            indicator.HideIndicator();
        }

        public void Interact(InteractionController interactionController)
        {
            interactionController.Inventory.AddKeyCard(storedKeyCard);
            Destroy(gameObject);
        }
    }
}
