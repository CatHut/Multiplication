﻿using System;
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


        public QuestionSetClass(int lower, int upper)
        {
            UpperLevel = upper;
            LowerLevel = lower;

            Questions = new Queue<QuestionClass>();
            GenerateQuestionSet();
        }

        private void GenerateQuestionSet()
        {
            List<Point> temp = new List<Point>();

            // 問題セットの生成をここで行います。
            for(int i = LowerLevel; i < UpperLevel; i++)
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
                return Questions.Dequeue();
            }
            else
            {
                // キューが空の場合の処理
                return null;
            }
        }

    }
}
