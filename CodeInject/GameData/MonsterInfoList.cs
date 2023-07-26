using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeInject.GameData
{
    class GameInfoList
    {
        public static MonstersDataLoader MonsterInfo = new MonstersDataLoader();
        public static SkillDataLoader   SkillInfo = new SkillDataLoader();

        public static UseItemDataLoader UseItemInfo = new UseItemDataLoader();


        public static string GetNameMonsterByID(int id)
        {
            MonsterData monsterData = MonsterInfo.MonsterDataList.FirstOrDefault(x => x.Id == id);
           
            return monsterData!=null? monsterData.Name: "unknow "+id.ToString();
        }


        public static string GetNameSkillByID(int id)
        {
            SkillData skillData = SkillInfo.SkillDataList.FirstOrDefault(x => x.Id == id);

            return skillData != null ? skillData.Name : "unknow " + id.ToString();
        }


        public static UseItemData GetUseItemByID(int id)
        {
            UseItemData skillData = UseItemInfo.UseItemDataList.FirstOrDefault(x => x.Id == id);

            return skillData;
        }

        private GameInfoList() {

           
        }
    }

    public class SkillData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MonsterData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UseItemData
    {
        public int Id { get; set; }
        public string UseName { get; set; }
        public string Name { get; set; }
    }

    public class UseItemDataLoader
    {
        public List<UseItemData> UseItemDataList { get; set; } = new List<UseItemData>();

        public UseItemDataLoader()
        {
            StreamReader skillDataFile = new StreamReader("iuseItemList.txt");

            int id;
            string name;
            string line;
            while (!skillDataFile.EndOfStream)
            {
                line = skillDataFile.ReadLine();

                string[] splitedData = line.Split(';');

                if (splitedData.Length == 3 && splitedData[0] != "" && splitedData[1] != "")
                {
                    UseItemDataList.Add(new UseItemData()
                    {
                        Id = int.TryParse(splitedData[0], out int x) ? int.Parse(splitedData[0]) : 0,
                        UseName = splitedData[1],
                        Name = splitedData[2]
                    });
                }
            }
        }
    }


    public class SkillDataLoader
    {
        public List<SkillData> SkillDataList { get; set; } = new List<SkillData>();

        public SkillDataLoader()
        {
            StreamReader skillDataFile = new StreamReader("skillList.txt");

            int id;
            string name;
            string line;
            while (!skillDataFile.EndOfStream)
            {
                line = skillDataFile.ReadLine();

                string[] splitedData = line.Split(';');

                if (splitedData.Length == 2 && splitedData[0] != "" && splitedData[1] != "")
                {
                    SkillDataList.Add(new SkillData()
                    {
                        Id = int.TryParse(splitedData[0],out int x)?int.Parse(splitedData[0]):0,
                        Name = splitedData[1]
                    });
                }
            }
        }
    }

    public class MonstersDataLoader
    {
        public List<MonsterData> MonsterDataList { get; set; } = new List<MonsterData>();

        public MonstersDataLoader()
        {
            StreamReader monsterDataFile = new StreamReader("monsterList.txt");

            int id;
            string name;
            string line;
            while (!monsterDataFile.EndOfStream)
            {
                line = monsterDataFile.ReadLine();

                string[] splitedData = line.Split(';');

                  if (splitedData.Length == 2 && splitedData[0]!="" && splitedData[1]!="")
                {
                    MonsterDataList.Add(new MonsterData()
                    {
                        Id = int.Parse(splitedData[0]),
                        Name = splitedData[1]
                    });
                }
            }
        }
    }

}
