using UnityEngine;

public class MedPack : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;
    [Space]
    [SerializeField] private int healthPerUse;
    [ContextMenuItem("Reset Uses", "ResetUses")]
    [SerializeField] private int initialUses;
    public int CurrentUses { get; private set; }

    private void Start()
    {
        ResetUses();
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
        if (CurrentUses <= 0) { return; }

        HealthController healthController = interactionController.HealthController;

        if (healthController.CurrentHealth < healthController.MaxHealth)
        {
            healthController.AddHealth(healthPerUse);
            CurrentUses -= 1;
        }

        indicator.SetInteractionInformation($"{CurrentUses}/{initialUses} uses\r\n{healthPerUse} health\r\nper use");
    }

    private void ResetUses()
    {
        CurrentUses = initialUses;
        indicator.SetInteractionInformation($"{CurrentUses}/{initialUses} uses\r\n{healthPerUse} health\r\nper use");
    }
}
