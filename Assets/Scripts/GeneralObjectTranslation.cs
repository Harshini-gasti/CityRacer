using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralObjectTranslation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    //[SerializeField] float x;
    //[SerializeField] float y;
    //[SerializeField] float z;
    [SerializeField] Vector3 direction;
    void Start()
    {
        //transform.Translate(Vector3.forward);
        //Destroy(gameObject);
        //gameObject.name = "Voijay";
        //Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(25 * Time.deltaTime, 0,45f * Time.deltaTime);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(new Vector3(x, y, z) * Time.deltaTime * speed);
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }

   
}
