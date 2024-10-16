using InventorySystem;
using TMPro;
using UnityEngine;

public class SamplesCollectorUI : MonoBehaviour
{
    [SerializeField] private SamplesCollector samplesCollector;
    [SerializeField] private Inventory playerInventory;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemsCounter;

    private void OnEnable()
    {
        playerInventory.OnItemCountChanged += DisplayRequiredItem;
    }

    private void OnDisable()
    {
        playerInventory.OnItemCountChanged -= DisplayRequiredItem;
    }

    private void DisplayRequiredItem(ItemDataSO itemDataSO)
    {
        if (itemDataSO == samplesCollector.RequiredItem)
        {
            DisplaySamples();
        }
    }

    private void DisplaySamples()
    {
        itemsCounter.text = $"{playerInventory.GetItemCount(samplesCollector.RequiredItem)}/{samplesCollector.RequiredCount}";
    }
}
