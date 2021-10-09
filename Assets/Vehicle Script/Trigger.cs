using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private int package { get; set; }
    public static int amountPackage = 0;
    public static bool hasPackage = false;
    private float destroyDelay = 0.5f;

    [SerializeField] private Color32 notHasPackageColor = new Color32(255, 255, 255, 255);

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            if (amountPackage < 3)
            {
                amountPackage++;
                hasPackage = true;
                this.spriteRenderer.color = collision.GetComponent<SpriteRenderer>().color;
                print("You picked " + amountPackage + " package! Bring it to the deliverier");
                Destroy(collision.gameObject, destroyDelay);
            }
            else
            {
                print("Enough package picked!");
            }
        }
        else if(collision.tag.Equals("Delivery"))
        {
            if(amountPackage == 0)
            {
                hasPackage = false;
                print("You don't have package! Turn back and take package");
            }
            else if (0 < amountPackage && amountPackage < 3)
            {
                hasPackage = false;
                this.spriteRenderer.color = notHasPackageColor;
                print("Delivery successful! Turn back and take next package");
            }
            else
            {
                this.spriteRenderer.color = notHasPackageColor;
                print("Enough packages! Wait to tomorrow");
                Destroy(collision.gameObject, destroyDelay);
            }
        }
    }
}
