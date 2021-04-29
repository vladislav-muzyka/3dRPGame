using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer itemMeshRenderer;
    [SerializeField] private MeshFilter itemMeshFilter;
    [SerializeField] private Collider itemCollider;
    public void Init(Mesh itemMesh, Material itemMaterial)
    {
        itemMeshRenderer.material = itemMaterial;
        itemMeshFilter.mesh = itemMesh;
    }
    public void Destroy()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
