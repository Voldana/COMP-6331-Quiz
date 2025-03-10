using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace AI
{
    public class IndividualAI : MonoBehaviour
    {
        [Inject] private GroupAI groupAI;

        [SerializeField] private float maxDistance = 75;
        [SerializeField] private GroupAI.Type type;

        private List<Transform> nearbyObstacles = new();
        private List<Transform> nearbyFriends = new();
        private List<Transform> nearbyEnemies = new();
        private Transform closestTarget;
        private Transform closestEnemy;
        private Rigidbody rb;

        private Vector3 startingPos;
        private Vector3 direction;
        private Vector3 avoidance;
        private float boostTime = 2;
        private bool isBoosting;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            startingPos = transform.position;
        }

        private void FixedUpdate()
        {
            CheckCenter();
            CheckBoost();
            SetTarget();
            if (closestEnemy && closestEnemy.gameObject.activeSelf)
                Flee();
            else if (closestTarget && closestTarget.gameObject.activeSelf)
                Seek();
            AvoidFriends();
            AvoidObstacles();
            CalculateSpeed();
        }

        private void CheckCenter()
        {
            var distance = Vector3.Distance(transform.position, Vector3.zero);
            if (distance <= maxDistance) return;
            // transform.position = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            transform.position = startingPos;
        }

        private void CheckBoost()
        {
            if (boostTime <= 0) return;
            boostTime -= Time.deltaTime;
        }

        private void Flee()
        {
            var distance = Vector3.Distance(closestEnemy.position, transform.position);
            if (distance > 7.5) // Out of range
            {
                closestEnemy = null;
                return;
            }

            direction = Vector3.Normalize(transform.position - closestEnemy.position);

            if (distance <= 5)
            {
                StartCoroutine(Boost());
            }
        }

        private void Seek()
        {
            direction = Vector3.Normalize(closestTarget.position - transform.position);
            if (Vector3.Distance(closestTarget.position, transform.position) <= 10) return; // In range
            // closestTarget = null;
        }

        private void AvoidFriends()
        {
            foreach (var friend in from friend in nearbyFriends
                     where friend.gameObject.activeSelf
                     let distance = Vector3.Distance(transform.position, friend.position)
                     where !(distance > 3)
                     select friend)
            {
                avoidance += Vector3.Normalize(transform.position - friend.position);
            }
        }

        private void AvoidObstacles()
        {
            foreach (var obstacle in from obstacle in nearbyObstacles
                     where obstacle.gameObject.activeSelf
                     let distance = Vector3.Distance(transform.position, obstacle.position)
                     where !(distance > 5)
                     select obstacle)
            {
                avoidance += Vector3.Normalize(transform.position - obstacle.position);
            }
        }
        
        private void CalculateSpeed()
        {
            direction = (direction + avoidance).normalized;
            rb.linearVelocity = direction * (groupAI.GetAggression() + (isBoosting ? 2 : 0));
        }

        private void SetTarget()
        {
            if (closestTarget && closestTarget.gameObject.activeSelf) return;
            closestTarget = groupAI.GetClosestTarget(transform);
        }

        private IEnumerator Boost()
        {
            isBoosting = true;
            closestTarget = null; // Just run
            yield return new WaitForSeconds(2);
            boostTime = 2;
            isBoosting = false;
        }

        public void AddFriend(Transform friend)
        {
            nearbyFriends.Add(friend);
        }

        public void AddEnemy(Transform enemy)
        {
            nearbyEnemies.Add(enemy);
            SetClosestEnemy();
        }

        private void SetClosestEnemy()
        {
            var distance = float.MaxValue;

            foreach (var enemy in nearbyEnemies)
            {
                var enemyDistance = Vector3.Distance(transform.position, enemy.position);
                if (distance <= enemyDistance) continue;
                distance = enemyDistance;
                closestEnemy = enemy;
            }
        }

        public void RemoveFriend(Transform friend)
        {
            if (!nearbyFriends.Contains(friend)) return;
            nearbyFriends.Remove(friend);
        }

        public void RemoveEnemy(Transform enemy)
        {
            if (!nearbyEnemies.Contains(enemy)) return;
            nearbyEnemies.Remove(enemy);
        }
        
        public void AddObstacle(Transform obstacle)
        {
            nearbyObstacles.Add(obstacle);
        }
        
        public void RemoveObstacle(Transform obstacle)
        {
            if (!nearbyObstacles.Contains(obstacle)) return;
            nearbyObstacles.Remove(obstacle);
        }
    }
}