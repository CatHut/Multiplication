using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication
{
    public class QuestionSetClass
    {

        private Queue<QuestionClass> Questions { get; set; }
        /// <summary>
        /// 問題の数値上限
        /// </summary>
        public int UpperLevel { get; private set; }
        /// <summary>
        /// 問題の数値下限
        /// </summary>
        public int LowerLevel { get; private set; }

        public QuestionClass CurrentQuestion { get; set; }
        private int InputIndex { get; set; }
        private int Answer { get; set; }

        private DateTime StartTime { get; set; }

        private DisplayControlClass DisplayControlClass { get; set; }


        public QuestionSetClass(int lower, int upper, DisplayControlClass displayControlClass)
        {
            UpperLevel = upper;
            LowerLevel = lower;

            DisplayControlClass = displayControlClass;

            GenerateQuestionSet();
        }

        public void RefreshQuestionSet()
        {
            GenerateQuestionSet();
        }


        private void GenerateQuestionSet()
        {
            Questions = Questions ?? new Queue<QuestionClass>();
            Questions.Clear();

            List<Point> temp = new List<Point>();

            // 問題セットの生成をここで行います。
            for (int i = LowerLevel; i < UpperLevel; i++)
            {
                for (int j = LowerLevel; j < UpperLevel; j++)
                {
                    temp.Add(new Point(i, j));
                }
            }

            Shuffle<Point>(temp);


            foreach(var xy in temp)
            {
                Questions.Enqueue(new QuestionClass(xy.X, xy.Y));
            }

        }

        /// <summary>
        /// Listの要素をランダムに並び替えます (Fisher-Yates shuffle)。
        /// </summary>
        /// <typeparam name="T">リストの型。</typeparam>
        /// <param name="list">並び替えるリスト。</param>
        public static void Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                T temp = list[i];
                list[i] = list[swapIndex];
                list[swapIndex] = temp;
            }
        }

        public QuestionClass GetNextQuestion()
        {
            // 次の問題を取得します。

            if (Questions.Count > 0)
            {
                CurrentQuestion = Questions.Dequeue();
                InputIndex = CurrentQuestion.AnswerValue.ToString().Length;

                StartTime = DateTime.Now;

                return CurrentQuestion;
            }
            else
            {
                // キューが空の場合の処理
                return null;
            }
        }

        public bool InputAnswer(int val, out TimeRecordClass trc)
        {
            var now = DateTime.Now;

            InputIndex--;
            Answer += val * ((int)(Math.Pow(10, InputIndex) + 0.5f));
            DisplayControlClass.AnswerValue[InputIndex].SetDisplay(DisplayMode.B, val);

            if(InputIndex <= 0)
            {
                //入力完了
                var result = CurrentQuestion.CheckAnswer(Answer);
                Answer = 0;
                trc = new TimeRecordClass(now, now - StartTime, result);

                return true;
            }

            //入力継続
            DisplayControlClass.AnswerValue[InputIndex - 1].SetDisplay(DisplayMode.A, val);

            trc = null;
            return false;
        }

    }
}
