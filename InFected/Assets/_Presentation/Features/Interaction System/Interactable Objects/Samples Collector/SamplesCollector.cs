using System;
using UnityEngine;

public class SamplesCollector : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;
    [SerializeField] private int requiredSamples;

    public int RequiredSamples { get { return requiredSamples; } }

    public event Action OnAllSamplesCollected;

    private void Start()
    {
        indicator.SetInteractionInformation($"Collect {requiredSamples}\r\nBacteria\r\nSamples");
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

        if (availableSamples >= requiredSamples)
        {
            interactionController.Inventory.RemoveSamples(availableSamples);
            OnAllSamplesCollected?.Invoke();
        }
    }
}
