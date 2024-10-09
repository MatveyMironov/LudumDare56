using TMPro;
using UnityEngine;

public class InteractionIndicator : MonoBehaviour
{
    [SerializeField] private GameObject indicatorObject;
    [SerializeField] private TextMeshProUGUI interactionInformationText;

    public void ShowIndicator()
    {
        indicatorObject.SetActive(true);
    }

    public void HideIndicator()
    {
        indicatorObject?.SetActive(false);
    }

    public void SetInteractionInformation(string information)
    {
        interactionInformationText.text = information;
    }
}
