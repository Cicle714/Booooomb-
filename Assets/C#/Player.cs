using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private GameObject Object;

    [SerializeField]
    private GameObject Ribbon;

    private float roteZ;

    [SerializeField]
    private float rotationPow;

    private float GravityPow;

    [SerializeField]
    private float GravityMaxY;
    [SerializeField]
    private float GravityMaxX;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            roteZ += Time.deltaTime * rotationPow;
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            roteZ -= Time.deltaTime * rotationPow;
        }
        rb.AddForce(new Vector2(Mathf.Sin(roteZ / 90.0f),-Mathf.Cos(roteZ / 90.0f)));

        if(rb.linearVelocityX > GravityMaxX )
            rb.linearVelocityX = GravityMaxX;
        if(rb.linearVelocityY > GravityMaxY ) 
            rb.linearVelocityY = GravityMaxY;


        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, roteZ);
        Ribbon.transform.rotation = Quaternion.Euler(0,0,transform.rotation.z);
    }
}
