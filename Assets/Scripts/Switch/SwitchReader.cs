using UnityEngine;

namespace Switch
{
    public partial class SwitchReader : MonoBehaviour
    {
        [SerializeField] private RotatorInvoker _rotator;

        private bool _isTaked = false;

        private void Update()
        {
            if (_isTaked)
                _rotator.SetRotation(transform.rotation.y);
        }

        public void StartRotate()
        {
            _isTaked = true;
        }

        public void StopRotate()
        {
            _isTaked = false;
        }
    }
}