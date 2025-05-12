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
                // Player is holding a Kitchen Object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else { 
                // Player is not holding anything
            }
        }
        else
        {
            // Kitchen Object found
            if (player.HasKitchenObject())
            {
                // Player is holding something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is holding a plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    // Player is not holding a plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // Counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
            {
                // Player is not holding anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    
}
