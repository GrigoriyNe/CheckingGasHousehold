using UnityEngine;
using Switch;

namespace FireGroup
{
    public class BurnerView : MonoBehaviour
    {
        private const float BrokenLifetime = 0.2f;

        [SerializeField] private GasRegulator _switchInvoker;

        private bool _isBroken = false;
        private ParticleSystem.MainModule _mainModule;

        public bool IsBroken => _isBroken;

        private void OnEnable()
        {
            _switchInvoker.Rotated += OnRotated;

            ParticleSystem particleSystem = GetComponent<ParticleSystem>();
            _mainModule = particleSystem.main;
            _mainModule.startSize = _switchInvoker.transform.rotation.z;

            if (_isBroken)
            {
                _mainModule.startLifetime = BrokenLifetime;
            }
        }

        private void OnDisable()
        {
            _switchInvoker.Rotated -= OnRotated;
        }

        public void Break()
        {
            _isBroken = true;
        }

        private void OnRotated(float value)
        {
            _mainModule.startSize = value;
        }
    }
}