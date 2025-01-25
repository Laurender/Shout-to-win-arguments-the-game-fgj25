using UnityEngine;

public class BeerCounter : MonoBehaviour
{
    public int beers = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        }
    }
}
