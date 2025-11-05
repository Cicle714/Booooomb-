using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            gameManager.clear = true;
            gameManager.gameOver = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 360 * Time.deltaTime, 0);
        if(gameManager.gameOver) {
            Destroy(gameObject);
        }
    }
}
