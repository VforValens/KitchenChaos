using Scriptable_Objects;
using UnityEngine;
    
[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    
    
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float fryingTimerMax;
    
}
