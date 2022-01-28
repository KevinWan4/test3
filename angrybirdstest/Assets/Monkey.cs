using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour {

    

    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector2 startPos;
    [SerializeField] float speed = 500;
    [SerializeField] float maxDragDist = 2;
    bool resetCoroutine = false;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        startPos = rb.position;
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown() {
        sr.color = new Color(255, 0, 0);
        rb.gravityScale = 0;
        
    }

    void OnMouseUp() {
        Vector2 direction = startPos - rb.position;
        direction.Normalize();
        
        rb.gravityScale = 1;
        sr.color = Color.white;
        rb.isKinematic = false;
        rb.AddForce(direction*speed);
    }

    void OnMouseDrag() {
        Vector3 mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector2 mouseBoundaries = new Vector2(mousePos.x, mousePos.y);
        print(mouseBoundaries.x - startPos.x);
        float centerDist = Vector2.Distance(mouseBoundaries, startPos);
        if (centerDist > maxDragDist) {
             Vector2 dir =  mouseBoundaries - startPos;
             dir.Normalize();
             mouseBoundaries = startPos + dir * maxDragDist;
        }
        if (mouseBoundaries.x < startPos.x) mouseBoundaries.x = startPos.x;
        transform.position = mouseBoundaries;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(!resetCoroutine) {
            resetCoroutine = true;
            StartCoroutine(ResetAfterDelay());
        }

    }

    IEnumerator ResetAfterDelay() {
        yield return new WaitForSeconds(3);
        rb.position = startPos;
        rb.velocity = new Vector2(0,0);
        rb.rotation = 0;
        rb.isKinematic = true;
        resetCoroutine = false;
    }
    





    // // Start is called before the first frame update
    // Rigidbody2D rb;
    // SpriteRenderer sr;
    // float xVel, yVel = 0;
    // void Start() {
    //     rb = GetComponent<Rigidbody2D>();
    //     sr = GetComponent<SpriteRenderer>();
    // }

    
    // // Update is called once per frame
    // void Update() {
    //     xVel = Input.GetAxisRaw("Horizontal") * 2;
    //     if (xVel > 0) sr.flipX = false;
    //     else if (xVel < 0) sr.flipX = true;

    //     rb.velocity = new Vector2(xVel, rb.velocity.y);

    // }

    

}
