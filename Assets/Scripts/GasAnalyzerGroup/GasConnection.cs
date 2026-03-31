using UnityEngine;

namespace GasAnalyzer
{
    public class GasConnection : MonoBehaviour
    {
        private const float HalfValue = 0.5f;

        [SerializeField] private bool _isGasLeak;

        public bool IsGasLeak => _isGasLeak;

        public void Randomize()
        {
            _isGasLeak = (Random.value > HalfValue);
        }
    }
}
