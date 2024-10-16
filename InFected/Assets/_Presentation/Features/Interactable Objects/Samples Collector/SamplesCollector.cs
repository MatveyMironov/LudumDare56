using InventorySystem;
using System;
using UnityEngine;

public class SamplesCollector : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;

    [Header("Samples")]
    [SerializeField] private ItemDataSO requiredItem;
    [SerializeField] private int requiredCount;
    
    public ItemDataSO RequiredItem { get { return requiredItem; } }
    public int RequiredCount { get { return requiredCount; } }

    public event Action OnAllSamplesCollected;

    private void Start()
    {
        indicator.SetInteractionInformation($"Collect {requiredCount}\r\nBacteria\r\nSamples");
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
        int availableSamples = interactionController.Inventory.GetItemCount(requiredItem);

        if (availableSamples >= requiredCount)
        {
            interactionController.Inventory.RemoveItem(requiredItem, availableSamples);
            OnAllSamplesCollected?.Invoke();
        }
    }
}
