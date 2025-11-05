using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb; 

    [SerializeField]
    private GameObject PlayerObject; //プレイヤー

    private Camera CameraObject;　//カメラ

    [SerializeField]
    private float roteZ;　//Z軸の回転の数値

    [SerializeField]
    private float rotationPow;　//Z軸を回転させる速さ

    [SerializeField]
    private float GravityPow;　//重力の強さ

    [SerializeField]
    private float GravityMaxY;　//Y軸の重力の最大値
    [SerializeField]
    private float GravityMaxX;　//X軸の重力の最大値


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CameraObject = FindObjectOfType<Camera>(); 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //方向キー入力で回転
        if(Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            roteZ += Time.deltaTime * rotationPow;
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            roteZ -= Time.deltaTime * rotationPow;
        }

        //重力の計算
        rb.AddForce(new Vector2(Mathf.Sin(roteZ / 180.0f * Mathf.PI)*GravityPow, (-Mathf.Cos((roteZ / 180.0f) * Mathf.PI)*GravityPow)));


        //重力が最大値を超えないようにする
        if (rb.linearVelocityX > GravityMaxX )
            rb.linearVelocityX = GravityMaxX;
        if (rb.linearVelocityX < -GravityMaxX)
            rb.linearVelocityX = -GravityMaxX;

        if (rb.linearVelocityY > GravityMaxY ) 
            rb.linearVelocityY = GravityMaxY;
        if (rb.linearVelocityY < -GravityMaxY)
            rb.linearVelocityY = -GravityMaxY;

        //カメラを追従させ、回転させる
        CameraObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, roteZ);
        CameraObject.transform.position = new Vector3(transform.position.x,transform.position.y,-10);
    }
}
