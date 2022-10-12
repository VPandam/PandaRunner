using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject target;
    // Update is called once per frame
    void Update()
    {

        if (target)
        {
            //Move the projectile to the target position + 0.5 up
            transform.position = Vector3.MoveTowards(transform.position,
             target.transform.position + transform.up * 0.5f, projectileSpeed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("OnTrigger");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("TagEnemy");
            Hit(other);
        }
    }
    void Hit(Collider other)
    {
        EnemyManager enemyHitted = other.gameObject.GetComponent<EnemyManager>();
        enemyHitted.TakeDamage();
        Destroy(gameObject);
        Debug.Log("DestroyGO");
    }
}
