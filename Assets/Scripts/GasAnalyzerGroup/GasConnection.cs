using UnityEngine;

namespace GasAnalyzer
{
    public class GasConnection : MonoBehaviour
    {
        [SerializeField] private bool _isGasLeak;

        public bool IsGasLeak => _isGasLeak;
    }
}