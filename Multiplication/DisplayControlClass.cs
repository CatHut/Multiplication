using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication
{

    /// <summary>
    /// 数値の位を表す列挙型です。
    /// </summary>
    public enum NumberPlace
    {
        Ones = 0,
        Tens = 1,
        Hundreds = 2,
        Thousands = 3,
        All = 4
    }


    public class DisplayControlClass
    {
        private readonly Point FirstValueBasePoint = new Point(30, 100);
        private readonly Point SecondValueBasePoint = new Point(400, 100);
        private readonly Point AnswerValueBasePoint = new Point(800, 100);

        private int SingleWidth = 130;
        private int Padding = 10;

        private List<ShapeDisplayControlClass> FirstValue = new List<ShapeDisplayControlClass>();
        private List<ShapeDisplayControlClass> SecondValue = new List<ShapeDisplayControlClass>();
        public List<ShapeDisplayControlClass> AnswerValue = new List<ShapeDisplayControlClass>();
        private Form form;

        public DisplayControlClass(Form form)
        {
            this.form = form;


            FirstValue.Add(new ShapeDisplayControlClass(form, new Point(FirstValueBasePoint.X + Padding + SingleWidth, FirstValueBasePoint.Y)));
            FirstValue.Add(new ShapeDisplayControlClass(form, new Point(FirstValueBasePoint.X + Padding, FirstValueBasePoint.Y)));

            SecondValue.Add(new ShapeDisplayControlClass(form, new Point(SecondValueBasePoint.X + Padding + SingleWidth, SecondValueBasePoint.Y)));
            SecondValue.Add(new ShapeDisplayControlClass(form, new Point(SecondValueBasePoint.X + Padding, SecondValueBasePoint.Y)));

            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + Padding + SingleWidth + SingleWidth + SingleWidth, AnswerValueBasePoint.Y)));
            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + Padding + SingleWidth + SingleWidth, AnswerValueBasePoint.Y)));
            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + Padding + SingleWidth, AnswerValueBasePoint.Y)));
            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + Padding, AnswerValueBasePoint.Y)));



        }

        public void RefreshQuestion(QuestionClass question)
        {
            //第１項表示
            {
                var val = question.FirstValue;
                var ones = val % 10;
                var tens = val / 10;
                FirstValue[(int)NumberPlace.Ones].SetDisplay(DisplayMode.D, ones);
                if (tens == 0)
                {
                    FirstValue[(int)NumberPlace.Tens].SetDisplay(DisplayMode.E, tens);
                }
                else
                {
                    FirstValue[(int)NumberPlace.Tens].SetDisplay(DisplayMode.D, tens);
                }

            }

            //第２項表示
            {
                var val = question.SecondValue;
                var ones = val % 10;
                var tens = val / 10;

                SecondValue[(int)NumberPlace.Ones].SetDisplay(DisplayMode.D, ones);

                if (tens == 0)
                {
                    SecondValue[(int)NumberPlace.Tens].SetDisplay(DisplayMode.E, tens);
                }
                else
                {
                    SecondValue[(int)NumberPlace.Tens].SetDisplay(DisplayMode.D, tens);
                }
            }

            //回答表示
            {
                var val = question.AnswerValue;
                RefreshAnswerValue(val);
            }
        }

        public void Draw(Graphics g)
        {
            foreach(var shapeControl in FirstValue)
            {
                shapeControl.Draw(g);
            }

            foreach (var shapeControl in SecondValue)
            {
                shapeControl.Draw(g);
            }

            foreach (var shapeControl in AnswerValue)
            {
                shapeControl.Draw(g);
            }
        }

        private void SetFirstValue(int val)
        {
        }

        private void SetAnswerValue(int val)
        {

        }

        private void RefreshAnswerValue(int val)
        {
            int numberOfDigits = val.ToString().Length; // valの桁数を計算
            NumberPlace[] places = { NumberPlace.Ones, NumberPlace.Tens, NumberPlace.Hundreds, NumberPlace.Thousands };

            for (int i = 0; i < places.Length; i++)
            {
                DisplayMode mode = ((i + 1) == numberOfDigits) ? DisplayMode.A : DisplayMode.C;
                if((i + 1) > numberOfDigits) { mode = DisplayMode.E; }

                int digitValue = (val / (int)Math.Pow(10, i)) % 10;

                AnswerValue[(int)places[i]].SetDisplay(mode, digitValue);
            }

            LeftJustificationAnswerValue(val);
        }

        private void LeftJustificationAnswerValue(int val)
        {
            int numberOfDigits = val.ToString().Length; // valの桁数を計算

            for(int i = 0; i < numberOfDigits; i++)
            {
                AnswerValue[i].BaseLocation = new Point(AnswerValueBasePoint.X + Padding + SingleWidth * (numberOfDigits - i - 1), AnswerValueBasePoint.Y);
            }
        }

    }
}
