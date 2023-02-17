using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;
    // Override the variable isActive
    private bool isActive = true;
    private Rigidbody2D physEffect;
    private BoxCollider2D knifeCollider;

    private void Awake()
    {
        physEffect = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            physEffect.AddForce(throwForce, ForceMode2D.Impulse);
            // Gravity moves with wood
            physEffect.gravityScale = 1;
            GameController.instance.GameUI.reductionKnife();
        }    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive) return;
        isActive = false;

        // When the knife hits the wood
        if (collision.collider.tag == "panelWood")
        {
            Audio.assign.playSound("stab", 2f);
            physEffect.velocity = new Vector2(0, 0);
            physEffect.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            // When the knife hit the wood, I put the BoxCollider as it was
            knifeCollider.offset = new Vector2(0, 0);
            knifeCollider.size = new Vector2(1, 4.5f);

            GameController.instance.hitKnife();
        }
        else
        {
            Audio.assign.playSound("touch", 2f);
            if (collision.collider.tag == "Knife")
            {
                physEffect.velocity = new Vector2(physEffect.velocity.x, -2);
            }
            // If two knifes collide, you lose
            GameController.instance.loseGame(true);
        }
    }
}
