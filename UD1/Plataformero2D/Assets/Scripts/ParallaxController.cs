using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    Transform cam;
    Vector3 camstartPos;
    float distance;
    GameObject[] backgrounds;
    Material[] mats;
    float[] bgSpeeds;
    float fartestBack;

    [Range(.01f, .5f)]
    public float parallaxSpeed = 0.02f;

    void Start()
    {
        cam = Camera.main.transform;
        camstartPos = cam.position;

        int bgCount = transform.childCount;
        mats = new Material[bgCount];
        bgSpeeds = new float[bgCount];
        backgrounds = new GameObject[bgCount];
        for (int i = 0; i < bgCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mats[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(bgCount);
    }

    void BackSpeedCalculate(int bgCount)
    {
        for (int i = 0; i < bgCount; i++)
        {
            if ((backgrounds[i].transform.position.z - camstartPos.z) > fartestBack)
            {
                fartestBack = backgrounds[i].transform.position.z;
            }
        }
        for (int i = 0; i < bgCount; i++)
        {
            bgSpeeds[i] = 1 - (backgrounds[i].transform.position.z - camstartPos.z) / fartestBack;
        }
    }

    void LateUpdate()
    {
        distance = cam.position.x - camstartPos.x;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = bgSpeeds[i] * parallaxSpeed;
            mats[i].SetTextureOffset("_MainTex", new Vector2(distance * -speed, 0));
        }
    }
}
