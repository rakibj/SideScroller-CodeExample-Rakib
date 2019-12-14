using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Platform
{
    public class RandomBackgroundSelector : MonoBehaviour, IRandomSelector
    {
        [SerializeField] private List<Sprite> backgroundObjects;
        private SpriteRenderer m_spriteRenderer;

        private void Awake()
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            Initialize();
        }

        public void Initialize()
        {
            //Randomly decide if there should be any backgroundObject here
            if (Random.Range(0f, 1f) > .8f)
                return;
            
            //Randomly select which one should appear
            m_spriteRenderer.sprite = backgroundObjects[Random.Range(0, backgroundObjects.Count)];

        }
    }
}
