using UnityEngine;

namespace Handlers.UI
{
    public class PauseScreenHandler : MonoBehaviour
    {
        [SerializeField] CanvasGroup pauseScreenCanvasGroup;

        // TODO: Get this pause event somewhere else?
        Player player;

        void Start()
        {
            player = FindObjectOfType<Player>();
            player.PauseToggled += OnPauseToggled;
        }

        void OnDestroy()
        {
            player.PauseToggled -= OnPauseToggled;
        }

        void OnPauseToggled(bool isPaused)
        {
            pauseScreenCanvasGroup.alpha = isPaused ? 1f : 0f;
        }
    }
}