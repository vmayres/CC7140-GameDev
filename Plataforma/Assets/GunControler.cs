using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunControler : MonoBehaviour
{

    [SerializeField] private Transform gun;
    [SerializeField] private Animator gun_anim;
    [SerializeField] private float gun_distance = 1.0f;
    

    private bool gunFacingRight = true;

    [Header("Bullet")]
    [SerializeField] private GameObject bullet_Prefab;
    [SerializeField] private float bullet_Speed;

    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        gun.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(gun_distance, 0, 0);

        GunFlipControler(mousePos);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot(direction);

    }

    private void GunFlipControler(Vector3 mousePos)
    {
        if (mousePos.x < gun.position.x && gunFacingRight)
            GunFlip();
        else if (mousePos.x > gun.position.x && !gunFacingRight)
            GunFlip();
    }

    private void GunFlip()
    {
        gunFacingRight = !gunFacingRight;
        gun.localScale = new Vector3(gun.localScale.x, gun.localScale.y * -1, gun.localScale.z);
    }

    public void Shoot(Vector3 direction)
    {
        gun_anim.SetTrigger("Shoot");

        GameObject new_bullet = Instantiate(bullet_Prefab, gun.position, Quaternion.identity);
        new_bullet.GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * bullet_Speed;
        Destroy(new_bullet, 5);
    }

}
