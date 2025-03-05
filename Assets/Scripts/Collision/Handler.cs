using System;
using UnityEngine;

namespace Collision
{
    public class Handler : MonoBehaviour
    {
        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (gameObject.CompareTag("Paper"))
            {
                if (collision.gameObject.CompareTag("Rock"))
                {
                    collision.gameObject.SetActive(false);
                    // GameManager.Instance.UpdateGameState(GameState.Decide);
                    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }

                if (collision.gameObject.CompareTag("Spock"))
                {
                    collision.gameObject.SetActive(false);
                    // GameManager.Instance.UpdateGameState(GameState.Decide);
                    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }
            }

            if (gameObject.CompareTag("Rock"))
            {
                if (collision.gameObject.CompareTag("Scissors"))
                {
                    collision.gameObject.SetActive(false);
                    // GameManager.Instance?.UpdateGameState(GameState.Decide);
                    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }

                if (collision.gameObject.CompareTag("Lizard"))
                {
                    collision.gameObject.SetActive(false);
                    // GameManager.Instance?.UpdateGameState(GameState.Decide);
                    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }
            }

            if (gameObject.CompareTag("Scissors"))
            {
                if (collision.gameObject.CompareTag("Paper"))
                {
                    collision.gameObject.SetActive(false);
                    // GameManager.Instance?.UpdateGameState(GameState.Decide);
                    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }

                if (collision.gameObject.CompareTag("Lizard"))
                {
                    collision.gameObject.SetActive(false);
                    // GameManager.Instance?.UpdateGameState(GameState.Decide);
                    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }
            }

            if (gameObject.CompareTag("Lizard"))
            {
                if (collision.gameObject.CompareTag("Spock"))
                {
                    collision.gameObject.SetActive(false);
                    // GameManager.Instance?.UpdateGameState(GameState.Decide);
                    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }

                if (collision.gameObject.CompareTag("Paper"))
                {
                    collision.gameObject.SetActive(false);
                    // GameManager.Instance?.UpdateGameState(GameState.Decide);
                    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }
            }

            if (gameObject.CompareTag("Spock"))
            {
                if (collision.gameObject.CompareTag("Scissors"))
                {
                    collision.gameObject.SetActive(false);
                    // GameManager.Instance?.UpdateGameState(GameState.Decide);
                    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }

                if (collision.gameObject.CompareTag("Rock"))
                {
                    collision.gameObject.SetActive(false);
                    // GameManager.Instance?.UpdateGameState(GameState.Decide);
                    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }
            }
        }
    }
}