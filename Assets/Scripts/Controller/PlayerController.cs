using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    private Player playerInfo;
    private IGenericRepository<Player> repository;


    void Start()
    {
        //editei aqui
        characterController = this.GetComponent<CharacterController>();
        repository = new GenericRepository<Player>();
    }

    void Update()
    {

    }

    public void Move(float axis)
    {
        transform.Translate(0, 0, axis * playerInfo.Speed *  Time.deltaTime);
    }

    public void Rotate(float direction)
    {
        transform.Rotate(0, direction * playerInfo.RotationSpeed * Time.deltaTime, 0);
    }

    public void Create(Player playerInfo)
    {
        this.playerInfo = playerInfo;
    }

    public Player getPlayerInfo()
    {
        return playerInfo;
    }
    public void SavePlayerInfo()
    {
        repository.Save(playerInfo);
    }

    public void LoadPlayerInfo()
    {
        playerInfo = (Player)repository.Get(new Player());
    }
    
}
