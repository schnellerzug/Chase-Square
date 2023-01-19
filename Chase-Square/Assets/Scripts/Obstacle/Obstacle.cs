using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public ObstacleType type;

    protected ITranslateVectorInput _motion;
    protected IAmADeathCondition _condition;

    public float speed;

    protected virtual void Start()
    {
        _motion = GetComponent<ITranslateVectorInput>();
        _condition = GetComponent<IAmADeathCondition>();
        
    }

    private void OnEnable()
    {
        if (_condition != null) _condition.OnCondition += Death;
    }
    protected virtual void Update()
    {
        if(_motion != null) { _motion.TranslateInput(Vector3.right, speed); }
        

    }

    private void Death()
    {
        gameObject.SetActive(false);
        _condition.OnCondition -= Death;
    }
}