using UnityEngine;

public class BeerCounter : MonoBehaviour
{
    public int beers = 3;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveBeer()
    {
        if (beers > 0)
        {
            GameObject beer = transform.Find("Beer"+beers).gameObject;
            beer.SetActive(false);
            beers--;

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
