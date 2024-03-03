using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSystem : MonoBehaviour
{
    private List<Collectable> items = new List<Collectable>(10000);

    void Update()
    {
        // analyze what close to player, and disable visual for all other GO
        
    }

    public void CreateNewCollectable(IItem item, Vector3 position)
    {
        // object pool will init new collectable and place  
    }
}
