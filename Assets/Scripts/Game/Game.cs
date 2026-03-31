using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FireGroup;
using GasAnalyzer;

namespace Game
{
    public class Game : MonoBehaviour
    {
        private const int Offset = 1;

        [SerializeField] private List<Burner> _burners;
        [SerializeField] private GasAnalyzer.GasAnalyzer _analyzer;

        [SerializeField] private bool _needRandomizeOnNewLevel = true;
        [SerializeField] private GasConnection _connection;
        [SerializeField] private GasStoveConditions _conditionsGasStove;

        [SerializeField] private GameObject _endWindow;
        [SerializeField] private Button _restartButton;

        private bool _allBurnersChecked = false;
        private bool _connectionChecked = false;

        private void OnEnable()
        {
            _analyzer.Checked += OnAnalyzerCheck;
            _restartButton.onClick.AddListener(OnRestart);

            foreach (Burner item in _burners)
            {
                item.Checked += CheckBurners;
            }
        }

        private void OnDisable()
        {
            _analyzer.Checked -= OnAnalyzerCheck;
            _restartButton.onClick.RemoveListener(OnRestart);

            foreach (Burner item in _burners)
            {
                item.Checked -= CheckBurners;
            }
        }

        private void Start()
        {
            if (_needRandomizeOnNewLevel)
            {
                _connection.Randomize();
                _conditionsGasStove.Randomize();
            }
        }

        private void CheckBurners()
        {
            int countChecked = 0;

            foreach (Burner item in _burners)
            {
                if (item.IsChecked)
                {
                    countChecked++;
                }
            }

            if (countChecked == _burners.Count - Offset)
            {
                _allBurnersChecked = true;
                TryEnd();
            }
        }

        private void OnAnalyzerCheck()
        {
            _connectionChecked = true;
            TryEnd();
        }

        private void TryEnd()
        {
            if (_allBurnersChecked && _connectionChecked)
            {
                _endWindow.SetActive(true);
            }
        }

        private void OnRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
