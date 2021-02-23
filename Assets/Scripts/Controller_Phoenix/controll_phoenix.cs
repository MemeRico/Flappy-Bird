using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controll_phoenix : MonoBehaviour {
    public static controll_phoenix instance;

    public float lucDay;
    private Rigidbody2D body;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;
    //[SerializeField]
    public AudioClip flyClip, pingClip, deadClip;

    private bool isAlive;
    private bool didFlap;

    private GameObject spawner;
    
    public bool end;
    public int score;
    void Awake () {
        isAlive = true;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _makeInstance();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }
    void _makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

	void FixedUpdate () {
        _birdMoveMent();
	}

    public void _click_Button_phoenix_bounce(){
        didFlap = true;
    }
    void _birdMoveMent(){
        if (isAlive)
        {
            if (didFlap)
            {
                didFlap = false;
                body.velocity = new Vector2(body.velocity.x, lucDay);
                audioSource.PlayOneShot(flyClip);
            }

        
            
        }
        if (body.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, body.velocity.y / 10);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (body.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -body.velocity.y / 10);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        if (Input.GetMouseButtonDown(0))
        {

        }

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder")
        {
            score++;
            if (gamePlayController.instance != null){
                gamePlayController.instance._setScore(score);
            }
            audioSource.PlayOneShot(pingClip);
               
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe"|| collision.gameObject.tag == "Ground")
        {
            end = true;
            if (isAlive){
                isAlive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(deadClip);
                anim.SetTrigger("phoenix_dead");
            };
            if (gamePlayController.instance != null)
            {
                gamePlayController.instance._birdDead(score);
            }
            
        }
    }
}
