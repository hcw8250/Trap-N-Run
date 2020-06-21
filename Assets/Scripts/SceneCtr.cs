using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class SceneCtr : MonoBehaviour
{
    public GameObject copyScene;//要赋值的场景物体
    
    public SpriteRenderer[] render;
    public float posx=35;
    public void SetBG(Sprite sp) 
    {
        for (int i = 0; i < render .Length; i++)
        {
            render[i].sprite = sp;
        }
        
    }
    /// <summary>
    /// 复制场景
    /// </summary>
    public void Copy()
    {
        posx += 35;
        GameObject obj = Instantiate(copyScene);
        obj.transform.SetParent(transform);
        obj.GetComponentInChildren<LoopPoint>().ctr = this;
        obj.transform.position = new Vector3(posx, 0, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
