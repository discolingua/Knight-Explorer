using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float xMargin = 1f;  // distance in the x axis the player can move before the camera follows
    public float yMargin = 1f;  // distance in the y axis the player can move before the camera follows
    public float xSmooth = 1f;  // how smoothly the camera catches up with its target movement in the x axis
    public float ySmooth = 1f;  // how smoothly the camera catches up with its target movement in the y axis
    public Vector2 maxXAndY;    // maximum x & y coords the camera can have
    public Vector2 minXAndY;    // minimum x & y coords the camera can have
    
    private Transform player;
    private Transform myTrans;

    void Awake() {
        myTrans = transform;
        player = GameObject.Find("Knight").transform;  // reference to player gameobject
    }

    bool CheckXMargin() {
        // return true if the x distance between camera and player is greater than the x margin
        return Mathf.Abs(myTrans.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin() {
        return Mathf.Abs(myTrans.position.y - player.position.y) > yMargin;
    }

    void FixedUpdate() {
        TrackPlayer();
    }

    void TrackPlayer() {
        // by default, target x/y coords of the camera are its current x/y coords
        float targetX = myTrans.position.x;
        float targetY = myTrans.position.y;

        Debug.Log(myTrans.position.x.ToString());
        
        if (CheckXMargin()) {
            targetX = Mathf.Lerp(myTrans.position.x, player.position.x, xSmooth * Time.deltaTime);
        }

        if (CheckYMargin()) {
            targetY = Mathf.Lerp(myTrans.position.y, player.position.y, ySmooth * Time.deltaTime);
        }

        // keep target x/y coords in bounds
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // set camera's position
        myTrans.position = new Vector3(targetX, targetY, myTrans.position.z);
    }
}