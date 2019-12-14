using System;
using System.Collections;
using _Project.Scripts.Generic;
using RakibUtils;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerPlatformHelper : MonoBehaviour
    {
        [SerializeField] private Vector3Variable nextPlatformPoint;

        private void Start()
        {
            InvokeRepeating(nameof(CheckPlatform), 1, .5f);
        }

        private void CheckPlatform()
        {
            if (Vector3.Distance(transform.position, nextPlatformPoint.value) < 20f)
            {
                GameEvents.OnSpawnPlatform();
            }
        }
    }
}
