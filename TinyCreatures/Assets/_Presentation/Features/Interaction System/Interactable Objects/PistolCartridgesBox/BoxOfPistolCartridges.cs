using UnityEngine;

public class BoxOfPistolCartridges : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;
    [Space]
    [ContextMenuItem("Reset Stored Items", "ResetStoredItems")]
    [SerializeField] private int initialStoredItems;
    public int CurrentStoredItems { get; private set; }

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
            CurrentStoredItems = 0;
        }
        else
        {
            inventory.AddPistolCartridges(availableSpace);
            CurrentStoredItems -= availableSpace;
        }

        indicator.SetInteractionInformation($"{CurrentStoredItems} Pistol Cartridges");
    }

    private void ResetStoredItems()
    {
        CurrentStoredItems = initialStoredItems;
        indicator.SetInteractionInformation($"{CurrentStoredItems} Pistol Cartridges");
    }
}
