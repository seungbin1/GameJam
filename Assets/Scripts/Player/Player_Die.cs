using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : MonoBehaviour
{

    public void Die()
    {
        SoundManager.Instance.OnDie();
        Destroy(transform.GetChild(0).gameObject);
        ShakeCamera.instance.OnShakeCamera();

        StopCoroutine(Twinkle(null,transform.gameObject));
        StartCoroutine(Twinkle(null,transform.gameObject));

        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.localPosition += new Vector3(1.25f,0,0);
            SpriteRenderer sprite = transform.GetChild(i).GetComponent<SpriteRenderer>();
            StopCoroutine(Twinkle(sprite));
            StartCoroutine(Twinkle(sprite));
        }
    }

    IEnumerator Twinkle(SpriteRenderer sprite = null, GameObject gameObject = null)
    {
        if(gameObject!=null) gameObject.layer = 9;

        if(sprite != null)
        {
            sprite.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.2f);
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.2f);
            sprite.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.2f);
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.2f);
            sprite.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.2f);
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.25f);
            sprite.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.25f);
            sprite.color = new Color(1, 1, 1, 1);
        }

        else
        {
            yield return new WaitForSeconds(1);
        }


        if (gameObject != null) gameObject.layer = 7;
    }
}
