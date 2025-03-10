using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace AI
{
    public class GroupAI : MonoBehaviour
    {
        public enum Type
        {
            Rock,
            Paper,
            Scissors,
            Lizard,
            Spock,
            None
        }

        [Inject] private SignalBus signalBus;

        [SerializeField] private List<GameObject> targets;
        [SerializeField] private List<GameObject> friends;
        [SerializeField] private List<GameObject> enemies;

        [SerializeField] private FuzzyLogic logic;
        [SerializeField] private Type type;

        private float aggressiveness;

        private void Start()
        {
            Subscribe();
            UpdateLists();
        }

        private void Subscribe()
        {
            signalBus.Subscribe<GameEvents.OnEntityDestroy>(UpdateLists);
        }

        private void UpdateLists()
        {
            friends = friends.FindAll(friend => friend.gameObject.activeSelf);
            targets = targets.FindAll(target => target.gameObject.activeSelf);
            enemies = enemies.FindAll(enemy => enemy.gameObject.activeSelf);
            aggressiveness = FuzzyLogic();
            CheckForGameOver();
        }

        private void CheckForGameOver()
        {
            if (friends.Any(friend => friend.gameObject.activeSelf))
            {
                return;
            }

            signalBus.Fire(new GameEvents.OnGameOver { loser = type });
        }

        private float FuzzyLogic()
        {
            return Defuzzification(EvaluateRules(Fuzzification()));
        }

        private (float Low, float High)[] Fuzzification()
        {
            (float, float)[] results =
            {
                FuzzificationLists(friends, logic.friendlyThreshold), FuzzificationLists(enemies, logic.enemyThreshold),
                FuzzificationLists(targets, logic.targetThreshold)
            };

            return results;
        }

        private (float Low, float High) FuzzificationLists(List<GameObject> list, Threshold threshold)
        {
            float low;
            float high;
            if (list.Count <= threshold.low)
            {
                low = 1;
                high = 0;
            }
            else if (list.Count >= threshold.high)
            {
                high = 1;
                low = 0;
            }
            else
            {
                high = Mathf.Lerp(0, 1, list.Count / threshold.high);
                low = 1 - high;
            }

            return new ValueTuple<float, float>(low, high);
        }

        private float[] EvaluateRules((float low, float high)[] fuzzyInput)
        {
            var outputVariable = new float[4];
            var friendly = fuzzyInput[0];
            var enemy = fuzzyInput[1];
            var target = fuzzyInput[2];

            // Rule 1: High Enemy & High Friendly → Average Speed
            outputVariable[0] += And(enemy.high, friendly.high) * logic.averageSpeed;

            // Rule 2: High Enemy & Low Friendly → Aggressive
            outputVariable[2] += And(enemy.high, friendly.low) * logic.aggressiveSpeed;

            // Rule 3: Low Enemy OR High Target → Average Speed
            outputVariable[0] += Or(enemy.low, target.high) * logic.averageSpeed;

            // Rule 4: Low Enemy OR Low Target → Move Calmly
            outputVariable[1] += Or(enemy.low, target.low) * logic.calmSpeed;

            // Rule 5: (High Target OR High Friendly) AND NOT High Enemy → Aggressive
            outputVariable[2] += And(Or(target.high, friendly.high), Not(enemy.high)) * logic.aggressiveSpeed;

            // Rule 6: (Low Target OR High Friendly) AND NOT High Enemy → Average Speed
            outputVariable[0] += And(Or(target.low, friendly.high), Not(enemy.high)) * logic.averageSpeed;

            // Rule 7: (Low Target OR Low Friendly) OR Low Enemy → Move Calmly
            outputVariable[1] += Or(Or(target.low, friendly.low), enemy.low) * logic.calmSpeed;

            return outputVariable;
        }

        private float Defuzzification(float[] input)
        {
            return Mathf.Clamp(Mathf.Max(input), 0, logic.maxSpeed);
        }

        public float GetAggression()
        {
            return aggressiveness;
        }

        public Transform GetClosestTarget(Transform from)
        {
            return targets
                .Where(target => target.gameObject.activeSelf)
                .OrderBy(target => Vector3.Distance(from.position, target.transform.position))
                .Select(target => target.transform)
                .FirstOrDefault();
        }

        private static float And(float val1, float val2)
        {
            return Mathf.Min(val1, val2);
        }

        private static float Or(float val1, float val2)
        {
            return Mathf.Max(val1, val2);
        }

        private static float Not(float val)
        {
            return 1 - val;
        }

        public Type GetFaction()
        {
            return type;
        }
    }
}