using TMPro;
using UnityEngine;

namespace TestMillionParticles.View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DistanceView : MonoBehaviour
    {
        private TextMeshProUGUI _distanceText;

        public void SetDistanceText(string distance) => (_distanceText ??= GetComponent<TextMeshProUGUI>()).text = distance;
    }    
}

