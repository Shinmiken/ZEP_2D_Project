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

    public void ChangeSkin()
    {
        Image image = GetComponent<Image>();
        string str = image.sprite.name;
        int i = 0;
        for (i = 0; i < skinOverrides.Length; i++)
        {
            if(str.Contains(i.ToString())) // �̹��� ��ȣ�� ���ԵǾ� ������ �� ��ȣ�� �ο�
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
