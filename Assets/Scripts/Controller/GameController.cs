using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public CameraController camera;

    public int gameStatus = 0;
    public bool isPaused = false;
    public bool allowUserInputs = true;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        camera = GameObject.Find("Camera").GetComponent<CameraController>();

        player.Create(new Player
        {
            Id = 0,
            Name = "Player1",
            Speed = 1f,
            RotationSpeed = 100f
        });

        camera.ChangeActiveCamera(0);
        camera.ChangeTarget(player.transform.gameObject);
        camera.ChangeMode(1);
    }

    void Update()
    {
        if (gameStatus == 0)
        {
            if (isPaused)
            {

            }
            else
            {
                Inputs(allowUserInputs);
            }
        }
    }

    private void Inputs(bool allowed)
    {
        if (allowed)
        {

            player.Move(Input.GetAxis("Vertical"));
            player.Rotate(Input.GetAxis("Horizontal"));

            
            camera.Zoom(Input.mouseScrollDelta.y);

            if (Input.GetKeyDown(KeyCode.S)) player.SavePlayerInfo(); //SAVE PLAYERINFO
            if (Input.GetKeyDown(KeyCode.L)) player.LoadPlayerInfo(); //LOAD PLAYERINFO

            if (Input.GetKeyDown(KeyCode.Keypad1)) camera.ChangeActiveCamera(0); //CHANGE TO CAMERA1
            if (Input.GetKeyDown(KeyCode.Keypad2)) camera.ChangeActiveCamera(1); //CHANGE TO CAMERA2
        }

    }

}
