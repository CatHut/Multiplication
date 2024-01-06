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
        Thousands = 3
    }


    public class DisplayControlClass
    {
        private readonly Point FirstValueBasePoint = new Point(30, 100);
        private readonly Point SecondValueBasePoint = new Point(400, 100);
        private readonly Point AnswerValueBasePoint = new Point(700, 100);

        List<ShapeDisplayControlClass> FirstValue = new List<ShapeDisplayControlClass>();
        List<ShapeDisplayControlClass> SecondValue = new List<ShapeDisplayControlClass>();
        List<ShapeDisplayControlClass> AnswerValue = new List<ShapeDisplayControlClass>();
        private Form form;

        public DisplayControlClass(Form form)
        {
            this.form = form;


            FirstValue.Add(new ShapeDisplayControlClass(form, new Point(FirstValueBasePoint.X + 10 + 130, FirstValueBasePoint.Y)));
            FirstValue.Add(new ShapeDisplayControlClass(form, new Point(FirstValueBasePoint.X + 10, FirstValueBasePoint.Y)));

            SecondValue.Add(new ShapeDisplayControlClass(form, new Point(SecondValueBasePoint.X + 10 + 130, SecondValueBasePoint.Y)));
            SecondValue.Add(new ShapeDisplayControlClass(form, new Point(SecondValueBasePoint.X + 10, SecondValueBasePoint.Y)));

            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + 10 + 130 + 130 + 130, AnswerValueBasePoint.Y)));
            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + 10 + 130 + 130, AnswerValueBasePoint.Y)));
            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + 10 + 130, AnswerValueBasePoint.Y)));
            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + 10, AnswerValueBasePoint.Y)));



        }

        public void RefreshQuestion(QuestionClass question)
        {
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
        }

    }
}
