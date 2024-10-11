using UnityEngine;

public class HelpClue : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;
    [SerializeField] private GameObject helpText;

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
        helpText.SetActive(false);
    }

    public void Interact(InteractionController interactionController)
    {
        helpText.SetActive(true);
    }
}
