using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private int _lives = 1;

        #endregion

        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D сCollision)
        {
            ApplyDamage();
        }

        #endregion

        #region Private methods

        private void ApplyDamage()
        {
            _lives--;
            if (_lives < 1)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().sprite = _sprites[_lives - 1];
            }
        }

        #endregion
    }
}