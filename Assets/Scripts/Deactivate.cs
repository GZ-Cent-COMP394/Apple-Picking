using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public float lifetimemax=5;
    public float lifetime=5;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Timeout");
    }

    // Update is called once per frame
    void Update()
    {
        if(lifetime > 0)
        {
            lifetime = lifetime - Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
            lifetime = lifetimemax;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
            
    }

    IEnumerable Timeout()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);

    }
}
