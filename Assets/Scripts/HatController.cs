using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    private float MaxWidth;
    private bool mexer;

    // Start is called before the first frame update
    void Start()
    {
 

        if (cam == null)
        {
            cam = Camera.main;
            rb = GetComponent<Rigidbody2D>();
        }

        Vector3 UpperC = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 dim = cam.ScreenToWorldPoint(UpperC);
        MaxWidth = dim.x - GetComponent<Renderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 rawpos = cam.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 targetPos = new Vector2(Mathf.Clamp(rawpos.x, -MaxWidth, MaxWidth), 0.0f);
        
        if (mexer) rb.MovePosition(targetPos);
    }

    public void MudaEstado(bool estado)
    {
        mexer = estado;
    }
}
