using InventorySystem;
using UnityEngine;

public class SingleItemContainer : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;

    [Header("Stored Item")]
    [SerializeField] private ItemDataSO item;
    [SerializeField] private int storedAmount;

    [Header("Interaction Effects")]
    [SerializeField] private AudioClip interactionClip;

    private void Start()
    {
        DisplayItem();
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
        inventory.AddItem(item, storedAmount);
        DisplayItem();
        Destroy(gameObject);
    }

    private void DisplayItem()
    {
        if (storedAmount == 1)
        {
            indicator.SetInteractionInformation($"{item.Name}");
        }
        else
        {
            indicator.SetInteractionInformation($"{item.Name}\r\n{storedAmount}");
        }
    }
}
