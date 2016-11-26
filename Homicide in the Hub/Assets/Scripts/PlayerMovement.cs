using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed = 2.0f;
	public float[] boundaries = new float[4]; //First element is min of x, second max of x, third min of y, fourth max of y.
	private Vector2 targetPosition;
	private SpriteRenderer spriteRenderer;
	public bool isFacingRight = true;

	void Start () {
		targetPosition = transform.position;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			targetPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log (targetPosition);
			spriteRenderer.flipX = (targetPosition.x < transform.position.x);
		}
		//Boundaries for movement
		if ((targetPosition.x > boundaries [0]) && (targetPosition.x < boundaries [1]) && (targetPosition.y > boundaries [2]) && (targetPosition.y < boundaries [3])) {
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
		}
	}    
}