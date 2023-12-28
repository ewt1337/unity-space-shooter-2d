using UnityEngine;

public class BonusSystem : MonoBehaviour
{
    [Header("Double Laser Settings")]
    [SerializeField] private string doubleLaserTag = "DoubleLaser";
    [SerializeField] private float minDurationDoubleLaser = 15f;
    [SerializeField] private float maxDurationDoubleLaser = 45f;
    [Header("HealthPack Settings")]
    [SerializeField] private string healthPackTag = "HealthPack";
    [SerializeField] private float minHealthPackAmount = 25f;
    [SerializeField] private float maxHealthPackAmount = 75f;
    [Header("AmmoPack Settings")]
    [SerializeField] private string ammoPackTag = "AmmoPack";
    [SerializeField] private int minAmmoPackAmount = 75;
    [SerializeField] private int maxAmmoPackAmount = 250;
    [Header("FuelPack Settings")]
    [SerializeField] private string fuelPackTag = "FuelPack";
    [SerializeField] private float minFuelPackAmount = 25f;
    [SerializeField] private float maxFuelPackAmount = 85f;
    [Header("ArmorPack Settings")]
    [SerializeField] private string armorPackTag = "ArmorPack";
    [SerializeField] private float minArmorPackAmount = 25f;
    [SerializeField] private float maxArmorPackAmount = 75f;
    [Header("RocketPack Settings")]
    [SerializeField] private string rocketPackTag = "RocketPack";
    [SerializeField] private int minRocketPackAmount = 2;
    [SerializeField] private int maxRocketPackAmount = 9;

    private PlayerShooting playerShooting;
    private PlayerStats playerStats;

    void Start()
    {
        playerShooting = GetComponent<PlayerShooting>();
        playerStats = GetComponent<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(doubleLaserTag))
        {
            ActivateDoubleLaser(other);
        }
        else if (other.CompareTag(healthPackTag))
        {
            ActivateHealthPack(other);
        }
        else if (other.CompareTag(ammoPackTag))
        {
            GiveAmmo(other);
        }
        else if (other.CompareTag(fuelPackTag))
        {
            GiveFuel(other);
        }
        else if (other.CompareTag(armorPackTag))
        {
            GiveArmor(other);
        }
        else if (other.CompareTag(rocketPackTag))
        {
            GiveRockets(other);
        }
    }

    void ActivateDoubleLaser(Collider2D other)
    {
        float randomLaserDuration = Random.Range(minDurationDoubleLaser, maxDurationDoubleLaser);
        playerShooting.doubleLaserActive = true;
        Debug.Log("Double laser activated for " + randomLaserDuration + " seconds");
        Destroy(other.gameObject);
        Invoke("DeactivateDoubleLaser", randomLaserDuration);
    }

    void DeactivateDoubleLaser()
    {
        playerShooting.doubleLaserActive = false;
        Debug.Log("Double laser deactivated");
    }

    void ActivateHealthPack(Collider2D other)
    {
        float healthToAdd = Random.Range(minHealthPackAmount, maxHealthPackAmount);
        playerStats.healthPlayer += healthToAdd;
        Debug.Log("Health pack collected. Health + " + healthToAdd);
        Destroy(other.gameObject);
    }

    void GiveAmmo(Collider2D other)
    {
        int ammoToAdd = Random.Range(minAmmoPackAmount, maxAmmoPackAmount);
        playerStats.ammunationPlayer += ammoToAdd; 
        Debug.Log("Ammo pack collected. Ammo + " + ammoToAdd);
        Destroy(other.gameObject);
    }

    void GiveFuel(Collider2D other)
    {
        float fuelToAdd = Random.Range(minFuelPackAmount, maxFuelPackAmount);
        playerStats.fuelPlayer += fuelToAdd;
        Debug.Log("Fuel pack collected. Fuel " + fuelToAdd);
        Destroy(other.gameObject);
    }

    void GiveArmor(Collider2D other)
    {
        float armorToAdd = Random.Range(minArmorPackAmount, maxArmorPackAmount);
        playerStats.armorPlayer += armorToAdd;
        Debug.Log("Armor pack collected. Armor " + armorToAdd);
        Destroy(other.gameObject);
    }

    void GiveRockets(Collider2D other)
    {
        int rocketsToAdd = Random.Range(minRocketPackAmount, maxRocketPackAmount);
        playerStats.rocketsPlayer += rocketsToAdd;
        Debug.Log("Rocket pack collected. Rockets + " + rocketsToAdd);
        Destroy(other.gameObject);
    }
}