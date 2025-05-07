using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RideManager : MonoBehaviour
{
    public TextMeshProUGUI swamp;
    public TextMeshProUGUI muddy;
    public GameObject _gameObject;
    private SpriteRenderer _sp;

    Player player;
    Animator animator;
    string str = "해제하기";
    string wear = "장착하기";

    public AnimatorOverrideController[] skinOverrides;
    private void Awake()
    {
        player = Player.instence;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }


    private void LateUpdate()
    {
        if (player._spriteRenderer.flipX == true) // 플레이어가 보는 방향을 보게끔 설정
        {
            _sp.flipX = true;
        }
        else
        {
            _sp.flipX = false;
        }
    }

    public void RideMuddy()
    {
        if (_gameObject.activeSelf == false) // 탈것을 타고 있지않으면 탑승 및 속도 변경
        {
            _gameObject.SetActive(true);
            muddy.text = str;
            player.playerSpeed = 30f;
            animator.runtimeAnimatorController = skinOverrides[0];
        }
        else if (animator.runtimeAnimatorController == skinOverrides[1] && _gameObject.activeSelf == true) // 다른 탈것을 타고 있다면 행동x
        {
            return;
        }
        else // 내리기
        {
            muddy.text = wear; 
            _gameObject.SetActive(false);
            player.playerSpeed = 20f;
        }
    }

    public void RideSwamp()
    {
        if (_gameObject.activeSelf == false)
        {
            _gameObject.SetActive(true);
            swamp.text = str;
            player.playerSpeed = 10f;
            animator.runtimeAnimatorController = skinOverrides[1];
        }
        else if(animator.runtimeAnimatorController == skinOverrides[0] && _gameObject.activeSelf == true)
        {
            return;
        }
        else
        {
            swamp.text= wear;
            _gameObject.SetActive(false);
            player.playerSpeed = 20f;
        }
    }
}
