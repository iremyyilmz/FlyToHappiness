using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class Monster : MonoBehaviour
{
    List<GameObject> monsters = new List<GameObject>();
    List<GameObject> usedMonsters = new List<GameObject>();

    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Monsters");

        for(int i = 1; i < 6; i++)
        {
            GameObject monster = new GameObject();
            SpriteRenderer spriteRenderer = monster.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = (Sprite)sprites[i];
            monster.name = sprites[i].name;
            spriteRenderer.sortingLayerName = "Monster";
            ScaleMonster(monster.transform, 0.4f);
            Vector2 position = monster.transform.position;
            position.x = -10;
            monster.transform.position = position;
            monsters.Add(monster);
        }
    }

    void ScaleMonster(Transform monsterTransform, float scaleRatio)
    {
        monsterTransform.localScale *= scaleRatio;
    }
    
    public void MonsterTransform(float refY)
    {
        float height = ScreenCalculator.instance.Height;
        float width = ScreenCalculator.instance.Width;

        float xValue1 = Random.Range(0.0f, width);
        float yValue1 = Random.Range(refY, refY + height);
        GameObject monster1 = RandomMonster();
        monster1.transform.position = new Vector2(xValue1, yValue1);


        float xValue2 = Random.Range(-width, 0.0f);
        float yValue2 = Random.Range(refY, refY + height);
        GameObject monster2 = RandomMonster();
        monster2.transform.position = new Vector2(xValue2, yValue2);


        float xValue3 = Random.Range(-width, 0.0f);
        float yValue3 = Random.Range(refY - height, refY);
        GameObject monster3 = RandomMonster();
        monster3.transform.position = new Vector2(xValue3, yValue3);


        float xValue4 = Random.Range(0.0f, width);
        float yValue4 = Random.Range(refY - height, refY);
        GameObject monster4 = RandomMonster();
        monster4.transform.position = new Vector2(xValue4, yValue4);
    }

    GameObject RandomMonster()
    {
        if(monsters.Count > 0)
        {
            int random;

            if (monsters.Count == 1)
            {
                random = 0;
            }
            else
            {
                random = Random.Range(0, monsters.Count - 1);
            }
            GameObject monster = monsters[random];
            monsters.Remove(monster);
            usedMonsters.Add(monster);

            return monster;
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                monsters.Add(usedMonsters[i]);
            }
            usedMonsters.RemoveRange(0, 5);
            int random = Random.Range(0, 5);
            GameObject monster = monsters[random];
            monsters.Remove(monster);
            usedMonsters.Add(monster);

            return monster;
        }
    }
}
