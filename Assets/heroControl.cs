using UnityEngine;
using System.Collections;

public class heroControl : MonoBehaviour {

    //�������ǽ�ɫ������
    CharacterController hero;

    //������
    public Transform[] points;

    //��һ������±꣬�����ƶ��ٶ�
    public int nextIndex;
    public int moveSpeed = 10;

    void Start()
    {
        //��ʼ�������ƶ��ٶ�
        nextIndex = 0;
        //������ǵĽ�ɫ���������
        hero = GetComponent<CharacterController>();
    }
    void Update()
    {
        //������Ǿ����ľ������0.2����������ǵĳ����ƶ���������
        if (Vector3.Distance(ignoreY(points[nextIndex % points.Length].position), ignoreY(transform.position)) > 0.2f)
        {
            //���ǵĳ���Ϊ��һ���������ȥ�������������
            Vector3 direction = (ignoreY(points[nextIndex % points.Length].position) - ignoreY(transform.position)).normalized;
            //��ֵ�ı����ǵĳ���ʹ����һ����Ȼת��Ĺ��̣���ֹ��˲��ת��
            hero.transform.forward = Vector3.Lerp(transform.forward, direction, 0.1f);
            //�ƶ�����
            hero.SimpleMove(transform.forward * moveSpeed);
        }
        else
        {
            //�������㣬��ʹ��һ����ΪĿ���
            nextIndex++;
        }
    }
    //�����������ȡ��������Y��Ӱ�죬�������ǵĸ߶����֮�������һ�ξ��룬����Ҫ������ξ���
    Vector3 ignoreY(Vector3 v3)
    {
        return new Vector3(v3.x, 0, v3.z);
    }
}
