using System;
using UnityEngine;

namespace RakibUtils
{
    public static class GameEvents
    {
        //Declare Event like this
        public static event Action spawnPlatform;
        //Declaration done. This can be used to register events from outside this class. But we can't yet Invoke this from
        //outside of this class as it is a delegate. So we will need a static function which will invoke this event. And we 
        //can call this function from another class to invoke this event.
        //This static function is used as an invocator. Used to Invoke this event from anywhere outside this static class.
        public static void OnSpawnPlatform() 
        {
            spawnPlatform?.Invoke();
        }

        public static event Action<int> gameOver;

        public static void OnGameOver(int score)
        {
            gameOver?.Invoke(score);
        }

    }

    
}
