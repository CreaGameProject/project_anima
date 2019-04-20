using System.Collections.Generic;
using UnityEngine;

public class P_l_a_y_e_r : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    private void Update()
    {
        GoStraight();
        Rotate();
        Shoot();
    }

    void GoStraight()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * 0.2f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * 0.2f);
        }
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, 1f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -1f);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, new Quaternion());
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 100f, ForceMode.VelocityChange);
        }
    }
}
