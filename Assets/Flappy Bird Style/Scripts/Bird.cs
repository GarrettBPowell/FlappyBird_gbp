using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	public float upForce;					
	private bool isDead = false;

	public int oofs = 25;

	private Animator anim;					
	private Rigidbody2D rb2d;
	private SpriteRenderer spritey;
	private PolygonCollider2D poliCol;

	void Start()
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D>();
		spritey = GetComponent<SpriteRenderer>();
		poliCol = GetComponent<PolygonCollider2D>();
	}

	void Update()
	{
		if (isDead == false) 
		{
			if (Input.GetButtonDown("FLAP")) 
			{
				anim.SetTrigger("Flap");
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2(0, upForce));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Column")
		{
			oofs--;

			if (oofs <= 0)
			{
				rb2d.velocity = Vector2.zero;
				isDead = true;
				anim.SetTrigger("Die");
				GameControl.instance.BirdDied();
			}
			else
			{
				poliCol.enabled = false;
				spritey.color = new Color(1, 0, 0, .5f);
				StartCoroutine(EnableBox(1.5F));
			}
		}
		else
        {
			rb2d.velocity = Vector2.zero;
			isDead = true;
			anim.SetTrigger("Die");
			GameControl.instance.BirdDied();
		}
	}

	IEnumerator EnableBox(float waitTime)
    {
		yield return new WaitForSeconds(waitTime);
		poliCol.enabled = true;
		spritey.color = new Color(1, 1, 1, 1);
	}
}
