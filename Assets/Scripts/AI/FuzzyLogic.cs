using System;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "FuzzyLogic", menuName = "ScriptableObjects/FuzzyLogic")]
    [Serializable]
    public class FuzzyLogic : ScriptableObject
    {
        public Threshold friendlyThreshold;
        public Threshold targetThreshold;
        public Threshold enemyThreshold;
        
        [Header("Speeds")]
        public int aggressiveSpeed;
        public int averageSpeed;
        public int calmSpeed;
    }
    
    [Serializable]
    public class Threshold
    {
        public float low;
        public float high;
    }
}