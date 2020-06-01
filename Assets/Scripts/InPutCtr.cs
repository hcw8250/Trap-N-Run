using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CtrKey
{
    MoveRight,
    MoveLeft,
    Jump
}

public class InPutCtr : MonoBehaviour
{
    public playerController player;
    public CtrKey key;
    private bool Check;
    public Text rightCtrTex, leftCtrTex, jumpCtrTex;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetKey(int  ctr)
    {
        key =(CtrKey ) ctr;
        Debug.Log(key);
        Check = true;
    }
    // Update is called once per frame
    void OnGUI()
    {
        if(Check)
        {

            if (Event.current.keyCode == KeyCode.None) return;
            if(Input .anyKeyDown)
            {
                switch (key)
                {
                    case CtrKey.MoveRight:
                        player.right = Event.current.keyCode;
                        rightCtrTex.text = player.right.ToString();
                        break;
                    case CtrKey.MoveLeft:
                        player.left = Event.current.keyCode;
                        leftCtrTex.text = player.left.ToString();
                        break;
                    case CtrKey.Jump:
                        player.jump = Event.current.keyCode;
                        jumpCtrTex.text = player.jump.ToString();
                        break;
                    default:
                        break;
                }
                Check = false;
            }
        }   
    }
}
