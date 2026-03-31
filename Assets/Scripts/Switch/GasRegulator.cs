using System;
using UnityEngine;

namespace Switch
{
    public class GasRegulator : MonoBehaviour
    {
        [SerializeField] private float _minRotation;
        [SerializeField] private float _maxRotation;
        [SerializeField] private float _startRotation;

        public event Action<float> Rotated;

        private void OnEnable()
        {
            SetMinValue();
        }

        public void SetRotation(float rotation)
        {
            if (rotation < 0 && transform.rotation.z <= _minRotation)
            {
                return;
            }
            else if (rotation > 0 && transform.rotation.z >= _maxRotation)
            {
                return;
            }

            transform.RotateAround(transform.position, transform.forward, rotation);
            Rotated?.Invoke(transform.rotation.z);
        }

        private void SetMinValue()
        {
            transform.RotateAround(transform.position, transform.forward, _minRotation);
        }
    }
}
