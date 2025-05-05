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

    public AnimatorOverrideController[] skinOverrides; // ��Ų�� ��Ʈ�ѷ� �迭

    public void ChangeSkin(int skinIndex)
    {
        animator = player.GetComponent<Animator>();
        if (skinIndex < skinOverrides.Length)
        {
            animator.runtimeAnimatorController = skinOverrides[skinIndex];
        }
    }
}
