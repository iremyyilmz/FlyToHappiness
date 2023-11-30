using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    Vector2 velocity;

    [SerializeField]
    float speed = default;

    [SerializeField]
    float speedUp = default;

    [SerializeField]
    float slowDown = default;

    [SerializeField]
    float jumpPower = default;

    [SerializeField]
    int jumpLimit = 4;

    Joystick joystick;

    JoystickButton joystickButton;

    bool jump;

    int jumpCount;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joystickButton = FindObjectOfType<JoystickButton>();
    }

    void Update()
    {
        #if UNITY_EDITOR
              KeyboardControl();
        #else
               JoystickControl();
        #endif

    }

    void KeyboardControl()
    {
        float motionInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;

        if (motionInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, motionInput * speed, speedUp * Time.deltaTime);
            animator.SetBool("run", true);
            scale.x = -0.55f;
        }
        else if (motionInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, motionInput * speed, speedUp * Time.deltaTime);
            animator.SetBool("run", true);
            scale.x = 0.55f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, slowDown * Time.deltaTime);
            animator.SetBool("run", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            StartJumping();
        }

        if (Input.GetKeyUp("space"))
        {
            StopJumping();
        }
    }

    void JoystickControl()
    {
        float motionInput = joystick.Horizontal;
        Vector2 scale = transform.localScale;

        if (motionInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, motionInput * speed, speedUp * Time.deltaTime);
            animator.SetBool("run", true);
            scale.x = -0.55f;
        }
        else if (motionInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, motionInput * speed, speedUp * Time.deltaTime);
            animator.SetBool("run", true);
            scale.x = 0.55f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, slowDown * Time.deltaTime);
            animator.SetBool("run", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (joystickButton.keyPressed == true && jump == false)
        {
            jump = true;
            StartJumping();
        }

        if (joystickButton.keyPressed == false && jump == true)
        {
            jump = false;
            StopJumping();
        }
    }

    void StartJumping()
    {
        if(jumpCount < jumpLimit)
        {
            FindObjectOfType<SoundControl>().JumpSound();
            rb2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            animator.SetBool("jump", true);
            FindObjectOfType<SliderControl>().SliderDeger(jumpLimit, jumpCount);
        }
        
    }

    void StopJumping()
    {
        animator.SetBool("jump", false);
        jumpCount++;
        FindObjectOfType<SliderControl>().SliderDeger(jumpLimit, jumpCount);
    }

    public void ResetJumping()
    {
        jumpCount = 0;
        FindObjectOfType<SliderControl>().SliderDeger(jumpLimit, jumpCount);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Dead")
        {
            FindObjectOfType<GameControl>().GameOver();
        }
    }

    public void Gameover()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Feet")
        {
            FindObjectOfType<GameControl>().GameOver();
        }
    }
}
