using UnityEngine;
using System.Collections;

public class heroControl : MonoBehaviour {

    //定义主角角色控制器
    CharacterController hero;

    //点数组
    public Transform[] points;

    //下一个点的下标，主角移动速度
    public int nextIndex;
    public int moveSpeed = 10;

    void Start()
    {
        //初始化主角移动速度
        nextIndex = 0;
        //获得主角的角色控制器组件
        hero = GetComponent<CharacterController>();
    }
    void Update()
    {
        //如果主角距离点的距离大于0.2，则算出主角的朝向，移动主角人物
        if (Vector3.Distance(ignoreY(points[nextIndex % points.Length].position), ignoreY(transform.position)) > 0.2f)
        {
            //主角的朝向即为下一个点坐标减去主角坐标的向量
            Vector3 direction = (ignoreY(points[nextIndex % points.Length].position) - ignoreY(transform.position)).normalized;
            //插值改变主角的朝向，使其有一个自然转向的过程，防止其瞬间转向
            hero.transform.forward = Vector3.Lerp(transform.forward, direction, 0.1f);
            //移动主角
            hero.SimpleMove(transform.forward * moveSpeed);
        }
        else
        {
            //如果到达点，则使下一点作为目标点
            nextIndex++;
        }
    }
    //这个函数用来取消向量的Y轴影响，比如主角的高度与点之间可能有一段距离，我们要忽略这段距离
    Vector3 ignoreY(Vector3 v3)
    {
        return new Vector3(v3.x, 0, v3.z);
    }
}
