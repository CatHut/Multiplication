using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Permissions;
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
        A, //入力フォーカス
        B, //入力済
        C, //入力待ち
        D, //数値のみ
        E //何も表示しない
    }

    /// <summary>
    /// 図形と数字の表示切り替えを行うクラスです。
    /// </summary>
    public class ShapeDisplayControlClass
    {
        private ShapeDrawerClass shapeDrawer;
        private Label numberLabel;
        private Form form;
        private Point baseLocation; // 基準位置
        private Point labelBaseLocation = new Point(15, 10); // 初期位置

        /// <summary>
        /// ShapeDisplayControlの基準位置を設定または取得します。
        /// </summary>
        public Point BaseLocation
        {
            get => baseLocation;
            set
            {
                baseLocation = value;
                UpdateChildControls(); // 子要素の位置を更新
            }
        }

        /// <summary>
        /// ShapeDisplayControlClassの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="form">描画を行うフォームのインスタンスです。</param>
        public ShapeDisplayControlClass(Form form)
        {
            this.form = form;
            this.shapeDrawer = new ShapeDrawerClass();
            this.numberLabel = new Label
            {
                AutoSize = false,
                Location = labelBaseLocation, // 初期位置
                Font = new Font("Arial", 130, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(100, 180),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.form.Controls.Add(this.numberLabel);
            this.BaseLocation = new Point(0, 0); // 初期基準位置
        }

        /// <summary>
        /// ShapeDisplayControlClassの新しいインスタンスを初期化し、基準位置を指定します。
        /// </summary>
        /// <param name="form">描画を行うフォームのインスタンスです。</param>
        /// <param name="baseLocation">このコントロールの基準位置です。</param>
        public ShapeDisplayControlClass(Form form, Point baseLocation) : this(form)
        {
            this.BaseLocation = baseLocation;
        }

        /// <summary>
        /// 子要素の位置を更新します。
        /// </summary>
        private void UpdateChildControls()
        {
            foreach (var shape in shapeDrawer.Shapes)
            {
                shape.Location = new Point(baseLocation.X + shape.Location.X, baseLocation.Y + shape.Location.Y);
            }

            numberLabel.Location = labelBaseLocation;
            numberLabel.Location = new Point(baseLocation.X + numberLabel.Location.X, baseLocation.Y + numberLabel.Location.Y);
            form.Invalidate(); // 画面を再描画
        }

        /// <summary>
        /// 指定された表示モードに応じて図形と数字の表示を切り替えます。
        /// </summary>
        /// <param name="mode">表示モードを指定するDisplayMode列挙型です。</param>
        /// <param name="str">表示する数字です。</param>
        public void SetDisplay(DisplayMode mode, int number)
        {
            shapeDrawer.ClearShapes(); // 現在の図形をすべてクリア
            numberLabel.Visible = false; // ラベルを非表示に設定
            var str = number.ToString();
            switch (mode)
            {
                case DisplayMode.A:
                    shapeDrawer.AddShape(new Triangle(new Point(35, -70), new Size(50, 30), false, TriangleDirection.Down)); //上部矢印
                    shapeDrawer.AddShape(new Triangle(new Point(35, 220), new Size(50, 30), false, TriangleDirection.Up)); //下部矢印
                    shapeDrawer.AddShape(new CatHut.Rectangle(new Point(0, 0), new Size(120, 200), false));
                    numberLabel.Text = str;
                    numberLabel.Visible = true;
                    break;
                case DisplayMode.B:
                    shapeDrawer.AddShape(new CatHut.Rectangle(new Point(0, 0), new Size(50, 100), false));
                    numberLabel.Text = str;
                    numberLabel.Visible = true;
                    break;
                case DisplayMode.C:
                    shapeDrawer.AddShape(new CatHut.Rectangle(new Point(0, 0), new Size(50, 100), false));
                    break;
                case DisplayMode.D:
                    numberLabel.Text = str;
                    numberLabel.Visible = true;
                    break;
                case DisplayMode.E:
                    //何もしない
                    break;
            }

            UpdateChildControls(); // 子要素の位置を更新
        }

        /// <summary>
        /// 図形を追加します。
        /// </summary>
        /// <param name="shape">追加する図形。</param>
        public void AddShape(Shape shape)
        {
            shapeDrawer.AddShape(shape);
        }

        public void Draw(Graphics g)
        {
            shapeDrawer.Draw(g);
        }

    }
}
