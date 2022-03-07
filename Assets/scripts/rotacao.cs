using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacao : MonoBehaviour
{
    [SerializeField]
    private Vector3 clickpos;
    private void OnMouseDrag()
    {
        atualizar();
        transform.position = new Vector3(clickpos.x, clickpos.y, transform.position.z);
    }
    private void atualizar()
    {
        clickpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
