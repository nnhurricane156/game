using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    private ParticleSystem collectEffect;

    void Start()
    {
        collectEffect = GetComponentInChildren<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectEffect != null)
            {
                collectEffect.transform.parent = null;
                collectEffect.Play();
                Destroy(collectEffect.gameObject, collectEffect.main.duration + 0.5f); // tự hủy sau thời gian
            }

            Destroy(gameObject);
        }
    }
}
