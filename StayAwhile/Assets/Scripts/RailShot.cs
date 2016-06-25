using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RailShot : MonoBehaviour {

    public LineRenderer lr;
    public float timer = 0f;
    public float timeToLive = 0.2f;

    public void Init(Vector3 start, Vector3 end)
    {
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timeToLive)
        {
            Destroy(gameObject);
        }
	}
}
