using Scriptable_Objects;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // No Kitchen Object found
            if (player.HasKitchenObject())
            {
                // Player is carrying Kitchen Object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else { 
                // Player is not carrying anything
                
            }
        }
        else
        {
            // Kitchen Object found
            if (player.HasKitchenObject())
            {
                // Player is carrying something
                
            }
            else
            {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    
}
