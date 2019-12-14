using UnityEngine;

namespace _Project.Scripts.Platform
{
    public class PlatformTile : MonoBehaviour
    {
        [SerializeField] private bool randomTile;
        [SerializeField] private Transform endPointTransform;
        public Vector3 EndPoint => endPointTransform.position;

        public void Initialize()
        {
            if (!randomTile) return;
            foreach (var randomSelector in GetComponentsInChildren<IRandomSelector>())
            {
                randomSelector.Initialize();
            }
        }
    }
}
