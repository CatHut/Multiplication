using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication
{
    public class QuestionSetClass
    {

        public List<QuestionClass> Questions { get; private set; }
        public int NumberOfQuestions { get; private set; }
        private int CurrentQuestionIndex;

        public QuestionSetClass(int numberOfQuestions)
        {
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<QuestionClass>();
            GenerateQuestionSet();
        }

        private void GenerateQuestionSet()
        {
            // 問題セットの生成をここで行います。
            // 空の定義としておきます。
        }

        public QuestionClass GetNextQuestion()
        {
            // 次の問題を取得します。
            // 空の定義としておきます。
            return null;
        }

        public bool IsQuestionAnswered(int questionIndex)
        {
            // 特定の問題が回答されたかどうかをチェックします。
            // 空の定義としておきます。
            return false;
        }

        public bool IsAnswerCorrect(int questionIndex)
        {
            // 特定の問題に対する回答が正しいかどうかをチェックします。
            // 空の定義としておきます。
            return false;
        }
    }
}
