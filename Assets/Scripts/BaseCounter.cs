using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    
    [SerializeField] private Transform counterTopPoint;
    
    
    private KitchenObject kitchenObject;
    

    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter.Interact();");
    }
    
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }
    
    public void SetKitchenObject(KitchenObject newKitchenObject)
    {
        this.kitchenObject = newKitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;   
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
    
}
