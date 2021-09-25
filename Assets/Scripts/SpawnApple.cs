using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple : MonoBehaviour
{
    GameObject obj;
    public float minWait;
    public float maxWait;
    public float rangex;
    public float rangey;
    public float rangez;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");

    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        obj = ObjectPool.SharedInstance.GetPooledObject();
        if (obj != null)
        {
            obj.transform.position = Randomizer(transform.position);
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);
        }
        StartCoroutine("Spawn");
    }

    Vector3 Randomizer(Vector3 v)
    {
        float randx = Random.Range(v.x - rangex, v.x + rangex);
        float randy = Random.Range(v.y - rangey, v.y + rangey);
        float randz = Random.Range(v.z - rangex, v.z + rangex);
        return new Vector3(randx, randy, randz);
    }
}
