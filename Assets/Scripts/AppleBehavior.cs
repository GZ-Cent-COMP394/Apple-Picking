using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehavior : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public bool SuperApple=false;
    public bool EvilApple=false;
    public GameObject childObject;
    Color defColor;
    // Start is called before the first frame update
    //[Range(0f, 4f)] [SerializeField] float m_GravityMultiplier = 2f;
    private void OnEnable()
    {
        float value = Random.value;
        if (value < 0.33)
        {
            //EvilApple = true;
            //childObject.GetComponent<Renderer>().material.color = Color.black;

        }
        else if (value > .66)
        {
            //SuperApple = true;
            //GetComponentInChildren<Renderer>().material.color = Color.yellow;
            //childObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            //EvilApple = false;
            //SuperApple = false;
            //GetComponentInChildren<Renderer>().material.color = Color.white;
            //childObject.GetComponent<Renderer>().material.color = Color.white;
        }

        m_Rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        //float value = Random.value;
        //if (value < 0.33)
        //{
        //    EvilApple=true;
        //    GetComponentInChildren<Renderer>().material.color = Color.black;

        //}else if (value > .66)
        //{
        //    SuperApple = true;
        //    GetComponentInChildren<Renderer>().material.color = Color.yellow;
        //    //GetComponent<Renderer>().material.color = Color.yellow;
        //}
        //else
        //{
        //    EvilApple = false;
        //    SuperApple = false;
        //    GetComponentInChildren<Renderer>().material.color = Color.white;
        //    //GetComponent<Renderer>().material.color = Color.white;
        //}

        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down,out hit))
        {
            float offsetDistance = hit.distance;
        }
        Debug.DrawLine(transform.position, hit.point, Color.cyan);
        //Debug.DrawRay(transform.position, hit.point, Color.cyan);
        //Vector3 groundTarget =  hit.point;
        //Instantiate a target aon ground
        //Instantiate(target, hit.point, Quaternion.LookRotation(hit.normal));
        
    }
}
