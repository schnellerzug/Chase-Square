using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData data;

    private IGetVectorInput _input;
    private ITranslateVectorInput _motion;
    private IPutRotation _rotation;

    private ParticleSystem particle;

    private void Start()
    {
        _motion = GetComponent<ITranslateVectorInput>();
        _input = GetComponent<IGetVectorInput>();
        _rotation= GetComponent<IPutRotation>();

        //later create a instance of a prefab
        GetComponentInChildren<SpriteRenderer>().sprite = data.skin;

        particle = GetComponentInChildren<ParticleSystem>();
    }
    private void Update()
    {
        Movement();
    }

    private Vector3 input;
    private void Movement()
    {
        
        if(_input != null) input = _input.GetInput();

        if (input == Vector3.zero)
            return;

        if(_rotation != null) _rotation.Rotate(input, data.rotationSpeed);
        if(_motion != null)  _motion.TranslateInput(input,data.speed);
    }

 
}
