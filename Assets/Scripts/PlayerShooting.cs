using BattleCity;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]private float      speed = 2.0f;
    [SerializeField]private GameObject bulletPrefab;
    public  static int     ShootenBulletsCount;
    public  const int      MaxShootenBulletsCount = 1;
    public  GameObject     bulletSpawn;
    
    private PlayerMovement playerMovement;
    private Sprite[]       bulletSprites;
    private Shooting       shooting;
    
    void Start ()
	{
	    playerMovement = GetComponent<PlayerMovement>();
        shooting = new Shooting(bulletSpawn, bulletPrefab);
	}
	void Update ()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerExplosion"))
            return;

        if (Input.GetKeyDown(KeyCode.Space) && (ShootenBulletsCount < MaxShootenBulletsCount))
	    {
	        ShootenBulletsCount++;
            shooting.Shoot(gameObject, playerMovement.movement, speed);
	    }
	}

    public void RemoveBullet()
    {
        ShootenBulletsCount--;
    }

}
