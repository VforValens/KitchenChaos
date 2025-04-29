using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{

    
    public event EventHandler OnPlayerGrabsObject;
    
    
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Player is not carrying anything
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            OnPlayerGrabsObject?.Invoke(this, EventArgs.Empty);
        }
    }

}
