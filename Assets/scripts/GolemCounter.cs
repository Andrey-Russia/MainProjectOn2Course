using UnityEngine;

public class GolemCounter : MonoBehaviour
{
    [SerializeField] private GameObject secretObject;
    [SerializeField] private int requiredKills = 4;

    private int enemiesKilled = 0;

    private void Start()
    {
        if (secretObject != null)
        {
            secretObject.SetActive(false);
        }
    }

    public void IncrementKillCount()
    {
        enemiesKilled++;

        if (enemiesKilled >= requiredKills && secretObject != null)
        {
            secretObject.SetActive(true);
        }
    }
}