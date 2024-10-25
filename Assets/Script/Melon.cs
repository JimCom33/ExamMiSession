using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melon : MonoBehaviour
{
    bool canCollect = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canCollect)
        {
            canCollect = false;
            FindAnyObjectByType<Player>().CollectMelon();
            Destroy(gameObject);
        }
    }
}
