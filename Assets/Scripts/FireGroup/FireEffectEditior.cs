using UnityEngine;
using Switch;

namespace FireGroup
{
    public class FireEffectEditior : MonoBehaviour
    {
        private const float BrokenLifetime = 0.2f;

        [SerializeField] private RotaterInvoker _reader;

        private bool _isBroken = false;
        private ParticleSystem.MainModule _mainModule;

        public bool IsBroken => _isBroken;

        private void OnEnable()
        {
            _reader.Rotated += OnRotation;

            ParticleSystem particleSystem = GetComponent<ParticleSystem>();
            _mainModule = particleSystem.main;
            _mainModule.startSize = _reader.transform.rotation.y;

            if (_isBroken)
            {
                _mainModule.startLifetime = BrokenLifetime;
            }
        }

        private void OnDisable()
        {
            _reader.Rotated -= OnRotation;
        }

        public void Brokend()
        {
            _isBroken = true;
        }

        private void OnRotation(float value)
        {
            _mainModule.startSize = value;
        }
    }
}