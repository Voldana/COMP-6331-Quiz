using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TimeScale : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Slider slider;
        
        private void Start()
        {
            UpdateTime(slider.value);
            slider.onValueChanged.AddListener(UpdateTime);
        }

        private void UpdateTime(float scale)
        {
            Time.timeScale = scale;
            text.text = "Time Scale: " + scale;
        }

    }
}
