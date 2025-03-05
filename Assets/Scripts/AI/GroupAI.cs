using UnityEngine;

namespace AI
{
    public class GroupAI: MonoBehaviour
    {
        public enum Type
        {
            Rock,
            Paper,
            Scissors,
            Lizard,
            Spock
        }

        [SerializeField] private FuzzyLogic logic;
        [SerializeField] private Type type;
        
        
        private float And (float val1, float val2)
        {
            return Mathf.Min(val1, val2);
        }
    
        private float Or (float val1, float val2)
        {
            return Mathf.Max(val1, val2);
        }

        private float Not (float val)
        {
            return 1 - val;
        }
    }
}