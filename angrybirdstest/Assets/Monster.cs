using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {


    [SerializeField] Sprite circleSprite;
    void OnCollisionEnter2D(Collision2D collision) {
        if (ShouldDieFromCollision(collision)) {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() {

        GetComponent<SpriteRenderer>().sprite = circleSprite;

        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }

    bool ShouldDieFromCollision(Collision2D collision) {

        Monkey monkey = collision.gameObject.GetComponent<Monkey>();
        if (monkey != null) return true;
        if (collision.contacts[0].normal.y < -0.5) return true;
        return false;
    }
}
