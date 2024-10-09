using UnityEngine;

public class MedPack : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;
    [Space]
    [SerializeField] private int healthPerUse;

    [Header("Interaction Effects")]
    [SerializeField] private AudioClip interactionClip;

    private void Start()
    {
        indicator.SetInteractionInformation($"{healthPerUse}%");
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
        HealthController healthController = interactionController.HealthController;

        if (healthController.CurrentHealth < healthController.MaxHealth)
        {
            healthController.AddHealth(healthPerUse);
            interactionController.PlayInteractionEffect(interactionClip);
            Destroy(gameObject);
        }
    }
}
