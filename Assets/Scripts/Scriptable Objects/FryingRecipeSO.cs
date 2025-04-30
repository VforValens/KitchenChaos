using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu()]
    public class FryingRecipeSO : ScriptableObject
    {


        public FryingRecipeSO input;
        public FryingRecipeSO output;
        public float fryingTimerMax;

    }
}
