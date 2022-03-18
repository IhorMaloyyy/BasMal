using UnityEngine;

public class TimePowerUp : PowerUp
{
    private Timer timerScript;

    private readonly float timeToAdd = 10f;

    protected override void Start()
    {
        base.Start();

        timerScript = GameObject.Find(nameof(Timer)).GetComponent<Timer>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        AddTime(timeToAdd);
    }

    private void AddTime(float timeToAdd)
    {
        timerScript.TimeLeft += timeToAdd;
    }
}
