using System.Collections;
using UnityEngine;

namespace GasAnalyzer
{
    public class GasAnalyzerAnimator : MonoBehaviour
    {
        private const string IsHaveLeak = "IsHaveLeak";
        private const string IsNotHaveLeak = "IsNotHaveLeak";
        private const string IsProcessing = "IsProcessing";

        [SerializeField] private Animator _animator;
        [SerializeField] private float _valueDelayShowingResult = 2f;
        [SerializeField] private float _valueDelayShowingProcessing = 1f;

        private WaitForSeconds _delayShowingResult;
        private WaitForSeconds _delayShowingProcessing;

        private bool _isShowing = false;
        private bool _isHaveLeak = false;

        private void Start()
        {
            _delayShowingResult = new WaitForSeconds(_valueDelayShowingResult);
            _delayShowingProcessing = new WaitForSeconds(_valueDelayShowingProcessing);
        }

        public void ShowAnimation(bool isHaveLeak)
        {
            if (_isShowing)
                return;

            _isShowing = true;
            _isHaveLeak = isHaveLeak;

            _animator.SetBool(IsProcessing, true);
            StartCoroutine(DeactivatedProcessing());
        }

        private IEnumerator DeactivatedProcessing()
        {
            yield return _delayShowingProcessing;
            _animator.SetBool(IsProcessing, false);
            ShowResult();
        }

        private void ShowResult()
        {
            if (_isHaveLeak)
            {
                _animator.SetBool(IsHaveLeak, true);
                StartCoroutine(DeactivatedAnimation(IsHaveLeak));
            }
            else
            {
                _animator.SetBool(IsNotHaveLeak, true);
                StartCoroutine(DeactivatedAnimation(IsNotHaveLeak));
            }
        }

        private IEnumerator DeactivatedAnimation(string nameAnimation)
        {
            yield return _delayShowingResult;
            _animator.SetBool(nameAnimation, false);
            _isShowing = false;
        }
    }
}