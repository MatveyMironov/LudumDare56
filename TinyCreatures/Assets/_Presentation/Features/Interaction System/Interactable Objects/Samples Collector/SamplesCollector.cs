using System;
using UnityEngine;

public class SamplesCollector : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;
    [SerializeField] private int requiredSamples;

    public int StoredSamples { get; private set; }

    public event Action OnAllSamplesCollected;

    private void Start()
    {
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
        int availableSamples = interactionController.Inventory.CollectedSamples;
        interactionController.Inventory.RemoveSamples(availableSamples);
        StoredSamples += availableSamples;
        indicator.SetInteractionInformation($"{StoredSamples}/{requiredSamples}\r\nSamples\r\nCollected");

        if (StoredSamples >= requiredSamples)
        {
            OnAllSamplesCollected?.Invoke();
        }
    }
}
