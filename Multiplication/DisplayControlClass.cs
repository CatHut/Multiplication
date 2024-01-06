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
        List<ShapeDisplayControlClass> FirstValue = new List<ShapeDisplayControlClass>();
        List<ShapeDisplayControlClass> SecondValue = new List<ShapeDisplayControlClass>();
        List<ShapeDisplayControlClass> AnswerValue = new List<ShapeDisplayControlClass>();
        private Form form;

        public DisplayControlClass(Form form)
        {
            this.form = form;

            Point FirstValueBasePoint = new Point(30, 100);
            Point SecondValueBasePoint = new Point(400, 100);
            Point AnswerValueBasePoint = new Point(700, 100);

            FirstValue.Add(new ShapeDisplayControlClass(form, new Point(FirstValueBasePoint.X + 10 + 130, FirstValueBasePoint.Y)));
            FirstValue.Add(new ShapeDisplayControlClass(form, new Point(FirstValueBasePoint.X + 10, FirstValueBasePoint.Y)));

            SecondValue.Add(new ShapeDisplayControlClass(form, new Point(SecondValueBasePoint.X + 10 + 130, SecondValueBasePoint.Y)));
            SecondValue.Add(new ShapeDisplayControlClass(form, new Point(SecondValueBasePoint.X + 10, SecondValueBasePoint.Y)));

            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + 10 + 130 + 130 + 130, AnswerValueBasePoint.Y)));
            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + 10 + 130 + 130, AnswerValueBasePoint.Y)));
            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + 10 + 130, AnswerValueBasePoint.Y)));
            AnswerValue.Add(new ShapeDisplayControlClass(form, new Point(AnswerValueBasePoint.X + 10, AnswerValueBasePoint.Y)));

            SetFirstValue(15);

        }

        public void RefreshQuestion(QuestionClass question)
        {
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
            FirstValue[(int)NumberPlace.Ones].SetDisplay(DisplayMode.A, val % 10);
            FirstValue[(int)NumberPlace.Tens].SetDisplay(DisplayMode.A, val / 10);
        }

    }
}
