using UnityEngine;
using UnityEngine.Serialization;

public class CuttingCounter : BaseCounter
{

    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
    
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // No Kitchen Object found
            if (player.HasKitchenObject())
            {
                // Player is carrying Kitchen Object
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    // Player carrying something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            
            // There is a Kitchen Object available AND it can be cut.
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }
    
    
}
