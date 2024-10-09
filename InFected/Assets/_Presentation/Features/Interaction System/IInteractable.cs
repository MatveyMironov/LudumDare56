using System;
using UnityEngine;

public interface IInteractable
{
    public void ShowInteraction();

    public void HideInteraction();

    public void Interact(InteractionController interactionController);
}
