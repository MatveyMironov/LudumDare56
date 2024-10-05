using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [field: SerializeField] public Inventory Inventory { get;private set; }
    [field: SerializeField] public HealthController HealthController { get;private set; }
    [Space]
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactableLayers;

    private IInteractable _currentInteractable;

    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius, interactableLayers);
        List<IInteractable> interactables = new();
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
            _currentInteractable?.HideInteraction();
            _currentInteractable = null;
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
        }
    }

    public void SetInteractable(IInteractable interactable)
    {
        _currentInteractable = interactable;
    }
}
