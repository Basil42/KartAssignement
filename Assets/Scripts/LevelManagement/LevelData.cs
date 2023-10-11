using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace LevelManagement
{
    [CreateAssetMenu(fileName = "new Level data", menuName = "Level Data", order = 0)]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField]public bool StopAfterFirstPlace { get; private set; } = true;
        [field: SerializeField]public int LapCount { get; private set; } = 3;
        [field: SerializeField] public string SceneName { get; private set; }
        [field: SerializeField] public List<int> PointValues { get; private set; }
    }
}