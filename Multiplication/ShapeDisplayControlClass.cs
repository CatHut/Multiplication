using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatHut;

namespace Multiplication
{

    /// <summary>
    /// 表示モードを定義する列挙型です。
    /// </summary>
    public enum DisplayMode
    {
        A,
        B,
        C,
        D
    }

    /// <summary>
    /// 図形と数字の表示切り替えを行うクラスです。
    /// </summary>
    public class ShapeDisplayControl
    {
        private ShapeDrawerClass shapeDrawer;
        private Label numberLabel;
        private Form form;

        /// <summary>
        /// ShapeDisplayControlクラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="form">描画を行うフォームのインスタンスです。</param>
        public ShapeDisplayControl(Form form)
        {
            this.form = form;
            this.shapeDrawer = new ShapeDrawerClass();
            this.numberLabel = new Label
            {
                AutoSize = true,
                Location = new Point(150, 150), // ラベルの位置は適宜調整してください。
                Font = new Font("Arial", 24, FontStyle.Bold)
            };
            this.form.Controls.Add(this.numberLabel);
        }

        /// <summary>
        /// 指定された表示モードに応じて図形と数字の表示を切り替えます。
        /// </summary>
        /// <param name="mode">表示モードを指定するDisplayMode列挙型です。</param>
        /// <param name="number">表示する数字です。</param>
        public void SetDisplayMode(DisplayMode mode, string number)
        {
            shapeDrawer.ClearShapes(); // 現在の図形をすべてクリア
            numberLabel.Visible = false; // ラベルを非表示に設定

            switch (mode)
            {
                case DisplayMode.A:
                    // 上下の三角形と四角枠を追加
                    shapeDrawer.AddShape(new Triangle(new Point(100, 100), new Size(50, 50), false, TriangleDirection.Up));
                    shapeDrawer.AddShape(new Triangle(new Point(100, 150), new Size(50, 50), false, TriangleDirection.Down));
                    shapeDrawer.AddShape(new CatHut.Rectangle(new Point(100, 100), new Size(50, 100), false));
                    numberLabel.Text = number;
                    numberLabel.Visible = true;
                    break;
                case DisplayMode.B:
                    // 四角枠を追加
                    shapeDrawer.AddShape(new CatHut.Rectangle(new Point(100, 100), new Size(50, 100), false));
                    numberLabel.Text = number;
                    numberLabel.Visible = true;
                    break;
                case DisplayMode.C:
                    // 四角枠のみを追加
                    shapeDrawer.AddShape(new CatHut.Rectangle(new Point(100, 100), new Size(50, 100), false));
                    break;
                case DisplayMode.D:
                    // 数字のみ表示
                    numberLabel.Text = number;
                    numberLabel.Visible = true;
                    break;
            }

            form.Invalidate(); // 描画を更新
        }
    }

}
