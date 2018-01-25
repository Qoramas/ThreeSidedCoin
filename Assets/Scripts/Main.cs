using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public Button generateButton;
	public Button clearButton;
	public Text outputText;
	public Slider coinCount;
	public InputField ratioValue;
	public Toggle collisionCheck;
	public Toggle colourCheck;
	public Slider velRange;
	public Slider angVelRange;

	public GameObject coin;

	private List<GameObject> coins = new List<GameObject>();

	// Use this for initialization
	void Start () {
		generateButton.onClick.AddListener(TaskGenerate);
		clearButton.onClick.AddListener (TaskClear);
		coinCount.onValueChanged.AddListener (delegate {TaskUpdateCount(); });
		velRange.onValueChanged.AddListener (delegate {TaskUpdateVRange(); });
		angVelRange.onValueChanged.AddListener (delegate {TaskUpdateAVRange(); });
		InvokeRepeating("CheckCoins", 0f, 1.0f);
	}

	void TaskUpdateCount() {
		coinCount.GetComponentInChildren<Text> ().text = "" + coinCount.value;
	}

	void TaskUpdateVRange() {
		velRange.GetComponentInChildren<Text> ().text = "" + velRange.value;
	}

	void TaskUpdateAVRange() {
		angVelRange.GetComponentInChildren<Text> ().text = "" + angVelRange.value;
	}

	void TaskClear() {
		foreach (GameObject c in coins) {
			Destroy (c);
		}
		coins.Clear ();
		CheckCoins ();
	}

	void CheckCoins() {
		int h = 0;
		int t = 0;
		int s = 0;
		int inv = 0;
		foreach(GameObject c in coins) {
			float x = Mathf.Abs(c.transform.eulerAngles.x);
			float z = Mathf.Abs(c.transform.eulerAngles.z);
			if (x > 200) x -= 180;
			if (z > 200) z -= 180;
			//If the z is roughly 90 then its on its side
			if ((z > 88 && z < 92)) {
				if(colourCheck.isOn) c.GetComponent<Renderer> ().material.color = Color.magenta;
				s++;
			} else {
				//If the x and z are the same and roughly 0 or 180 then its heads
				if((x < 2 && z < 2) || (x > 178 && z > 178)) {
					if(colourCheck.isOn) c.GetComponent<Renderer> ().material.color = Color.blue;
					h++;
				//If the x and z are different and roughly 0 or 180 then its tails
				} else if ((x < 2 && z > 178) || (x > 178 && z < 2)) {
					if(colourCheck.isOn) c.GetComponent<Renderer> ().material.color = Color.red;
					t++;
				//Otherwise its invalid
				} else {
					if(colourCheck.isOn) c.GetComponent<Renderer> ().material.color = Color.yellow;
					inv++;
				}
			}
		}
		outputText.text = "Heads : " + h + "\nTails : " + t + "\nSides : " + s + "\nInvalid : " + inv;
	}

	void TaskGenerate() {
		float width = (1/(float.Parse (ratioValue.text))) * 0.5f;

		for (int i = 0; i < coinCount.value; i++) {
			GameObject instance = Instantiate (coin, new Vector3 (Random.Range(-50f, 50f), 20, Random.Range(-50f, 50f)), Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
//			GameObject instance = Instantiate (coin, new Vector3 (0, 20, 0), Quaternion.identity);
			instance.name = "Coin" + coins.Count;
			if (!collisionCheck.isOn) {
				foreach (GameObject c in coins) {
					Physics.IgnoreCollision (instance.GetComponent<Collider> (), c.GetComponent<Collider> ());
				}
			}
			coins.Add (instance);
			instance.transform.localScale = new Vector3 (1.0f, width, 1.0f);
			instance.GetComponent<Rigidbody> ().velocity += new Vector3 (Random.Range(-velRange.value, velRange.value),Random.Range(-velRange.value, velRange.value),Random.Range(-velRange.value, velRange.value));
//			instance.GetComponent<Rigidbody> ().velocity += new Vector3 (0,20f,0);
			instance.GetComponent<Rigidbody> ().angularVelocity += new Vector3 (Random.Range(-angVelRange.value, angVelRange.value),Random.Range(-angVelRange.value, angVelRange.value),Random.Range(-angVelRange.value, angVelRange.value));
//			Debug.Log (instance.GetComponent<Rigidbody>().velocity + " " + instance.GetComponent<Rigidbody>().angularVelocity);
		}
	}
}
