using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathDetect : MonoBehaviour
{
    
    private bool death = false, win = false;

    [SerializeField]
    private Animator animP, animE;

    public delegate void LoseLevel();
    public event LoseLevel losedLevel;

    public delegate void WinLevel();
    public event WinLevel winedLevel;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Enemy") && collision.gameObject.CompareTag("fluid"))
        {
            GameManager.inst.countE++;
        }
        else if ((gameObject.CompareTag("Player")|| gameObject.CompareTag("NonPlayerAndEnemy")) && collision.gameObject.CompareTag("fluid"))
        {
            GameManager.inst.countp++;
        }
        if (!GameManager.inst.action)
        {
            if (GameManager.inst.countE > 20f && gameObject.CompareTag("Enemy") && !win )
            {
                winedLevel?.Invoke();
                win = true;
                animE.SetTrigger("death");
                GameManager.inst.action = true;
            }
            else if (GameManager.inst.countp > 4f && gameObject.CompareTag("Player") && !death)
            {
                losedLevel?.Invoke();
                death = true;
                animP.SetTrigger("death");
                GameManager.inst.action = true;
            }
            else if (GameManager.inst.countp > 4f && gameObject.CompareTag("NonPlayerAndEnemy") && !death)
            {
                losedLevel?.Invoke();
                death = true;
                GameManager.inst.action = true;
            }
        }
        
    }

}
