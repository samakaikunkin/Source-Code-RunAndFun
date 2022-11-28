using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move_monster : MonoBehaviour
{
    public int speed = 1;
    public int xMove = 1;
    public int NextScene = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * speed;

        if (hit.distance < 0.5f)
        {
            Flip();

            if (hit.collider.tag == "Player")
            {
                SceneManager.LoadScene(NextScene);
            }
        }
    }
    void Flip()
    {
        if (xMove > 0)
        {
            xMove = -1;
        }
        else
        {
            xMove = 1;
        }
    
    }
}
