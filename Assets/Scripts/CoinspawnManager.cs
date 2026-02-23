using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinspawnManager : MonoBehaviour
{

    [SerializeField] GameObject coinPool;
    [SerializeField] string[] tagNames;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoinSpawnActive());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoinSpawnActive()
    {
        while (Application.isPlaying)
        {
            //GameObject g = coinPool.GetComponent<AdvancedObjectPool>().GetPooledObject(tagNames[Random.Range(0, tagNames.Length)]);
            GameObject coin = coinPool.GetComponent<AdvancedObjectPool>().GetPooledObject(tagNames[Random.Range(0, tagNames.Length)]);
            if (coin != null)
            {
                coin.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, transform.position.z);
                //g.transform.rotation = transform.rotation;
                coin.SetActive(true);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
