using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 0.4f;
    [SerializeField] private float moveSpeed = 0.04f;
    private bool isBoost = false;
    private bool isSlow = false;
    
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime * 500;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * 500;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Boost") && !isBoost)
        {
            moveSpeed *= 2;
            isBoost = true;
            isSlow = false;
            normalFromBoost(3);
        }
        else if(collision.tag.Equals("Slow") && !isSlow)
        {
            moveSpeed /= 4;
            isBoost = false;
            isSlow = true;
            normalFromSlow(3);
        }
    }

    private IEnumerator normalFromBoost(int secs)
    {
        yield return new WaitForSeconds(secs);
        isBoost = false;
        isSlow = false;
        moveSpeed /= 4;
    }

    private IEnumerator normalFromSlow(int secs)
    {
        yield return new WaitForSeconds(secs);
        isBoost = false;
        isSlow = false;
        moveSpeed *= 2;
    }
}
