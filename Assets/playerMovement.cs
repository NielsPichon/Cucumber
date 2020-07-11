using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 1;

    private Vector3 direction = new Vector3(0, 0, 0);

    private float revertMvt = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoUp()
    {
        direction = new Vector3(0, 0, 1);
    }

    public void GoDown()
    {
        direction = new Vector3(0, -1, 0);
    }

    public void GoLeft()
    {
        direction = new Vector3(-1, 0, 0);
    }

    public void GoRight()
    {
        direction = new Vector3(1, 0, 0);
    }

    public void Stop()
    {
        direction = new Vector3(0, 0, 0);
    }

    public void Revert()
    {
        revertMvt *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * movementSpeed * Time.deltaTime * revertMvt;
    }
}
