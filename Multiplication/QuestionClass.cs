using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication
{
    using System;

    public class QuestionClass
    {
        public int FirstValue { get; private set; }
        public int SecondValue { get; private set; }
        public int AnswerValue { get; private set; }
        public HiddenValueType HiddenValue { get; private set; }

        public QuestionClass(int first, int second)
        {
            GenerateQuestion(first, second);
        }

        private void GenerateQuestion(int first, int second)
        {
            FirstValue = first;
            SecondValue = second;
            AnswerValue = FirstValue * SecondValue;

            HiddenValue = HiddenValueType.ANSWER_VALUE;
        }

        private void GenerateQuestion(int first, int second, bool isHideRandom)
        {
            FirstValue = first;
            SecondValue = second;
            AnswerValue = FirstValue * SecondValue;
            HiddenValue = GetRandomHiddenValueType();

        }


        /// <summary>
        /// HiddenValueType enumからランダムな値を取得します。
        /// </summary>
        /// <returns>HiddenValueType enumからランダムに選ばれた値。</returns>
        public static HiddenValueType GetRandomHiddenValueType()
        {
            Random random = new Random();
            HiddenValueType[] values = (HiddenValueType[])Enum.GetValues(typeof(HiddenValueType));
            return values[random.Next(values.Length)];
        }

        public bool CheckAnswer(int userAnswer)
        {
            // ユーザーの回答が正しいかチェックします。
            switch (HiddenValue)
            {
                case HiddenValueType.FIRST_VALUE:
                    {
                        var temp = userAnswer * SecondValue;
                        if(AnswerValue == temp)
                        {
                            return true;
                        }
                        return false;
                    }
                case HiddenValueType.SECOND_VALUE:
                    {
                        var temp = userAnswer * FirstValue;
                        if (AnswerValue == temp)
                        {
                            return true;
                        }
                        return false;
                    }
                case HiddenValueType.ANSWER_VALUE:
                    {
                        var temp = SecondValue * FirstValue;
                        if (userAnswer == temp)
                        {
                            return true;
                        }
                        return false;
                    }

                default:
                    return false;
            }
        }
    }

}
