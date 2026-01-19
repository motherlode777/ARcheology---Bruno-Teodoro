using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactCleaner : MonoBehaviour
{
    [SerializeField] private Material cleanMaterial;
    [SerializeField] private MeshRenderer artifactRenderer;

    public void Clean()
    {
        if (artifactRenderer != null && cleanMaterial != null)
        {
            artifactRenderer.material = cleanMaterial; 
        }
    }
}
