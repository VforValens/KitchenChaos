using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu()]
    public class CuttingRecipeSO : ScriptableObject
    {


        public KitchenObjectSO input;
        public KitchenObjectSO output;
        public int cuttingProgressMax;

    }
}
