using UnityEngine;

public class StarfieldGenerator : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private int numberOfStars = 100;
    [SerializeField] private float xRange = 10f;
    [SerializeField] private float yRange = 10f;

    private void Start()
    {
        GameObject starfield = GameObject.Find("Starfield");

        if (starfield != null)
        {
            for (int i = 0; i < numberOfStars; i++)
            {
                float x = Random.Range(-xRange, xRange);
                float y = Random.Range(-yRange, yRange);
                Instantiate(starPrefab, new Vector3(x, y, 10), Quaternion.identity, starfield.transform);
            }
        }
        else
        {
            Debug.LogError("Starfield object not found!");
        }
    }
}
