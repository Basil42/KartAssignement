using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace LevelManagement
{
    [CreateAssetMenu(fileName = "new Level data", menuName = "Level Data", order = 0)]
    public class LevelData : ScriptableObject
    {
        public static LevelData current;

        [SerializeField] private bool _stopAfterFirstPlace = true;
        [SerializeField] private int _lapCount = 3;
        [SerializeField] private List<int> _pointValues;//points earned by players by place finished

        public bool stopAfterFirstPlace => _stopAfterFirstPlace;
        public int lapCount => _lapCount;

        
        public List<int> pointValues => _pointValues;
    }
}