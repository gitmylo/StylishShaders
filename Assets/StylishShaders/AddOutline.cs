using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AddOutline : MonoBehaviour
{
    public Material outlineMaterial;
    // Start is called before the first frame update
    void Start()
    {
        //Apply the outline
        addOutline(this.gameObject);
    }

    void addOutline(GameObject g)
    {
        var renderers = g.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            var go = renderer.gameObject;
            var c = Instantiate(go, go.transform.parent);
            var r = c.GetComponent<Renderer>();
            
            //outlines don't cast shadows dummy
            r.shadowCastingMode = ShadowCastingMode.Off;
            
            //set material/materials of the clone to the outline material
            if (r.material != null) r.material = outlineMaterial;
            if (r.materials != null && r.materials.Length != 0)
                for (int i = 0; i < r.materials.Length; i++) r.materials[i] = outlineMaterial;
        }
    }
}
