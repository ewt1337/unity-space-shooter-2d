using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float healthPlayer = 100f;
    public float armorPlayer = 200f;
    public float fuelPlayer = 100f;
    public int ammunationPlayer = 150;
    public int rocketsPlayer = 5;

    [SerializeField] private TextMeshProUGUI textHealthPlayer;
    [SerializeField] private TextMeshProUGUI textArmorPlayer;
    [SerializeField] private TextMeshProUGUI textFuelPlayer;
    [SerializeField] private TextMeshProUGUI textAmmunationPlayer;
    [SerializeField] private TextMeshProUGUI textRocketsPlayer;

    [SerializeField] private float fuelUsagePerSecond = 1f;
    
    [SerializeField, Range(0f, 1f)]
    private float armorDamageReduction = 0.8f;
   
    public bool gameEnded = false;
    private PlayerStatsUI playerStatsUI;

    private void Start()
    {
        playerStatsUI = GetComponent<PlayerStatsUI>();
    }

    private void Update()
    {
        if (!gameEnded && (fuelPlayer <= 0 || healthPlayer <= 0))
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (playerStatsUI != null)
            {
                playerStatsUI.ToggleLiveScreen();
            }
        }
        
        textHealthPlayer.text = "Health: " + Mathf.Round(healthPlayer).ToString();
        textArmorPlayer.text = "Armor: " + Mathf.Round(armorPlayer).ToString();
        textFuelPlayer.text = "Fuel: " + Mathf.Round(fuelPlayer).ToString();
        textAmmunationPlayer.text = "Ammunition: " + ammunationPlayer.ToString();
        textRocketsPlayer.text = "Rockets: " + rocketsPlayer.ToString();
    }

    public void TakeDamage(float damage) 
    {
        if (armorPlayer > 0) 
        {
            float armorDamage = damage * armorDamageReduction;
            damage -= armorDamage;
            armorPlayer -= armorDamage;
            armorPlayer = Mathf.Max(armorPlayer, 0f);
        }

        healthPlayer -= damage;

        if (healthPlayer <= 0) 
        {
            GameOver();
        }
    }


    private void GameOver()
    {
        gameEnded = true;
        Debug.Log("Game end");

        if (playerStatsUI != null)
        {
            playerStatsUI.ShowDeathScreen();
        }

        Time.timeScale = 0;
    }

    public void UseFuel()
    {
        fuelPlayer -= fuelUsagePerSecond * Time.deltaTime;
        fuelPlayer = Mathf.Clamp(fuelPlayer, 0f, 100f);
    }
}
