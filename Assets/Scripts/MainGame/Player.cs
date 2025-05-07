using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 20f;
    [SerializeField] private float jumpHigh = 0.5f;
    [SerializeField] private float jumpDuration = 0.4f;
    private Rigidbody2D _rigidbody;
    public SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private Vector2 moveVec;

    private bool isJump = false;

    public static Player instence; // 이미지 교페를 위한 싱글톤 선언
    private void Awake()
    {
        if(instence == null)
        {
            instence = this;
        }
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            StartCoroutine(Jump());
        }

    }

    private void FixedUpdate()
    {
        Vector2 myMove = moveVec.normalized * playerSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + myMove); // x,y값을 따로 해서 위치변경이 아닌 rigidbody에 MovePosition를 활용하여 한번에 움직임 구현
    }

    private void LateUpdate()
    {
        _animator.SetFloat("isRun", moveVec.magnitude);
        if (moveVec.x != 0)
        {
            _spriteRenderer.flipX = moveVec.x < 0;
        }
    }

    private IEnumerator Jump()
    {
        isJump = true;

        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + new Vector2(0, jumpHigh);

        float firstTime = 0;
        while(firstTime < jumpDuration / 2)
        {
            transform.position = Vector3.Lerp(startPos, endPos, firstTime / (jumpDuration / 2 )); // 올라가고 내려가고 시간 조절
            firstTime += Time.deltaTime;
            yield return null;
        }

        firstTime = 0;
        while (firstTime < jumpDuration / 2)
        {
            transform.position = Vector3.Lerp(endPos, startPos, firstTime / (jumpDuration / 2));
            firstTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos;
        isJump = false;
    }
}
