using UnityEngine;

namespace Arkanoid.Services
{
    public class PauseService : SingletonMonoBehaviour<PauseService>
    {
        #region Variables

        private bool _isPause;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        #endregion

        #region Private methods

        private void TogglePause()
        {
            _isPause = !_isPause;
            Time.timeScale = _isPause ? 0 : 1;
        }

        #endregion
    }
}