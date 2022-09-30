using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeSystem : MonoBehaviour
{
    [SerializeField]
    private Light2D sun;
    [SerializeField]
    private Gradient Timegradientcolor;
    [SerializeField]
    private GameObject[] lights;
    [SerializeField]
    private TextMeshProUGUI timetext;
    private float minutes;
    private int hours;
    private int days;
    private const int DayLength = 23;
    private const int DayLengthInMinutes = 1440;
    public int CurrentHour => hours;

	private void Start()
    {
        hours = 7;
        minutes = 40;
	}

    private void Update()
    {
        if (Time.timeScale == 1)
            minutes += Time.deltaTime * 10;
        if (minutes >= 60)
        {
            minutes = 0;
            hours++;
			if (hours <= 0 && hours >= 21)
			{
				foreach (GameObject light in lights)
				{
					light.SetActive(true);
				}
			}
			else
			{
				foreach (GameObject light in lights)
				{
					light.SetActive(false);
				}
			}
		}
        if (hours == 24)
            hours = 0;
		sun.color = Timegradientcolor.Evaluate((hours + (minutes / 60f)) / DayLength);
		timetext.SetText(hours.ToString("00") + ":" + minutes.ToString("00"));
    }
}
