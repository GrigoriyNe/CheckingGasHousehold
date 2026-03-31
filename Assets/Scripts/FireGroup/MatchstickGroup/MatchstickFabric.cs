using System.Collections.Generic;
using UnityEngine;
using Pool;

namespace FireGroup
{
    public class MatchstickFabric : MonoBehaviour
    {
        [SerializeField] private Matchstick _prefabMatchstick;
        [SerializeField] private Transform _spawnPoint;

        private List<Matchstick> _createdMatchsticks = new List<Matchstick>();
        private Pool<Matchstick> _matchsticks;

        private void Start()
        {
            _matchsticks = new Pool<Matchstick>(_prefabMatchstick);
        }

        private void OnDestroy()
        {
            foreach (Matchstick item in _createdMatchsticks)
            {
                if (item != null)
                {
                    item.Burned -= OnBurn;
                }
            }
        }

        public void Create()
        {
            Matchstick matchstick = _matchsticks.GetItem().GetComponent<Matchstick>();
            matchstick.gameObject.SetActive(true);
            matchstick.transform.rotation = Quaternion.identity;
            matchstick.transform.position = _spawnPoint.position;
            matchstick.Burned += OnBurn;
            _createdMatchsticks.Add(matchstick);
        }

        private void OnBurn(Matchstick matchstick)
        {
            _createdMatchsticks.Remove(matchstick);
            matchstick.Burned -= OnBurn;
            matchstick.gameObject.SetActive(false);
            _matchsticks.ReturnItem(matchstick);
        }
    }
}