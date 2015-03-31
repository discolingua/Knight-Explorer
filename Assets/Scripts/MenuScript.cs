using UnityEngine;

/// <summary>
///   Title screen script
/// </summary>

public class MenuScript : MonoBehaviour {

    void Update() {
        if (Input.GetKeyUp ("space")) {
            Debug.Log("what");
            Application.LoadLevel("House");
        }
    }
}