using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public int speed = 5;
    private Vector2 movement;
    private Animator anim;
    private Transform myTrans;

    void Awake() {
        anim = this.GetComponent<Animator>();
        myTrans = transform;
    }

    void Update() {

        int x = 0;
        int y = 0;

        // 3 - Retrieve axis information
        if (Input.GetKey("w")) {
            y += 1;
            anim.SetInteger("Direction", 2);
        }
        if (Input.GetKey("a")) {
            x -= 1;
            anim.SetInteger("Direction", 1);
        }
        if (Input.GetKey("s")) {
            y -= 1;
            anim.SetInteger("Direction", 0);
        }
        if (Input.GetKey("d")) {
            x += 1;
            anim.SetInteger("Direction", 3);
        }

        movement = new Vector2( speed * x, speed * y);

    }

    void FixedUpdate() {
        myTrans.GetComponent<Rigidbody2D>().velocity = movement;
    }
}