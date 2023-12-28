using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public static PlayerReference Instance { get; private set; }
    public static Transform PlayerTransform { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            PlayerTransform = transform;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
