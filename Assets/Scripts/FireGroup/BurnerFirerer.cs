using UnityEngine;
using Switch;

namespace FireGroup
{
    public class BurnerFirerer : MonoBehaviour
    {
        [SerializeField] private GameObject _fireEffect;
        [SerializeField] private GameObject _gasEffect;
        [SerializeField] private RotaterInvoker _rotaterInvoker;

        private void OnEnable()
        {
            _rotaterInvoker.Rotated += OnSwitchRotated;
        }

        private void OnDisable()
        {
            _rotaterInvoker.Rotated -= OnSwitchRotated;
        }

        private void OnSwitchRotated(float value)
        {
            if (value <= 0)
            {
                ChangeFire(false);
            }
        }

        public void ChangeFire(bool isActiveFire)
        {
            _fireEffect.SetActive(isActiveFire);
            _gasEffect.SetActive(!isActiveFire);
        }
    }
}