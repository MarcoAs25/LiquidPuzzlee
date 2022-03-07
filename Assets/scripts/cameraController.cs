using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class cameraController : MonoBehaviour
{
    public Transform bolaTitular;
    public Camera cam;
    public float offset = 30f;
    public float max, min;
    public List<Transform> ballList = new List<Transform>();

    public delegate void LoseLevel();
    public event LoseLevel losedLevel;

    void Start()
    {
        cam = Camera.main;
        
        ballList.Add(bolaTitular);
        transform.position = new Vector3(0, GetLowestBall.position.y + offset, -14.14f);

    }

    private Transform GetLowestBall
    {
        get => (from t in ballList
                orderby t.position.y
                where t.gameObject.GetComponent<ball>().IsActive()
                select t
                ).ToList()[0];
    }

    private bool IsObjectInView(GameObject Object)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        return GeometryUtility.TestPlanesAABB(planes,
            Object.GetComponent<CircleCollider2D>().bounds);
    }
    private void Update()
    {
        if (GameManager.inst.countp > 4f && !GameManager.inst.action)
        {
            losedLevel?.Invoke();
        }
    }
    

    private void CheckIfAnyBallLost()
    {
        foreach (Transform ball in ballList)
        {
            if (!IsObjectInView(ball.gameObject) && ball.gameObject.activeSelf && (transform.position.y - ball.position.y) > 16.05f )
            {
                GameManager.inst.countp++;
                ball.gameObject.SetActive(false);
            }
        }
    }

    void LateUpdate()
    {
        if(GetLowestBall!= null)
        {
            Vector3 vector = new Vector3(0f, Mathf.Clamp(GetLowestBall.position.y + offset, min, max), -15f);
            
                Vector3 velocity = default;
                transform.position = Vector3.SmoothDamp(transform.position,
                                                            vector,
                                                            ref velocity,
                                                            0.2f);
        }
    }

    
}
