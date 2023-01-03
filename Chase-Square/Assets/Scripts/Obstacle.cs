using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public ObstacleType type;

    private ITranslateVectorInput _motion;
    private IAmADeathCondition _condition;

    public float speed;

    private void Start()
    {
        _motion = GetComponent<ITranslateVectorInput>();
        _condition = GetComponent<IAmADeathCondition>();
    }
    private void Update()
    {
        if(_motion != null) { _motion.TranslateInput(Vector3.right, speed); }
        
        if(_condition != null ) 
        {
            if (_condition.Condition())
            {
                gameObject.SetActive(false);
            } 
        }
    }
}