using TMPro;
using UnityEngine;

public class SamplesCollectorUI : MonoBehaviour
{
    [SerializeField] private SamplesCollector samplesCollector;
    [SerializeField] private Inventory playerInventory;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemsCounter;

    public void UpdateCounter()
    {
        itemsCounter.text = $"{playerInventory.CollectedSamples}/{samplesCollector.RequiredSamples}";
    }

    private void OnEnable()
    {
        playerInventory.OnCollectedSamplesChanged += UpdateCounter;
    }

    private void OnDisable()
    {
        playerInventory.OnCollectedSamplesChanged -= UpdateCounter;
    }
}
