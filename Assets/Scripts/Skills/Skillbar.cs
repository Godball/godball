using UnityEngine;
using System.Collections;

public class Skillbar : MonoBehaviour
{

    private Skill[] skills;

    private Skill activeSkill;

    void Start()
    {
        skills = GetComponentsInChildren<Skill>();
        SetActiveSkill((skills.Length > 0) ? skills[0] : null);
    }

    public void SetActiveSkill(Skill newActiveSkill)
    {
        activeSkill = newActiveSkill;
        foreach (var skill in skills)
        {
            skill.gameObject.SetActive(skill == activeSkill);
        }
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        // go through entire skillbar
        foreach (var skill in skills)
        {
            // active skill green, on cooldown red, all other grey
            GUI.color = Color.grey;
            if (skill == activeSkill) GUI.color = Color.green;
            if (skill.isOnCooldown()) GUI.color = Color.red;

            if (GUILayout.Button(skill.SkillName, GUILayout.Width(150), GUILayout.Height(64)))
            {
                SetActiveSkill(skill);
            }


        }
        GUILayout.EndHorizontal();
    }

}
