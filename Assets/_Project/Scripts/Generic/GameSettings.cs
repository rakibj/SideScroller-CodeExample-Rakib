using UnityEngine;

namespace _Project.Scripts.Generic
{
    [CreateAssetMenu(menuName = "Custom/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [Range(0f, 1f)] public float backgroundObjectFrequency;
        [Range(0f, 1f)] public float trapsFrequency;
        
    }
}
