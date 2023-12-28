using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private GameObject liveScreen;
    [SerializeField] private GameObject deathScreen;

    private void Start()
    {
        if (deathScreen != null)
        {
            deathScreen.SetActive(false);
        }

        if (liveScreen != null)
        {
            liveScreen.SetActive(true);
        }
    }

    public void ShowDeathScreen()
    {
        if (liveScreen != null)
        {
            liveScreen.SetActive(false);
        }

        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }
    }

    public void ToggleLiveScreen()
    {
        if (liveScreen != null)
        {
            liveScreen.SetActive(!liveScreen.activeSelf);
        }
    }
}
