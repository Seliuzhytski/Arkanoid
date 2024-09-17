using System;
using System.Collections.Generic;
using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private int _lives = 1;
        [SerializeField] private int _score;
        [SerializeField] private bool _isInvisible;

        #endregion

        #region Events

        public static event Action<Block> OnCreated;
        public static event Action<Block> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            if (_isInvisible)
            {
                _spriteRenderer.color = new Color(255, 255, 255, 0);
                _lives++;
            }

            OnCreated?.Invoke(this);

            UpdateView();
        }

        private void OnDestroy()
        {
            GameService.Instance.AddScore(_score);
            OnDestroyed?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            ApplyDamage();
        }

        #endregion

        #region Private methods

        private void ApplyDamage()
        {
            if (_isInvisible)
            {
                _spriteRenderer.color = new Color(255, 255, 255, 255);
            }

            _lives--;
            if (_lives < 1)
            {
                Destroy(gameObject);
            }
            else
            {
                UpdateView();
            }
        }

        private void UpdateView()
        {
            int index = _lives - 1;

            if (index >= _sprites.Count)
            {
                index = _sprites.Count - 1;
            }

            _spriteRenderer.sprite = _sprites[index];
        }

        #endregion
    }
}