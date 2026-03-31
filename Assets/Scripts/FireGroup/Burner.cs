using System;
using UnityEngine;
using Switch;

namespace FireGroup
{
    public class Burner : MonoBehaviour
    {
        [SerializeField] private GameObject _fireEffect;
        [SerializeField] private GameObject _gasEffect;
        [SerializeField] private GasRegulator _rotaterInvoker;

        public bool IsChecked { get; private set; }

        public bool IsFirePossible =>
            _rotaterInvoker.transform.rotation.z > 0;

        public event Action Checked;

        private void OnEnable()
        {
            IsChecked = false;
            _rotaterInvoker.Rotated += OnSwitchRotated;
        }

        private void OnDisable()
        {
            _rotaterInvoker.Rotated -= OnSwitchRotated;
        }

        public void ChangeFire(bool isActiveFire)
        {
            if (isActiveFire)
            {
                Checked?.Invoke();
                IsChecked = true;
            }

            _fireEffect.SetActive(isActiveFire);
            _gasEffect.SetActive(!isActiveFire);
        }

        private void OnSwitchRotated(float value)
        {
            if (value <= 0)
            {
                ChangeFire(false);
            }
        }
    }
}
