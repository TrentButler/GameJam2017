using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            other.GetComponent<EnemyBehaviour>().HitPoints -= 1;
            //other.GetComponent<EnemyBehaviour>().destroy = true;
            Destroy(gameObject);
        }
    }
}
