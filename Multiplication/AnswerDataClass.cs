using CatHut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication
{
    public class AnswerDataClass
    {
        public SerializableDictionary<int, SerializableDictionary<int, EachTypeRecordClass>> AnswerData;

        public AnswerDataClass() {
            
            //処理なし

        }

        public void Initialize()
        {
            AnswerData = new SerializableDictionary<int, SerializableDictionary<int, EachTypeRecordClass>>();

            for (int i = 1; i < 100; i++)
            {
                AnswerData[i] = new SerializableDictionary<int, EachTypeRecordClass>();
                for (int j = 1; j < 100; j++)
                {
                    AnswerData[i][j] = new EachTypeRecordClass();
                    AnswerData[i][j].EachTypeRecord = new SerializableDictionary<HiddenValueType, List<TimeRecordClass>>();
                }
            }
        }
    }

    public class EachTypeRecordClass
    {
        public SerializableDictionary<HiddenValueType, List<TimeRecordClass>> EachTypeRecord;

        public EachTypeRecordClass()
        {
            EachTypeRecord = new SerializableDictionary<HiddenValueType, List<TimeRecordClass>>();
        }
    }

    public class TimeRecordClass
    {
        public DateTime DateTime { get; set; }  //回答日時
        public TimeSpan Time { get; set; }  //回答時間
        public bool IsCorrect { get; set; }  //正解したか
    }
}
