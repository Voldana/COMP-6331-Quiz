using System;
using System.Linq;
using AI;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Faction : MonoBehaviour
    {
        [Inject] private EndPanel.Factory factory;
        [Inject] private SignalBus signalBus;
        
        [SerializeField] private TMP_Text aggressiveness;
        [SerializeField] private TMP_Text targetsKilled;
        [SerializeField] private TMP_Text factionName;
        [SerializeField] private TMP_Text membersLeft;
        [SerializeField] private GroupAI.Type faction;

        private int members = 10;
        private GroupAI groupAI;
        private int targets;

        private void Start()
        {
            UpdateTexts();
            SetTitle();
            FindGroupAI();
            signalBus.Subscribe<GameEvents.OnEntityDestroy>(OnEntityDeath);
        }

        private void FindGroupAI()
        {
            var groups = FindObjectsOfType<GroupAI>();
            groupAI = groups.FirstOrDefault(group => group.GetFaction().Equals(faction));
        }

        private void FixedUpdate()
        {
            aggressiveness.text = "Aggressiveness: " + groupAI.GetAggression();
        }

        private void SetTitle()
        {
            factionName.text = faction.ToString();
        }

        private void OnEntityDeath(GameEvents.OnEntityDestroy signal)
        {
            if (signal.killedBy.Equals(faction))
            {
                targets++;
                UpdateTexts();
            }

            if (!signal.typeKilled.Equals(faction)) return;
            members--;
            UpdateTexts();
            if(members == 0)
                CreateEndPanel();
                

        }

        private void CreateEndPanel()
        {
            factory.Create(faction).transform.SetParent(transform.parent.parent, false);
        }

        private void UpdateTexts()
        {
            targetsKilled.text = "Killed: " + targets;
            membersLeft.text = "Members: " + members;
        }
    }
}
