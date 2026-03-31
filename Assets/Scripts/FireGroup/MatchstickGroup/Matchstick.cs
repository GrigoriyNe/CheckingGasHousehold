using System;
using UnityEngine;

namespace FireGroup
{
    public class Matchstick : MonoBehaviour
    {
        public event Action<Matchstick> Burned;

        private void OnTriggerStay(Collider collider)
        {
            if (collider.TryGetComponent(out Burner burnerFirerer))
            {
                if (burnerFirerer.IsFirePossible)
                {
                    burnerFirerer.ChangeFire(true);
                    Burned?.Invoke(this);
                }
            }
        }
    }
}
