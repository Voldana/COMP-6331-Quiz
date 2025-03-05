using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class IndividualAI : MonoBehaviour
    {
        [SerializeField] private float maxRadius = 75;
        [SerializeField] private GroupAI.Type type;

        private List<Transform> nearbyFriends = new();
        private List<Transform> nearbyEnemies = new();

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