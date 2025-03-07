using System;
using AI;
using UnityEngine;
using Zenject;

namespace Collision
{
    public class Handler : MonoBehaviour
    {
        [Inject] private SignalBus signalBus;

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (gameObject.CompareTag("Paper"))
            {
                if (collision.gameObject.CompareTag("Rock"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Rock, GroupAI.Type.Paper);
                }

                if (collision.gameObject.CompareTag("Spock"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Spock, GroupAI.Type.Paper);
                }
            }

            if (gameObject.CompareTag("Rock"))
            {
                if (collision.gameObject.CompareTag("Scissors"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Scissors, GroupAI.Type.Rock);
                }

                if (collision.gameObject.CompareTag("Lizard"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Lizard, GroupAI.Type.Rock);
                }
            }

            if (gameObject.CompareTag("Scissors"))
            {
                if (collision.gameObject.CompareTag("Paper"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Paper, GroupAI.Type.Scissors);
                }

                if (collision.gameObject.CompareTag("Lizard"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Lizard, GroupAI.Type.Scissors);
                }
            }

            if (gameObject.CompareTag("Lizard"))
            {
                if (collision.gameObject.CompareTag("Spock"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Spock, GroupAI.Type.Lizard);
                }

                if (collision.gameObject.CompareTag("Paper"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Paper,GroupAI.Type.Lizard);
                }
            }

            if (gameObject.CompareTag("Spock"))
            {
                if (collision.gameObject.CompareTag("Scissors"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Scissors,GroupAI.Type.Spock);
                }

                if (collision.gameObject.CompareTag("Rock"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Rock,GroupAI.Type.Spock);
                }
            }
        }

        private void SendSignal(GroupAI.Type typeKilled, GroupAI.Type killedBy)
        {
            signalBus.Fire(new GameEvents.OnEntityDestroy { typeKilled = typeKilled , killedBy = killedBy});
        }
    }
}