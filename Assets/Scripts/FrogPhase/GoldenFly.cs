using UnityEngine;

public class GoldenFly : MonoBehaviour
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
            spawner.OnGoldenFlyDestroyed();
        }
    }
}
