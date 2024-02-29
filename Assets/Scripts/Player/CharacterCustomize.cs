using System;
using System.Collections.Generic;
using UnityEngine;
public enum BodyPart
{
    Hairs = 0,
    HeadAllElements = 1,
    Eyebrow = 2,
    FacialHair = 3,
    Torso = 4,
    Arm_Upper_Right = 5,
    Arm_Upper_Left = 6,
    Arm_Lower_Right = 7,
    Arm_Lower_Left = 8,
    Hand_Right = 9,
    Hand_Left = 10,
    Hips = 11,
    Leg_Right = 12,
    Leg_Left = 13,
}
public enum Gender {Male,Female}
public class CharacterCustomize : MonoBehaviour
{
    // public List<GameObject> BodyParts = new List<GameObject>();
    public Dictionary<BodyPart, GameObject> BodyParts = new Dictionary<BodyPart, GameObject>()
    {
    { BodyPart.Hairs, null },
    { BodyPart.HeadAllElements, null },
    { BodyPart.Eyebrow, null },
    { BodyPart.FacialHair, null },
    { BodyPart.Torso, null },
    { BodyPart.Arm_Upper_Right, null },
    { BodyPart.Arm_Upper_Left, null },
    { BodyPart.Arm_Lower_Right, null },
    { BodyPart.Arm_Lower_Left, null },
    { BodyPart.Hand_Right, null },
    { BodyPart.Hand_Left, null },
    { BodyPart.Hips, null },
    { BodyPart.Leg_Right, null },
    { BodyPart.Leg_Left, null }
    };
    public Gender gender = Gender.Male;
    [HideInInspector]
    public CharacterObjectGroups male;
    [HideInInspector]
    public CharacterObjectGroups female;
    [HideInInspector]
    public CharacterObjectListsAllGender allGender;
    private void Awake()
    {
        BuildLists();
    }
    private void Start()
    {
        ActiveItem(male.headAllElements[0],BodyPart.HeadAllElements);
        ActiveItem(male.eyebrow[0],BodyPart.Eyebrow);
        ActiveItem(male.torso[0],BodyPart.Torso);
        ActiveItem(male.armUpperRight[0],BodyPart.Arm_Upper_Right);
        ActiveItem(male.armUpperLeft[0],BodyPart.Arm_Upper_Left);
        ActiveItem(male.armLowerRight[0],BodyPart.Arm_Lower_Right);
        ActiveItem(male.armLowerLeft[0],BodyPart.Arm_Lower_Left);
        ActiveItem(male.handRight[0],BodyPart.Hand_Right);
        ActiveItem(male.handLeft[0],BodyPart.Hand_Left);
        ActiveItem(male.hips[0],BodyPart.Hips);
        ActiveItem(male.legRight[0],BodyPart.Leg_Right);
        ActiveItem(male.legLeft[0],BodyPart.Leg_Left);
    }
    private void BuildLists()
    {
        //build out male lists
        BuildList(male.headAllElements, "Male_Head_All_Elements");
        BuildList(male.headNoElements, "Male_Head_No_Elements");
        BuildList(male.eyebrow, "Male_01_Eyebrows");
        BuildList(male.facialHair, "Male_02_FacialHair");
        BuildList(male.torso, "Male_03_Torso");
        BuildList(male.armUpperRight, "Male_04_Arm_Upper_Right");
        BuildList(male.armUpperLeft, "Male_05_Arm_Upper_Left");
        BuildList(male.armLowerRight, "Male_06_Arm_Lower_Right");
        BuildList(male.armLowerLeft, "Male_07_Arm_Lower_Left");
        BuildList(male.handRight, "Male_08_Hand_Right");
        BuildList(male.handLeft, "Male_09_Hand_Left");
        BuildList(male.hips, "Male_10_Hips");
        BuildList(male.legRight, "Male_11_Leg_Right");
        BuildList(male.legLeft, "Male_12_Leg_Left");

        //build out female lists
        BuildList(female.headAllElements, "Female_Head_All_Elements");
        BuildList(female.headNoElements, "Female_Head_No_Elements");
        BuildList(female.eyebrow, "Female_01_Eyebrows");
        BuildList(female.facialHair, "Female_02_FacialHair");
        BuildList(female.torso, "Female_03_Torso");
        BuildList(female.armUpperRight, "Female_04_Arm_Upper_Right");
        BuildList(female.armUpperLeft, "Female_05_Arm_Upper_Left");
        BuildList(female.armLowerRight, "Female_06_Arm_Lower_Right");
        BuildList(female.armLowerLeft, "Female_07_Arm_Lower_Left");
        BuildList(female.handRight, "Female_08_Hand_Right");
        BuildList(female.handLeft, "Female_09_Hand_Left");
        BuildList(female.hips, "Female_10_Hips");
        BuildList(female.legRight, "Female_11_Leg_Right");
        BuildList(female.legLeft, "Female_12_Leg_Left");

        // build out all gender lists
        BuildList(allGender.allHair, "All_01_Hair");
        BuildList(allGender.allHeadAttachment, "All_02_Head_Attachment");
        BuildList(allGender.headCoveringsBaseHair, "HeadCoverings_Base_Hair");
        BuildList(allGender.headCoveringsNoFacialHair, "HeadCoverings_No_FacialHair");
        BuildList(allGender.headCoveringsNoHair, "HeadCoverings_No_Hair");
        BuildList(allGender.chestAttachment, "All_03_Chest_Attachment");
        BuildList(allGender.backAttachment, "All_04_Back_Attachment");
        BuildList(allGender.shoulderAttachmentRight, "All_05_Shoulder_Attachment_Right");
        BuildList(allGender.shoulderAttachmentLeft, "All_06_Shoulder_Attachment_Left");
        BuildList(allGender.elbowAttachmentRight, "All_07_Elbow_Attachment_Right");
        BuildList(allGender.elbowAttachmentLeft, "All_08_Elbow_Attachment_Left");
        BuildList(allGender.hipsAttachment, "All_09_Hips_Attachment");
        BuildList(allGender.kneeAttachementRight, "All_10_Knee_Attachement_Right");
        BuildList(allGender.kneeAttachementLeft, "All_11_Knee_Attachement_Left");
        BuildList(allGender.elfEar, "Elf_Ear");
    }
    private void BuildList(List<GameObject> targetList, string characterPart)
    {
        Transform[] rootTransform = gameObject.GetComponentsInChildren<Transform>();
        Transform targetRoot = null;
        foreach (Transform t in rootTransform)
        {
            if (t.gameObject.name == characterPart)
            {
                targetRoot = t;
                break;
            }
        }
        targetList.Clear();
        for (int i = 0; i < targetRoot.childCount; i++)
        {
            GameObject go = targetRoot.GetChild(i).gameObject;
            go.SetActive(false);
            targetList.Add(go);
            
        }
    }
    private int GetCurrentIndex(List<GameObject> target)
    {
        int index = -1;
        foreach (GameObject go in target)
        {
            if (go.activeSelf)
            {
                index = target.IndexOf(go);
                break;
            }
        }

        return index;
    }
    private void ActiveItem(GameObject go, BodyPart bodypart)
    {
        go.SetActive(true);
        if(BodyParts.ContainsKey(bodypart))
        {
            BodyParts[bodypart] = go;
        }
    }
    private void DeActiveItem(BodyPart bodypart)
    {
        if (BodyParts.ContainsKey(bodypart) && BodyParts[bodypart] != null)
        {
            BodyParts[bodypart].SetActive(false);
            BodyParts[bodypart] = null;
        }
    }
    public void ChangeHair(bool increase)
    {
        int index = GetCurrentIndex(allGender.allHair);
        DeActiveItem(BodyPart.Hairs);
        if (increase)
        {
            if (index != allGender.allHair.Count - 1)
            {
                index = (index + 1) % allGender.allHair.Count;
                ActiveItem(allGender.allHair[index], BodyPart.Hairs);
            }
        }
        else
        {
            if (index != 0)
            {
                index = (index - 1 + allGender.allHair.Count + 1) % (allGender.allHair.Count + 1);
                ActiveItem(allGender.allHair[index], BodyPart.Hairs);
            }
        }
    }

    public void ChangeGender(Gender newGender)
    {
        gender = newGender;
    }
 
}

[System.Serializable]
public class CharacterObjectGroups
{
    public List<GameObject> headAllElements;
    public List<GameObject> headNoElements;
    public List<GameObject> eyebrow;
    public List<GameObject> facialHair;
    public List<GameObject> torso;
    public List<GameObject> armUpperRight;
    public List<GameObject> armUpperLeft;
    public List<GameObject> armLowerRight;
    public List<GameObject> armLowerLeft;
    public List<GameObject> handRight;
    public List<GameObject> handLeft;
    public List<GameObject> hips;
    public List<GameObject> legRight;
    public List<GameObject> legLeft;
}
[System.Serializable]
public class CharacterObjectListsAllGender
{
    public List<GameObject> headCoveringsBaseHair;
    public List<GameObject> headCoveringsNoFacialHair;
    public List<GameObject> headCoveringsNoHair;
    public List<GameObject> allHair;
    public List<GameObject> allHeadAttachment;
    public List<GameObject> chestAttachment;
    public List<GameObject> backAttachment;
    public List<GameObject> shoulderAttachmentRight;
    public List<GameObject> shoulderAttachmentLeft;
    public List<GameObject> elbowAttachmentRight;
    public List<GameObject> elbowAttachmentLeft;
    public List<GameObject> hipsAttachment;
    public List<GameObject> kneeAttachementRight;
    public List<GameObject> kneeAttachementLeft;
    public List<GameObject> all1Extra;
    public List<GameObject> elfEar;
}