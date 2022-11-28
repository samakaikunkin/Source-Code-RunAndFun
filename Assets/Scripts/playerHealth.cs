using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public float TakeDamage = 1f;
    [SerializeField] HealthBar healthBar;
    public AudioClip AudioCoin;
    private AudioSource audio;
    public int _score;
    public int score_value = 1;
    public Text ScoreText;
    public int NextScene = 2;
    public Animator anim; //รับ animator controller
    public string anim_Dead = "Player_Dead";
    public bool VipOn = true;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth -= Time.deltaTime;

        if (currentHealth > 0.1f) 
        { 
            playerDamage(TakeDamage/1000);
        }
        else
        {
            SceneManager.LoadScene(NextScene);
        }

        ScoreText.text = "SCORE: "+ _score;
    }

    private void playerDamage(float dmg) {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }

    private void playerHeal(float healing)
    {
        currentHealth += healing;
        healthBar.SetHealth(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            _score += score_value;
            audio.clip = AudioCoin;
            audio.Play();
            RetureScore();
            playerHeal(5);
            Destroy(collision.gameObject);
        }
        else if((collision.gameObject.tag == "CoinVip")){
            if(VipOn == true){
                int randomScore = Random.Range(1, score_value*3);
                _score += randomScore;
                audio.clip = AudioCoin;
                audio.Play();
                RetureScore();
                playerHeal(10);
                Destroy(collision.gameObject);
            }
            else{
                _score += score_value;
                audio.clip = AudioCoin;
                audio.Play();
                RetureScore();
                playerHeal(5);
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.tag == "Respawn")
        {
            playerDamage(5);
        }
    }

    public void RetureScore(){
        if(_score > PlayerPrefs.GetInt("highscore")){
            PlayerPrefs.SetInt("highscore", _score);
        }
        
    }
}
