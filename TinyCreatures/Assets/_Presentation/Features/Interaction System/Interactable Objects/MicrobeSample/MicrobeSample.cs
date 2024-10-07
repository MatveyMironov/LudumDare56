using UnityEngine;

public class MicrobeSample : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;

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
        indicator?.HideIndicator();
    }

    public void Interact(InteractionController interactionController)
    {
        interactionController.Inventory.AddSamples(1);

        Destroy(gameObject);
    }
}
