using UnityEngine;

public class limiter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fluid"))
        {
            GameManager.inst.countp++;
            collision.gameObject.GetComponent<ball>().setActive(false);
        }
    }
}
