using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public float speed;
    public float fireRate;
    public Material material;
    public GameObject owner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No speed!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != owner)
        {
            speed = 0;
            Destroy(gameObject);

            Debug.Log(collision.gameObject);

            if (collision.gameObject.GetComponent<Explode>() == null)
            {
                Explode explode = collision.gameObject.AddComponent<Explode>();
                explode.material = material;
            }
        }
    }

}
