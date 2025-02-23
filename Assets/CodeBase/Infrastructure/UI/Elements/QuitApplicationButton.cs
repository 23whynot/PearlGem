using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.UI.Elements
{
    public class QuitApplicationButton : MonoBehaviour
    {
        [SerializeField] private Button quitButton;

        private void OnEnable() =>
            quitButton.onClick.AddListener(QuitApplication);

        private void OnDisable() =>
            quitButton.onClick.RemoveListener(QuitApplication);

        private void QuitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}