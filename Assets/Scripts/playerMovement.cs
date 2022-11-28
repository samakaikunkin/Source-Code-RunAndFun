using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed_player = 300f; //กำหนดความเร็วเท่ากับ 5
    public float jump_player = 1200f; //ความสูงของการกระโดด
    private float move_x = 0f; //เคลื่อนที่ในแนวแกน x 
    public Animator anim; //รับ animator controller
    private Rigidbody2D rb;
    public bool isGround; //ตรวจสอบว่ายืนอยู่บนพื้นหรือไม่
    private bool mirrered; //หันตัวไปทางซ้าย

    public AudioClip JumpAudio;
    private AudioSource audio;

    public int NextScene = 3;

    void Start() //เริ่มต้นในการทำงาน
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>(); // เรียกใช้ Rigidbody
        isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        move_x = Input.GetAxis("Horizontal"); //เคลื่อนที่ไปในแนวแกน x หรือแนวนอน

        anim.SetFloat("speed", Mathf.Abs(move_x));

        if (Input.GetButtonDown("Jump") && isGround == true) //Ground
        {
            Jumppp();
        }

        if (!isGround)
        {
            anim.SetBool("IsJump", true);
        }

        if(move_x < 0.0f && mirrered == false){
            FilpPlayer();

        }
        else if (move_x > 0.0f && mirrered == true){
            FilpPlayer();

        }

    }

    private void FixedUpdate() {
        rb.velocity = new Vector2((move_x * speed_player * Time.deltaTime), rb.velocity.y);
    }

    private void Jumppp()
    {
        rb.AddForce(Vector2.up * jump_player);
        isGround = false; //Ground
        anim.SetBool("IsJump", true);
        audio.clip = JumpAudio;
        audio.Play();
    }

    private void FilpPlayer()
    {
        mirrered = !mirrered;
        Vector2 local = gameObject.transform.localScale;
        local.x *= -1;
        transform.localScale = local;
    }

    private void OnCollisionEnter2D(Collision2D other) //Ground
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Box")
        {
            isGround = true;
            anim.SetBool("IsJump", false);
        }

        if(other.gameObject.tag == "Finish"){
            SceneManager.LoadScene(NextScene);
        }
    }
}
