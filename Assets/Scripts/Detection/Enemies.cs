using System;
using AI;
using UnityEngine;
using Zenject;

namespace Detection
{
    public class Enemies : MonoBehaviour
    {
        private IndividualAI individualAI;
        
        private void Start()
        {
            individualAI = transform.parent.GetComponent<IndividualAI>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (transform.parent.CompareTag("Rock") && (other.CompareTag("Paper") || other.CompareTag("Spock")))
                individualAI.AddEnemy(other.transform);
            
            if (transform.parent.CompareTag("Paper") && (other.CompareTag("Scissors") || other.CompareTag("Lizard")))
                individualAI.AddEnemy(other.transform);
            
            if (transform.parent.CompareTag("Scissors") && (other.CompareTag("Rock") || other.CompareTag("Spock")))
                individualAI.AddEnemy(other.transform);
            
            if(transform.parent.CompareTag("Lizard") && (other.CompareTag("Rock") || other.CompareTag("Scissors")))
                individualAI.AddEnemy(other.transform);
            
            if(transform.parent.CompareTag("Spock") && (other.CompareTag("Paper") || other.CompareTag("Lizard")))
                individualAI.AddEnemy(other.transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if (transform.parent.CompareTag("Rock") && (other.CompareTag("Paper") || other.CompareTag("Spock")))
                individualAI.RemoveEnemy(other.transform);
            
            if (transform.parent.CompareTag("Paper") && (other.CompareTag("Scissors") || other.CompareTag("Lizard")))
                individualAI.RemoveEnemy(other.transform);
            
            if (transform.parent.CompareTag("Scissors") && (other.CompareTag("Rock") || other.CompareTag("Spock")))
                individualAI.RemoveEnemy(other.transform);
            
            if(transform.parent.CompareTag("Lizard") && (other.CompareTag("Rock") || other.CompareTag("Scissors")))
                individualAI.RemoveEnemy(other.transform);
            
            if(transform.parent.CompareTag("Spock") && (other.CompareTag("Paper") || other.CompareTag("Lizard")))
                individualAI.RemoveEnemy(other.transform);
        }
    }
}