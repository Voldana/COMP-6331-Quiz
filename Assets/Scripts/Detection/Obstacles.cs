using AI;
using UnityEngine;

namespace Detection
{
    public class Obstacles: MonoBehaviour
    {
        private IndividualAI individualAI;

        private void Start()
        {
            individualAI = transform.parent.GetComponent<IndividualAI>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(!other.gameObject.CompareTag("Obstacle")) return;
            individualAI.AddObstacle(other.transform);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if(!other.gameObject.CompareTag("Obstacle")) return;
            individualAI.RemoveObstacle(other.transform);
        }
    }
}