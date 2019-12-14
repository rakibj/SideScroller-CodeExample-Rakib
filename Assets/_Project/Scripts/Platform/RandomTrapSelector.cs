using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Traps;
using UnityEngine;

namespace _Project.Scripts.Platform
{
    public class RandomTrapSelector : MonoBehaviour, IRandomSelector
    {
        private List<Trap> m_traps;
        private void Awake()
        {
            m_traps = GetComponentsInChildren<Trap>().ToList();
            Initialize();
        }

        public void Initialize()
        {
            //Disable all traps before selecting a new trap
            DisableAllTraps();
            
            //Randomly decide if there should be any trap here
            if (Random.Range(0f, 1f) > .7f)
                return;
            
            //Randomly select which one should appear
            ActivateTrap(Random.Range(0, m_traps.Count));
        }

        private void DisableAllTraps()
        {
            foreach (var t in m_traps)
            {
                t.gameObject.SetActive(false);
            }
        }

        private void ActivateTrap(int i)
        {
            m_traps[i].gameObject.SetActive(true);
        }
    }
}
