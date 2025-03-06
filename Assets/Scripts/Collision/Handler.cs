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
                    SendSignal(GroupAI.Type.Rock);
                }

                if (collision.gameObject.CompareTag("Spock"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Spock);
                }
            }

            if (gameObject.CompareTag("Rock"))
            {
                if (collision.gameObject.CompareTag("Scissors"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Scissors);
                }

                if (collision.gameObject.CompareTag("Lizard"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Lizard);
                }
            }

            if (gameObject.CompareTag("Scissors"))
            {
                if (collision.gameObject.CompareTag("Paper"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Paper);
                }

                if (collision.gameObject.CompareTag("Lizard"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Lizard);
                }
            }

            if (gameObject.CompareTag("Lizard"))
            {
                if (collision.gameObject.CompareTag("Spock"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Spock);
                }

                if (collision.gameObject.CompareTag("Paper"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Paper);
                }
            }

            if (gameObject.CompareTag("Spock"))
            {
                if (collision.gameObject.CompareTag("Scissors"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Scissors);
                }

                if (collision.gameObject.CompareTag("Rock"))
                {
                    collision.gameObject.SetActive(false);
                    SendSignal(GroupAI.Type.Rock);
                }
            }
        }

        private void SendSignal(GroupAI.Type type)
        {
            signalBus.Fire(new GameEvents.OnEntityDestroy { type = type });
        }
    }
}