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
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

            OnPlayerGrabsObject?.Invoke(this, EventArgs.Empty);
        }
    }

}
