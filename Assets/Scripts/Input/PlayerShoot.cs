using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public InputManager inputManager;
    public GameManager gameManager;
    private Camera cameraMain;

    public GameObject startPosVisual;
    public GameObject currPosVisual;

    public GameObject line;

    public GameObject shootTowards;

    Vector3 startPos;
    bool doShoot = false;

    public float shootFrequency = 1f;
    public float lastShotTime;

    private void Awake()
    {
        lastShotTime = Time.time;
        cameraMain = Camera.main;
        inputManager.OnStartTouch += StartShoot;
        inputManager.OnEndTouch += endShoot;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += StartShoot;
        inputManager.OnEndTouch += endShoot;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= StartShoot;
        inputManager.OnEndTouch -= endShoot;
    }

    private void Update()
    {
        currPosVisual.transform.position = convertToWorldPoint(inputManager.currTouchPosition);
        Vector3 shootPos = convertToWorldPoint(inputManager.currTouchPosition) - startPos;
        shootPos = shootPos.normalized * 2;
        line.GetComponent<LineRenderer>().SetPositions(new Vector3[] { transform.position, (transform.position + shootPos) });
        shootTowards.transform.position = transform.position + shootPos;
        if (doShoot && lastShotTime + shootFrequency < Time.time && convertToWorldPoint(inputManager.currTouchPosition) != startPos)
        {
            shootProjectile(gameManager.currentProjectile, shootPos);
            lastShotTime = Time.time;
        }
    }

    public void StartShoot(Vector2 screenPos, float time)
    {
        Debug.Log("start shoot");
        startPos = convertToWorldPoint(screenPos);
        startPosVisual.transform.position = startPos;
        doShoot = true;
    }

    public void endShoot(Vector2 screenPos, float time)
    {
        doShoot = false;
    }

    public Vector3 convertToWorldPoint(Vector2 point)
    {
        Vector3 screenCoords = new Vector3(point.x, point.y, cameraMain.nearClipPlane);
        Vector3 WorldCoords = cameraMain.ScreenToWorldPoint(screenCoords);
        WorldCoords.z = 0;
        return WorldCoords;
    }

    public void shootProjectile(GameObject projectile, Vector3 shootDirection)
    {
        GameObject newProj = Instantiate(projectile, transform.position, Quaternion.identity);
        Projectile p = newProj.GetComponent<Projectile>();
        p.spawn(gameManager.projectileStatManager, shootDirection);
    }

}
