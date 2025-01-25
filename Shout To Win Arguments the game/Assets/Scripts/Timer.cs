using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float maxTime = 5f;

    private float timer = 0f;
    private bool started;

    private Gradient gradient;

    private Image image;

    private BeerCounter beers;
    private TypingInput typingInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartTimer();
        started = false;

        gradient = new Gradient();

        GradientColorKey[] colors = new GradientColorKey[3];
        colors[0] = new GradientColorKey(Color.red, 0.0f);
        colors[1] = new GradientColorKey(new Color(1f, 0.6f, 0f), 0.5f);
        colors[2] = new GradientColorKey(Color.green, 1.0f);

        GradientAlphaKey[] alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphas[1] = new GradientAlphaKey(1.0f, 1.0f);

        gradient.SetKeys(colors, alphas);

        image = GetComponent<Image>();

        beers = FindFirstObjectByType<BeerCounter>();
        typingInput = FindFirstObjectByType<TypingInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                OutOfTime();
            }

        }

        transform.localScale = new Vector3(timer / maxTime, transform.localScale.y, transform.localScale.z);
        image.color = gradient.Evaluate(timer / maxTime);
    }

    public void StartTimer()
    {
        timer = maxTime;
        started = true;
    }

    public void StopTimer()
    {
        timer = maxTime;
        started = false;
    }

    public void OutOfTime() {
        timer = 0f;
        started = false;

        beers.RemoveBeer();
        typingInput.Fail();
    }


}
