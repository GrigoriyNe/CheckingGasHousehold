using UnityEngine;

namespace GasAnalyzer
{
    public class GasAnalyzer : MonoBehaviour
    {
        [SerializeField] private GasAnalyzerAnimator _animator;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out GasConnection gasConnection))
            {
                ShowResults(gasConnection.IsGasLeak);
            }
        }

        private void ShowResults(bool isGasLeak)
        {
            _animator.ShowAnimation(isGasLeak);
        }
    }
}