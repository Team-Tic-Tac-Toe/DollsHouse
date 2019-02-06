using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {
    public float magnitude = 0.3f;
    public float duration = 1f;
    public Sprite[] sprites;

    int spriteIndex = 0;
    float timer = 0;
    bool isOpen = false;

    SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(!isOpen)
            timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerMelee") && timer > duration && spriteIndex < sprites.Length)
        {
            timer = 0;
            spriteIndex++;

            if (spriteIndex < sprites.Length)
            {
                StartCoroutine(Shake());
                renderer.sprite = sprites[spriteIndex];

                if (spriteIndex == sprites.Length - 2)
                {
                    isOpen = true;
                    StartCoroutine(Open());
                }
            }
        }
    }

    IEnumerator Shake()
    {
        Vector3 originPos = transform.position;

        transform.position = new Vector3(originPos.x - magnitude, originPos.y, originPos.z);

        yield return null;

        transform.position = new Vector3(originPos.x + magnitude, originPos.y, originPos.z);

        yield return null;

        transform.position = originPos;
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(0.5f);

        renderer.sprite = sprites[++spriteIndex];
    }
}
