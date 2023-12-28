using UnityEngine;

public class RestartKey : MonoBehaviour
{
    [SerializeField] private KeyCode restartKey = KeyCode.R;

    private PlayerStats playerStats;
    private UIButtonManager buttonManager;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        buttonManager = GetComponent<UIButtonManager>();
    }

    private void Update()
    {
        if (playerStats.gameEnded && Input.GetKeyDown(restartKey))
        {
            buttonManager.RestartScene();
        }
    }
}