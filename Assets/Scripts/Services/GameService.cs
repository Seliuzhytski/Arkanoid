using System;
using Arkanoid.Game;
using UnityEngine;

namespace Arkanoid.Services
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Variables

        [SerializeField] private int _score;
        [SerializeField] private int _life = 3;

        private Ball _ball;
        private GameObject _gameOverScreen;
        private Platform _platform;

        #endregion

        #region Events

        public event Action<int> OnScoreChanged;

        #endregion

        #region Properties

        public int Life => _life;

        public int Score => _score;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            LevelService.Instance.OnAllBlocksDestroyed += AllBlocksDestroyedCallback;
            _gameOverScreen = GameObject.FindWithTag("Finish");
            _gameOverScreen.SetActive(false);
        }

        private void OnDestroy()
        {
            LevelService.Instance.OnAllBlocksDestroyed -= AllBlocksDestroyedCallback;
        }

        #endregion

        #region Public methods

        public void AddScore(int value)
        {
            _score += value;
            OnScoreChanged?.Invoke(_score);
        }

        public void LoseLife()
        {
            _life--;

            if (_life < 1)
            {
                GameOver();
            }

            _ball = FindObjectOfType<Ball>();
            _platform = FindObjectOfType<Platform>();

            _ball.IsStarted = false;
            _ball.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _ball.gameObject.GetComponent<Rigidbody2D>().transform.position = _platform.transform.position;
        }

        #endregion

        #region Private methods

        private void AllBlocksDestroyedCallback()
        {
            SceneLoaderService.LoadNextLevelTest();
        }

        private void GameOver()
        {
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);
        }

        #endregion
    }
}