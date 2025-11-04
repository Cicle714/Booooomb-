using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private GameObject PlayerObject;
    [SerializeField] 
    private GameObject CameraObject;

    [SerializeField]
    private GameObject Ribbon;

    [SerializeField]
    private float roteZ;

    [SerializeField]
    private float rotationPow;

    [SerializeField]
    private float GravityPow;

    [SerializeField]
    private float GravityMaxY;
    [SerializeField]
    private float GravityMaxX;

    [SerializeField]
    float debugX;
    [SerializeField]
    private float debugY;


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

        rb.AddForce(new Vector2(Mathf.Sin(roteZ / 180.0f * Mathf.PI) , (-Mathf.Cos((roteZ / 180.0f) * Mathf.PI))));

        debugX = Mathf.Sin(roteZ / 90.0f * Mathf.PI);
        debugY = (-Mathf.Cos((roteZ / 90.0f) * Mathf.PI));


        if (rb.linearVelocityX > GravityMaxX )
            rb.linearVelocityX = GravityMaxX;
        if (-rb.linearVelocityX < -GravityMaxX)
            rb.linearVelocityX = -GravityMaxX;
        if (rb.linearVelocityY > GravityMaxY ) 
            rb.linearVelocityY = GravityMaxY;
        if (-rb.linearVelocityY < -GravityMaxY)
            rb.linearVelocityY = -GravityMaxY;


        CameraObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, roteZ);
        CameraObject.transform.position = new Vector3(transform.position.x,transform.position.y,-10);
    }
}
