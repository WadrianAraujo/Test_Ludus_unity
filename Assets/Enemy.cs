using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlesPrefab;
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Bird1 bird = collision.collider.GetComponent<Bird1>();
        if (bird != null)
        {
            Instantiate(_cloudParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        if (collision.contacts[0].normal.y < - 0.5)
        {
            Instantiate(_cloudParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
