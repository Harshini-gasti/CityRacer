using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralObjectRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;
    void Start()
    {
        //transform.Rotate(0, 45f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform .Rotate(0, 45f* Time.deltaTime , 0);
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }
}
