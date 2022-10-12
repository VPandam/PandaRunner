using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] ParticleSystem projectilePS;
    [SerializeField] GameObject projectileGO;
    [SerializeField] GameObject shootStartPoint;
    Vector3 overlapBoxStart;
    [SerializeField] LayerMask EnemyLayerMask;
    Collider[] enemyColliders;
    [SerializeField] float range;
    [SerializeField] float projectileSpeed;
    Vector3 enemyDetectionBoxSize;

    //Shooting
    [SerializeField]
    float fireRate = 1;
    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        overlapBoxStart = shootStartPoint.transform.position + Vector3.forward;
        enemyDetectionBoxSize = new Vector3(18, 3, range * 2f);
    }

    private void FixedUpdate()
    {
        enemyColliders = Physics.OverlapBox(overlapBoxStart + Vector3.forward * range,
        enemyDetectionBoxSize / 2, Quaternion.identity, EnemyLayerMask);

    }
    // Update is called once per frame
    void Update()
    {
        if (counter < fireRate)
        {
            counter += Time.deltaTime;
        }

        if (enemyColliders.Length > 0 && counter >= fireRate)
        {
            Shoot();
            counter = 0;
        }
    }
    void Shoot()
    {
        GameObject target = enemyColliders[0].gameObject;
        float distanceToTarget;
        foreach (Collider enemyCol in enemyColliders)
        {
            float distance = Vector3.Distance(transform.position, enemyCol.transform.position);
            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distance < distanceToTarget)
            {
                target = enemyCol.gameObject;
            }
        }

        GameObject projectile = Instantiate(projectileGO, shootStartPoint.transform.position,
         Quaternion.identity, shootStartPoint.transform);
        projectile.GetComponent<MoveProjectile>().target = target;
        projectile.GetComponent<MoveProjectile>().projectileSpeed = projectileSpeed;

    }
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawCube(overlapBoxStart + Vector3.forward * range, enemyDetectionBoxSize);
    // }

}
