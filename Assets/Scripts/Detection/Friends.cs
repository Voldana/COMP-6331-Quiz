using System;
using AI;
using UnityEngine;
using Zenject;

namespace Detection
{
    public class Friends: MonoBehaviour
    {
        [Inject] private IndividualAI individualAI;
        private void OnTriggerEnter(Collider other)
        {
            if(!other.gameObject.CompareTag(transform.parent.tag)) return;
            individualAI.AddFriend(other.transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if(!other.gameObject.CompareTag(transform.parent.tag)) return;
            individualAI.RemoveFriend(other.transform);
        }
    }
}