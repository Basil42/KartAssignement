using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace track
{
    public class CarSpawnPoint : MonoBehaviour
    {

        public static List<Transform> SpawnPoints = new ();

        [RuntimeInitializeOnLoadMethod]
        private static void StartupChecks()
        {
            Assert.IsTrue(SpawnPoints.Count <= 4,"spawn point list has too many entries, statics were likely not properly cleaned up");//ideally i should compare to the number of player
        }

        private void OnEnable()
        {
            SpawnPoints.Add(transform);
        }

        private void OnDisable()
        {
            if (!SpawnPoints.Remove(transform))
            {
                Debug.LogError("A spawn point was unexpectedly removed from or not added to the list");
            }
        }

    }
}