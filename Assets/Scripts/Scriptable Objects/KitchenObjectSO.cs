using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu()]
    public class KitchenObjectSO : ScriptableObject
    {

        public Transform prefab;
        public Sprite sprite;
        public string objectName;
    
    }
}
