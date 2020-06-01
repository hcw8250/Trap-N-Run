using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Sprite [] sprites;
    private Coroutine cor;
    public int dir = 1;//是正放还是倒放
    public SpriteRenderer render;
    public WaitForSeconds wait = new WaitForSeconds(0.005f);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAniamtion()
    {
        if(cor != null)
        {
            StopCoroutine(Show());
        }
        cor = StartCoroutine(Show());
    }
    IEnumerator Show()
    {
        if(dir == 1)
        {
            for (int i = 0; i < sprites .Length ; i++)
            {
                render.sprite = sprites[i];
                yield return wait;
            }
            Destroy(gameObject);
        }
    }
}
