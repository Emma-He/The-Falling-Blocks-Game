using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;
using System.Globalization;
using System.Runtime.InteropServices;

public class PlayerController : MonoBehaviour {

	public HealthBar healthbar;
	public Text countText;//text object for gold earned
	public float speed = 7;
	public event System.Action OnPlayerDeath;
	public static int count = 0;
	public int maxHealth = 4;
	public int currentHealth;
	float screenHalfWidthInWorldUnits;

	// Use this for initialization
	void Start() {
		currentHealth = maxHealth;
		healthbar.setMaxHealth(maxHealth);
		setCountText();
		float halfPlayerWidth = transform.localScale.x / 2f;
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;

	}

	// Update is called once per frame
	void Update() {

		float inputX = Input.GetAxisRaw("Horizontal");
		float velocity = inputX * speed;
		transform.Translate(Vector2.right * velocity * Time.deltaTime);

		if (transform.position.x < -screenHalfWidthInWorldUnits) {
			transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
		}

		if (transform.position.x > screenHalfWidthInWorldUnits) {
			transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
		}

	}

	void OnTriggerEnter2D(Collider2D triggerCollider) {
		if (triggerCollider.tag == "Falling Block") {
			Destroy(triggerCollider.gameObject);
			takeDamage(1);
			if (currentHealth < 1)
			{
				if (OnPlayerDeath != null)
				{
					OnPlayerDeath();
				}
				Destroy(gameObject);
			}
		}
		else if (triggerCollider.tag == "Golden Brick")
		{
			Destroy(triggerCollider.gameObject);
			count += 1;
			setCountText();
		}
		else if (triggerCollider.tag == "Blood")
		{
			Destroy(triggerCollider.gameObject);
			if (currentHealth < maxHealth)
			{
				addHealth(1);
			}
		}
	}

	void takeDamage(int damage)
	{
		currentHealth -= damage;
		healthbar.setHealth(currentHealth);
	}

	void addHealth(int num)
    {
		currentHealth += num;
		healthbar.setHealth(currentHealth);
	}

	void setCountText()
    {
		countText.text = "Gold Earned: " + count.ToString();
    }
	public static int getCount()
    {
		return count;
    }
	public static void resetCount()
	{
		count = 0;
	}
}