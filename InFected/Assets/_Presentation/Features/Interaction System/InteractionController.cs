using InventorySystem;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [field: SerializeField] public Inventory Inventory { get; private set; }
    [field: SerializeField] public HealthController HealthController { get; private set; }

    [Space]
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactableLayers;

    [Space]
    [SerializeField] private AudioSource interactingSource;

    private IInteractable _currentInteractable;

    private void FixedUpdate()
    {
        List<IInteractable> interactables = new();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius, interactableLayers);
        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactables.Add(interactable);
            }
        }

        if (interactables.Contains(_currentInteractable))
        {
            return;
        }
        else
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.HideInteraction();
                _currentInteractable = null;
            }

            if (interactables.Count > 0)
            {
                _currentInteractable = interactables[0];
                _currentInteractable.ShowInteraction();
            }
        }
    }

    public void Interact()
    {
        if (_currentInteractable != null)
        {
            _currentInteractable.Interact(this);
            _currentInteractable = null;
        }
    }

    public void SetInteractable(IInteractable interactable)
    {
        _currentInteractable = interactable;
    }

    public void PlayInteractionEffect(AudioClip interactionClip)
    {
        interactingSource.PlayOneShot(interactionClip);
    }
}
