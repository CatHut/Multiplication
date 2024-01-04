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

        public QuestionClass()
        {
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            // 質問の生成と隠す値の決定をここで行います。
            // 空の定義としておきます。
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
