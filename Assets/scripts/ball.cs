using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] private bool isActive;
    public bool IsActive() => isActive;
    public void setActive(bool n) => isActive = n;
}
