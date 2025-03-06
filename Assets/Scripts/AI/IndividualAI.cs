using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace AI
{
    public class IndividualAI : MonoBehaviour
    {
        [Inject] private GroupAI groupAI;
        
        [SerializeField] private float maxDistance = 75;
        [SerializeField] private GroupAI.Type type;

        private List<Transform> nearbyFriends = new();
        private List<Transform> nearbyEnemies = new();
        private Transform closestEnemy;
        private Transform target;
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            CheckCenter();
        }

        private void CheckCenter()
        {
            var distance = Vector3.Distance(transform.position, Vector3.zero);
            if(distance <= maxDistance) return;
            transform.position = new Vector3(Random.Range(-25,25),0,Random.Range(-25,25));
        }

        private void CheckBoost()
        {
            
        }

        public void AddFriend(Transform friend)
        {
            nearbyFriends.Add(friend);
        }

        public void AddEnemy(Transform enemy)
        {
            nearbyEnemies.Add(enemy);
        }

        public void RemoveFriend(Transform friend)
        {
            nearbyFriends.Remove(friend);
        }

        public void RemoveEnemy(Transform enemy)
        {
            nearbyEnemies.Remove(enemy);
        }
    }
}