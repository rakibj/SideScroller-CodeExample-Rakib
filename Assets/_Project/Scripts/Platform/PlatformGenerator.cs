using System;
using System.Collections.Generic;
using _Project.Scripts.Generic;
using RakibUtils;
using UnityEngine;

namespace _Project.Scripts.Platform
{
    public class PlatformGenerator : MonoBehaviour
    {
        [SerializeField] private PlatformTile platformTilePrefab;
        [SerializeField] private PlatformTile startingPlatform;
        [SerializeField] private int maxPlatformsInScene = 5;
        [SerializeField] private Vector3Variable nextPlatformPoint;
        
        private List<PlatformTile> platformTiles = new List<PlatformTile>();
        private int nextPlatformIndex = 0;
        
        private void Start()
        {
            //current platform's end point is the new platform's spawn point
            nextPlatformPoint.value = startingPlatform.EndPoint;
            
            //Initialize with {maxPlatformsInScene} platforms
            for (int i = 0; i < maxPlatformsInScene; i++)
            {
                var platformTile = Instantiate(platformTilePrefab, nextPlatformPoint.value, Quaternion.identity);
                platformTile.Initialize();
                nextPlatformPoint.value = platformTile.EndPoint;
                platformTiles.Add(platformTile);
            }
            
        }

        private void OnEnable()
        {
            GameEvents.spawnPlatform += GeneratePlatformFromPool;
        }

        private void OnDisable()
        {
            GameEvents.spawnPlatform -= GeneratePlatformFromPool;
        }


        /// <summary>
        /// Generate a new platform
        /// </summary>
        private void GeneratePlatformFromPool()
        {
            platformTiles[nextPlatformIndex].transform.position = nextPlatformPoint.value;
            nextPlatformPoint.value = platformTiles[nextPlatformIndex].EndPoint;
            platformTiles[nextPlatformIndex].Initialize();
            nextPlatformIndex++;
            if (nextPlatformIndex >= maxPlatformsInScene)
                nextPlatformIndex = 0;
        }
        
        
        
        
    }
}
