using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FlapPlayer : MonoBehaviour
{
    public static FlapPlayer instance;
    [SerializeField]private float FlapSpeed = 3f;
    [SerializeField] private float FlapJump = 3f;
    private bool isJump = false;

    Rigidbody2D _rigidbody2D;
    Animator _animator;

    public bool isDead = false;

    public GameObject StartUI;
    public GameObject ScoreUI;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        Time.timeScale = 0f;
    }


    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            UiManger.instancee.GameOver();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            isJump = true;
        }
        
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        Vector2 vel = _rigidbody2D.velocity;
        vel.x = FlapSpeed;
        if (isJump)
        {
            vel.y = FlapJump;
            isJump = false;
        }
        _rigidbody2D.velocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        isDead = true;
        _animator.SetInteger("isDie", 1);
    }

    public void StartFlapGame()
    {
        StartUI.SetActive(false);
        ScoreUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
