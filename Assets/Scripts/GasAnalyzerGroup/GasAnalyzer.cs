using System;
using UnityEngine;

namespace GasAnalyzer
{
    public class GasAnalyzer : MonoBehaviour
    {
        [SerializeField] private GasAnalyzerAnimator _animator;

        public event Action Checked;

        private void Start()
        {
            _animator.ResultShowed += OnShowResult;
        }

        private void OnDestroy()
        {
            _animator.ResultShowed -= OnShowResult;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out GasConnection gasConnection))
            {
                ShowingResults(gasConnection.IsGasLeak);
            }
        }

        private void OnShowResult()
        {
            Checked?.Invoke();
        }

        private void ShowingResults(bool isGasLeak)
        {
            _animator.ShowAnimation(isGasLeak);
        }
    }
}
