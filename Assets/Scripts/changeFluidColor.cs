using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeFluidColor : MonoBehaviour
{
    public GameObject Fluid;
    public GameObject[] Bubbles;
    public ParticleSystem explosion;
    //public Color redcolor;
    
    // Start is called before the first frame update
    void Start()
    {
        Fluid = GameObject.FindGameObjectWithTag("fluid");
        Bubbles = GameObject.FindGameObjectsWithTag("bubble");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("bottle"))
        {
            Debug.Log(other.gameObject.name);
            Color gColor = other.gameObject.GetComponent<Renderer>().materials[0].GetColor("_Color");
            Fluid.GetComponent<Renderer>().materials[0].SetColor("_FarColor", gColor);
            Fluid.GetComponent<Renderer>().materials[0].SetColor("_SunSpecularColor", gColor);
            Fluid.GetComponent<Light>().color = gColor;
            foreach (GameObject bubble in Bubbles)
            {
                bubble.GetComponent<Renderer>().materials[0].color = gColor;
                bubble.GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", gColor);
            }
            explosion.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
