using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpHigh = 0.5f;
    [SerializeField] private float jumpDuration = 0.4f;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private Vector2 moveVec;

    private bool isJump = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        //// 힘을 준다
        //_rigidbody.AddForce(Vec);

        ////속도를 제어한다.
        //_rigidbody.velocity = Vector3;

        ////위치 이동
        //_rigidbody.MovePosition(_rigidbody.position + Vec);

    }

    // Update is called once per frame
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
        _rigidbody.MovePosition(_rigidbody.position + myMove);
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
            transform.position = Vector3.Lerp(startPos, endPos, firstTime / (jumpDuration / 2 ));
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
