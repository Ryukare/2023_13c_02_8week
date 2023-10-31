
using UnityEngine;

public class Diamond : Collectible
{
    protected override void Collect()
    {
        Destroy(gameObject);
    }
}
