using UnityEngine;

public class CameraController : MonoBehaviour {

	private static float movementSpeed = 1.0f;

	void Update () {
		if (Input.GetMouseButton (0)) {
			movementSpeed = Mathf.Max (movementSpeed += Input.GetAxis ("Mouse ScrollWheel"), 0.0f);
			transform.position += (transform.right * Input.GetAxis ("Horizontal") + transform.forward * Input.GetAxis ("Vertical")) * movementSpeed;
			transform.eulerAngles += new Vector3 (-Input.GetAxis ("Mouse Y"), Input.GetAxis ("Mouse X"), 0);
		}
	}
}