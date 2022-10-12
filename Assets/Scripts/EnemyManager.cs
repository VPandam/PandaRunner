using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float hp;
    Material _material;
    [SerializeField] Material _hittedMaterial;
    [SerializeField] GameObject lodGO;
    SkinnedMeshRenderer[] _meshRenderers;

    private void Start()
    {
        lodGO.GetComponentsInChildren<MeshRenderer>();

        {
            _meshRenderers = lodGO.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer mesh in _meshRenderers)
            {
                _material = mesh.material;
            }
        }
        // _material = gameObject.GetComponentInChildren<Material>();


    }

    public void TakeDamage()
    {
        StartCoroutine(ChangeColorOnHit());
    }

    IEnumerator ChangeColorOnHit()
    {
        Debug.Log("ChangeColor");
        foreach (SkinnedMeshRenderer mesh in _meshRenderers)
        {

            mesh.material = _hittedMaterial;
            Debug.Log(mesh.name + " material: " + mesh.material.name);
        }

        yield return new WaitForSeconds(0.08f);

        foreach (SkinnedMeshRenderer mesh in _meshRenderers)
        {
            mesh.material = _material;
            Debug.Log(mesh.name + " material: " + mesh.material.name);
        }
    }

}
