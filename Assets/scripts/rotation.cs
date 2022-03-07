using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 clickpos;
    [SerializeField]
    private float max, min;
    [SerializeField]
    private bool isVertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    

    private void OnMouseDrag()
    {
        atualizar();
        if (!isVertical)
        {
            transform.position = new Vector3(Mathf.Clamp(clickpos.x, min, max), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(clickpos.y, min, max), transform.position.z);
        }
    }

    private void atualizar()
    {
        clickpos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
