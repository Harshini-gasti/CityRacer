using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CarManager : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    float h;
    public static int fuel_value = 100;
    public static int goldCoinCounter, silverCoinCounter;
    public static int damageIndicator = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(FuelValue());
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal") * speed;
        
    
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(h, rb.velocity.y, rb.velocity.z);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -2.5f, 2.5f), rb.position.y, rb.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("c1"))
        {
            other.gameObject.SetActive(false);
            goldCoinCounter++;
        }

        else if (other.gameObject.CompareTag("c2"))
        {
            
            other.gameObject.SetActive(false);
            silverCoinCounter++;    
        }

        else if (other.gameObject.CompareTag("Rock"))
        {
            other.gameObject.SetActive(false);
            damageIndicator -= 25;
            Debug.Log(damageIndicator);
        }

        else if (other.gameObject.CompareTag("Fuel"))
        {
            other.gameObject.SetActive(false);
            fuel_value = 100;
           
            
        }
        

    }

    IEnumerator FuelValue()
    {
        while(Application.isPlaying)
        {
            yield return new WaitForSeconds(2f);
            fuel_value -= 10;
            Debug.Log(fuel_value);
            if( fuel_value == 0 || damageIndicator ==0)
            {
                yield return new WaitForSeconds(0.5f);

#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#endif
                Application.Quit();
            }
        }
    }
}
