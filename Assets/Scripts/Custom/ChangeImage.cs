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

    public void ChangeSkin()
    {
        Image image = GetComponent<Image>();
        string str = image.sprite.name;
        int i = 0;
        for (i = 0; i < skinOverrides.Length; i++)
        {
            if(str.Contains(i.ToString())) // 이미지 번호가 포함되어 있으면 그 번호를 부여
            {
                break;
            }
            else if (str.Contains("ten"))
            {
                i = 10;
                break;
            }
            else if(str.Contains("elev"))
            {
                i = 11;
                break;
            }
        }
        animator = player.GetComponent<Animator>();
        animator.runtimeAnimatorController = skinOverrides[i];
    }
}
