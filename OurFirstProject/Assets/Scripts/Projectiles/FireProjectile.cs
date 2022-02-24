using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{

    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public Camera cam;
    public float maximumLength;

    private Ray rayMouse;
    private Vector3 direction;
    private Quaternion rotation;
    private GameObject effectToSpawn;
    private bool previousMouseState = false;

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && previousMouseState == false)
        {
            SpawnVFX();
        }
        previousMouseState = Input.GetMouseButton(0);
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if (firePoint != null)
        {

            UpdateDirection();

            vfx = Instantiate(effectToSpawn, firePoint.transform.position, rotation);
            //vfx.transform.rotation = firePoint.transform.rotation;
            vfx.GetComponent<ProjectileMove>().owner = gameObject;
            vfx.SetActive(true);
        } else
        {
            Debug.Log("No Fire Point!");
        }
    }

    void UpdateDirection()
    {
        if (cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximumLength))
            {
                UpdateMouseDirection(gameObject, hit.point);
            }
            else
            {
                var pos = rayMouse.GetPoint(maximumLength);
                UpdateMouseDirection(gameObject, pos);
            }
        }
        else
        {
            Debug.Log("No Camera!");
        }
    }

    void UpdateMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = Vector3.Normalize(destination - obj.transform.position);
        rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

}
