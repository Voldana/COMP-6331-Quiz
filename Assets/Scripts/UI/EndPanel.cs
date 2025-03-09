using System;
using AI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class EndPanel : MonoBehaviour
    {
        [Inject] private GroupAI.Type eliminatedFaction;

        [SerializeField] private TMP_Text title;

        private void Start()
        {
            Time.timeScale = 0;
            title.text = eliminatedFaction + " faction has been eliminated!";
        }

        public void OnRetry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        public class Factory : PlaceholderFactory<GroupAI.Type, EndPanel>
        {
        }
    }
}
