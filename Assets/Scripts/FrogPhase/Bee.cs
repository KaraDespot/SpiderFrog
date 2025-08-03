using UnityEngine;

public class Bee : MonoBehaviour
{
    private FlySpawner spawner;

    public void SetSpawner(FlySpawner flySpawner)
    {
        spawner = flySpawner;
    }
    void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.OnBeeDestroyed();
        }
    }
}
