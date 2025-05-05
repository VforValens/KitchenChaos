using Scriptable_Objects;
using UnityEngine;
    
[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject
{
    
    
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float burningTimerMax;
    
}
