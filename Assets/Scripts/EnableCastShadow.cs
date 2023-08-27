using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCastShadow : MonoBehaviour
{
    public Material existingMaterial; // Reference to existing material in the Inspector

    void Start()
    {
        if (existingMaterial == null)
        {
            Debug.LogError("Existing material not assigned.");
            return;
        }

        // Find all GameObjects with a SpriteRenderer component
        SpriteRenderer[] spriteRenderers = FindObjectsOfType<SpriteRenderer>();

        // Loop through each SpriteRenderer
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            // Enable Cast Shadows
            spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

            // Assign the existing material
            spriteRenderer.material = existingMaterial;
        }
    }
}
