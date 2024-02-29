
//using System.Collections.Generic;
//using UnityEngine;

//public class CharacterAppearance : MonoBehaviour
//{
//    //public enum Gender { Male, Female }
//    public CharacterObjectGroups male;
//    public CharacterObjectGroups female;
//    public CharacterObjectListsAllGender allGender;

//    //[SerializeField] private Gender gender = Gender.Male;

//    private void Awake()
//    {
//        BuildLists();
//    }
//    private void Start()
//    {
//         //Initiallize();
//    }
//    private void Initiallize()
//    {
        
//    }
//    private void BuildLists()
//    {
//        //build out male lists
//        BuildList(maleList, "Male_Head_All_Elements");
//        BuildList(maleList, "Male_Head_No_Elements");
//        BuildList(maleList, "Male_01_Eyebrows");
//        BuildList(maleList, "Male_02_FacialHair");
//        BuildList(maleList, "Male_03_Torso");
//        BuildList(maleList, "Male_04_Arm_Upper_Right");
//        BuildList(maleList, "Male_05_Arm_Upper_Left");
//        BuildList(maleList, "Male_06_Arm_Lower_Right");
//        BuildList(maleList, "Male_07_Arm_Lower_Left");
//        BuildList(maleList, "Male_08_Hand_Right");
//        BuildList(maleList, "Male_09_Hand_Left");
//        BuildList(maleList, "Male_10_Hips");
//        BuildList(maleList, "Male_11_Leg_Right");
//        BuildList(maleList, "Male_12_Leg_Left");

//        //build out female lists
//        //BuildList(female.headAllElements, "Female_Head_All_Elements");
//        //BuildList(female.headNoElements, "Female_Head_No_Elements");
//        //BuildList(female.eyebrow, "Female_01_Eyebrows");
//        //BuildList(female.facialHair, "Female_02_FacialHair");
//        //BuildList(female.torso, "Female_03_Torso");
//        //BuildList(female.armUpperRight, "Female_04_Arm_Upper_Right");
//        //BuildList(female.armUpperLeft, "Female_05_Arm_Upper_Left");
//        //BuildList(female.armLowerRight, "Female_06_Arm_Lower_Right");
//        //BuildList(female.armLowerLeft, "Female_07_Arm_Lower_Left");
//        //BuildList(female.handRight, "Female_08_Hand_Right");
//        //BuildList(female.handLeft, "Female_09_Hand_Left");
//        //BuildList(female.hips, "Female_10_Hips");
//        //BuildList(female.legRight, "Female_11_Leg_Right");
//        //BuildList(female.legLeft, "Female_12_Leg_Left");

//        //// build out all gender lists
//        //BuildList(allGender.allHair, "All_01_Hair");
//        //BuildList(allGender.allHeadAttachment, "All_02_Head_Attachment");
//        //BuildList(allGender.headCoveringsBaseHair, "HeadCoverings_Base_Hair");
//        //BuildList(allGender.headCoveringsNoFacialHair, "HeadCoverings_No_FacialHair");
//        //BuildList(allGender.headCoveringsNoHair, "HeadCoverings_No_Hair");
//        //BuildList(allGender.chestAttachment, "All_03_Chest_Attachment");
//        //BuildList(allGender.backAttachment, "All_04_Back_Attachment");
//        //BuildList(allGender.shoulderAttachmentRight, "All_05_Shoulder_Attachment_Right");
//        //BuildList(allGender.shoulderAttachmentLeft, "All_06_Shoulder_Attachment_Left");
//        //BuildList(allGender.elbowAttachmentRight, "All_07_Elbow_Attachment_Right");
//        //BuildList(allGender.elbowAttachmentLeft, "All_08_Elbow_Attachment_Left");
//        //BuildList(allGender.hipsAttachment, "All_09_Hips_Attachment");
//        //BuildList(allGender.kneeAttachementRight, "All_10_Knee_Attachement_Right");
//        //BuildList(allGender.kneeAttachementLeft, "All_11_Knee_Attachement_Left");
//        //BuildList(allGender.elfEar, "Elf_Ear");
//    }
//    void BuildList(List<GameObject> targetList, string characterPart)
//    {
//        Transform[] rootTransform = gameObject.GetComponentsInChildren<Transform>();
//        Transform targetRoot = null;
//        foreach (Transform t in rootTransform)
//        {
//            if (t.gameObject.name == characterPart)
//            {
//                targetRoot = t;
//                break;
//            }
//        }
        
//        for (int i = 0; i < targetRoot.childCount; i++)
//        {
//            GameObject go = targetRoot.GetChild(i).gameObject;
//            if(go.activeSelf)
//            {
//                targetList.Add(go);
//            }
//        }
//    }
//}

////[System.Serializable]
////public class CharacterObjectGroups
////{
////    public List<GameObject> headAllElements;
////    public List<GameObject> headNoElements;
////    public List<GameObject> eyebrow;
////    public List<GameObject> facialHair;
////    public List<GameObject> torso;
////    public List<GameObject> armUpperRight;
////    public List<GameObject> armUpperLeft;
////    public List<GameObject> armLowerRight;
////    public List<GameObject> armLowerLeft;
////    public List<GameObject> handRight;
////    public List<GameObject> handLeft;
////    public List<GameObject> hips;
////    public List<GameObject> legRight;
////    public List<GameObject> legLeft;
////}
////[System.Serializable]
////public class CharacterObjectListsAllGender
////{
////    public List<GameObject> headCoveringsBaseHair;
////    public List<GameObject> headCoveringsNoFacialHair;
////    public List<GameObject> headCoveringsNoHair;
////    public List<GameObject> allHair;
////    public List<GameObject> allHeadAttachment;
////    public List<GameObject> chestAttachment;
////    public List<GameObject> backAttachment;
////    public List<GameObject> shoulderAttachmentRight;
////    public List<GameObject> shoulderAttachmentLeft;
////    public List<GameObject> elbowAttachmentRight;
////    public List<GameObject> elbowAttachmentLeft;
////    public List<GameObject> hipsAttachment;
////    public List<GameObject> kneeAttachementRight;
////    public List<GameObject> kneeAttachementLeft;
////    public List<GameObject> all1Extra;
////    public List<GameObject> elfEar;
////}