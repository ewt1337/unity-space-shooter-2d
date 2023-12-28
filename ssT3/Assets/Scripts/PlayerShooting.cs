using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Laser Shooting Parameters")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject laseBulletPrefab;
    [SerializeField] private GameObject doubleLaserFirePoint1;
    [SerializeField] private GameObject doubleLaserFirePoint2;
    [SerializeField] private float bulletLaserSpeed = 20f;
    [SerializeField] private float bulletLifetime = 3f;
    [SerializeField] private float timeBetweenShots = 0.5f;

    [Header("Rocket Shooting Parameters")]
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private float rocketSpeed = 12f;
    [SerializeField] private float amountFuelForRocket = 5f;
    [SerializeField] private float rocketCooldown = 1.5f;
    private float timeSinceLastRocket;

    [Header("AoELaser Shooting Parameters")]
    [SerializeField] private GameObject pointAoELaser1;
    [SerializeField] private GameObject pointAoELaser2;

    [Header("Plasma Shooting Parameters")]
    [SerializeField] private GameObject plasmaBulletPrefab;
    [SerializeField] private float plasmaBulletSpeed = 9f;
    [SerializeField] private float amountFuelForPlasma = 6f;
    [SerializeField] private float plasmaCooldown = 3f;
    private float timeSinceLastPlasma;


    [Header("Weapon Settings")]
    public bool doubleLaserActive = false;
    public enum WeaponType 
    {   
        Laser, 
        AoELaser,
        Rockets,
        PlasmaGuns
    }
    public WeaponType currentWeapon = WeaponType.Laser;

    [Header("Weapon Keys")]
    [SerializeField] private KeyCode laserKey = KeyCode.Alpha1;
    [SerializeField] private KeyCode rocketsKey = KeyCode.Alpha2;
    [SerializeField] private KeyCode aoeLaserKey = KeyCode.Alpha3;
    [SerializeField] private KeyCode plasmaGunsKey = KeyCode.Alpha4;

    private float timeSinceLastShot;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        HandleShootingInput(); // Handle shooting input
        SwitchWeapon(); // Switch weapons based on input
        UpdateWeaponVisuals(); // Update weapon visuals
        UpdateCooldownTimers(); // Update cooldown timers
    }

    private void HandleShootingInput()
    {
        // Track time since the last shot
        timeSinceLastShot += Time.deltaTime;

        // Check if the fire button is pressed and enough time has passed between shots
        if (Input.GetButton("Fire1") && timeSinceLastShot >= timeBetweenShots)
        {
            // Shoot the selected weapon
            ShootCurrentWeapon();
            // Reset the timer for the next shot
            timeSinceLastShot = 0f;
        }
    }

    private void SwitchWeapon()
    {
        // Check for weapon switch input and update the current weapon
        if (Input.GetKeyDown(laserKey) && currentWeapon != WeaponType.Laser)
        {
            currentWeapon = WeaponType.Laser;
            UpdateWeapon();
        }
        else if (Input.GetKeyDown(rocketsKey) && currentWeapon != WeaponType.Rockets)
        {
            currentWeapon = WeaponType.Rockets;
            UpdateWeapon();
        }
        else if (Input.GetKeyDown(aoeLaserKey) && currentWeapon != WeaponType.AoELaser)
        {
            currentWeapon = WeaponType.AoELaser;
            UpdateWeapon();
        }
        else if (Input.GetKeyDown(plasmaGunsKey) && currentWeapon != WeaponType.PlasmaGuns)
        {
            currentWeapon = WeaponType.PlasmaGuns;
            UpdateWeapon();
        }
    }

    private void UpdateWeapon()
    {
        // Perform actions based on the selected weapon
        switch (currentWeapon)
        {
            case WeaponType.Laser:
                Debug.Log("Current Weapon: Laser");
                break;
            case WeaponType.AoELaser:
                Debug.Log("Current Weapon: AoE Laser");
                break;
            case WeaponType.Rockets:
                Debug.Log("Current Weapon: Rockets");
                break;
            case WeaponType.PlasmaGuns:
                Debug.Log("Current Weapon: Plasma Guns");
                break;
        }
    }

    private void UpdateWeaponVisuals()
    {
        // Toggle the visibility of fire points based on the doubleLaserActive flag
        firePoint.gameObject.SetActive(!doubleLaserActive);
        doubleLaserFirePoint1.SetActive(doubleLaserActive);
        doubleLaserFirePoint2.SetActive(doubleLaserActive);
    }

    private void ShootCurrentWeapon()
    {
        // Perform shooting based on the selected weapon
        switch (currentWeapon)
        {
            case WeaponType.Laser:
                ShootLaser();
                break;
            case WeaponType.Rockets:
                ShootRockets(gameObject);
                break;
            case WeaponType.AoELaser:
                ShootAoELaser();
                break;
            case WeaponType.PlasmaGuns:
                ShootPlasmaGuns(gameObject);
                break;
        }
    }

    private void ShootLaser()
    {
        // Check ammunition before shooting
        if (playerStats.ammunationPlayer > 0)
        {
            // Shoot from the appropriate fire point(s)
            if (doubleLaserActive)
            {
                ShootFromFirePoint(doubleLaserFirePoint1);
                ShootFromFirePoint(doubleLaserFirePoint2);
                playerStats.ammunationPlayer -= 2;
            }
            else
            {
                ShootFromFirePoint(firePoint.gameObject);
                playerStats.ammunationPlayer--;
            }
        }
        else
        {
            Debug.Log("No ammunition available");
        }

        // Check if ammunition is depleted and block shooting
        if (playerStats.ammunationPlayer <= 0)
        {
            Debug.Log("Shooting blocked due to lack of ammunition");
        }
    }

    private void ShootFromFirePoint(GameObject firePointObject)
    {
        GameObject laseBullet = Instantiate(laseBulletPrefab, firePointObject.transform.position, firePointObject.transform.rotation);
        Rigidbody2D rb = laseBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointObject.transform.up * bulletLaserSpeed, ForceMode2D.Impulse);
        Destroy(laseBullet, bulletLifetime);
    }

    private void ShootRockets(GameObject firePointObject)
    {
        // Check if enough time has passed since the last rocket shot
        if (timeSinceLastRocket >= rocketCooldown)
        {
            // Check if there are available rockets
            if (playerStats.rocketsPlayer > 0)
            {
                // Instantiate and shoot the rocket
                GameObject rocket = Instantiate(rocketPrefab, firePointObject.transform.position, firePointObject.transform.rotation);
                Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
                rb.AddForce(firePointObject.transform.up * rocketSpeed, ForceMode2D.Impulse);
                Destroy(rocket, bulletLifetime);

                // Reduce the number of available rockets
                playerStats.rocketsPlayer--;
                playerStats.fuelPlayer -= amountFuelForRocket;

                // Reset the cooldown timer for rockets
                timeSinceLastRocket = 0f;
            }
            else
            {
                Debug.Log("No rockets available");
            }
        }
    }


    private void ShootAoELaser()
    {
        if (playerStats.ammunationPlayer >= 3)
        {
            ShootFromFirePoint(firePoint.gameObject);
            ShootFromFirePoint(pointAoELaser1);
            ShootFromFirePoint(pointAoELaser2);

            playerStats.ammunationPlayer -= 3;
        }
        else
        {
            Debug.Log("Not enough ammo for AoE laser");
        }
    }

    private void ShootPlasmaGuns(GameObject firePointObject)
    {
        // Check if enough time has passed since the last plasma shot
        if (timeSinceLastPlasma >= plasmaCooldown)
        {
            // Instantiate and shoot the plasma bullet
            GameObject plasmaBullet = Instantiate(plasmaBulletPrefab, firePointObject.transform.position, firePointObject.transform.rotation);
            Rigidbody2D rb = plasmaBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePointObject.transform.up * plasmaBulletSpeed, ForceMode2D.Impulse);
            playerStats.fuelPlayer -= amountFuelForPlasma;
            Destroy(plasmaBullet, bulletLifetime);

            // Reset the cooldown timer for plasma guns
            timeSinceLastPlasma = 0f;
        }
    }

    private void UpdateCooldownTimers()
    {
        timeSinceLastRocket += Time.deltaTime;
        timeSinceLastPlasma += Time.deltaTime;
    }
}