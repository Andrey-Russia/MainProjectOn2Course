using UnityEngine;

public class MobCounter : MonoBehaviour
{
    public int EnemiesKilled { get; private set; }

    public void IncrementKillCount()
    {
        EnemiesKilled++;
    }
}