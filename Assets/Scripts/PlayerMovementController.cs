using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

	private Rigidbody2D _Rigidbody2D;
	public bool _FacingRight = true;  // For determining which way the player is currently facing.
	private SpriteRenderer _Renderer;

	

	public float runSpeed = 100f;

	Vector3 movement;

    private void Awake()
	{

		

		_Rigidbody2D = GetComponent<Rigidbody2D>();
		_Renderer = GetComponent<SpriteRenderer>();

	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
		{
			Flip(false);
		}
        else if (Input.GetKeyDown(KeyCode.D))
        {
			Flip(true);

		}

		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		movement = Vector2.ClampMagnitude(movement, 1) * runSpeed * Time.deltaTime;
		_Rigidbody2D.velocity = movement;


	}


	


	private void Flip(bool direction)
	{
		// Switch the way the player is labelled as facing.
		_FacingRight = direction;
		_Renderer.flipX = !direction;

	}
}