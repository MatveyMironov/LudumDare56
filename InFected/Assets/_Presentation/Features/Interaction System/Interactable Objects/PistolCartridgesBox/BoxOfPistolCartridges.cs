using UnityEngine;

public class BoxOfPistolCartridges : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;
    [Space]
    [ContextMenuItem("Reset Stored Items", "ResetStoredItems")]
    [SerializeField] private int initialStoredItems;
    public int CurrentStoredItems { get; private set; }

    [Header("Interaction Effects")]
    [SerializeField] private AudioClip interactionClip;

    private void Start()
    {
        ResetStoredItems();
        HideInteraction();
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
        Inventory inventory = interactionController.Inventory;
        int availableSpace = inventory.MaxPistolCartridges - inventory.CurrentPistolCartridges;

        if (availableSpace >= CurrentStoredItems)
        {
            inventory.AddPistolCartridges(CurrentStoredItems);
            interactionController.PlayInteractionEffect(interactionClip);
            CurrentStoredItems = 0;
            Destroy(gameObject);
        }
        else
        {
            inventory.AddPistolCartridges(availableSpace);
            interactionController.PlayInteractionEffect(interactionClip);
            CurrentStoredItems -= availableSpace;
            indicator.SetInteractionInformation($"{CurrentStoredItems}\r\nRounds");
        }
    }

    private void ResetStoredItems()
    {
        CurrentStoredItems = initialStoredItems;
        indicator.SetInteractionInformation($"{CurrentStoredItems}\r\nRounds");
    }
}
