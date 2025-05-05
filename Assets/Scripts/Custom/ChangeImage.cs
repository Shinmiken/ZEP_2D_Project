using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = Player.instence;
    }
    Animator animator;

    public AnimatorOverrideController[] skinOverrides; // 스킨별 컨트롤러 배열

    public void ChangeSkin(int skinIndex)
    {
        animator = player.GetComponent<Animator>();
        if (skinIndex < skinOverrides.Length)
        {
            animator.runtimeAnimatorController = skinOverrides[skinIndex];
        }
    }
}
