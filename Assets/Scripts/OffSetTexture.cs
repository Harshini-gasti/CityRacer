using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChooseAxis
{
    X, Y
}
public class OffSetTexture : MonoBehaviour
{
    // Start is called before the first frame update
    // Scroll main texture based on time
    [SerializeField] float scrollSpeed = 0.1f;
    Renderer rend;

    [SerializeField] ChooseAxis axis;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;

        if (axis == ChooseAxis.X)
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        else if (axis == ChooseAxis.Y)
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }

    }

}
