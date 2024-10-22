using Door;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    [SerializeField] private KeyCardDataSO keyCard;
    [SerializeField] private SpriteRenderer colorIndicator;

    private void Start()
    {
        ResetColor();
    }

    [ContextMenu("Reset Color")]
    private void ResetColor()
    {
        colorIndicator.color = keyCard.Color;
    }
}
