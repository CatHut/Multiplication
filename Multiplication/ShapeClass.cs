using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatHut
{
    /// <summary>
    /// 図形の基底クラス。共通のプロパティとメソッドを定義します。
    /// </summary>
    public abstract class Shape
    {
        /// <summary>図形の位置</summary>
        public Point Location { get; set; }

        /// <summary>図形のサイズ</summary>
        public Size Size { get; set; }

        /// <summary>図形が塗りつぶされるかどうか</summary>
        public bool IsFilled { get; set; }

        /// <summary>図形が描画されるかどうか</summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// 図形の基本情報を初期化します。
        /// </summary>
        /// <param name="location">図形の位置</param>
        /// <param name="size">図形のサイズ</param>
        /// <param name="isFilled">図形が塗りつぶされるかどうか</param>
        /// <param name="isVisible">図形が描画されるかどうか</param>
        protected Shape(Point location, Size size, bool isFilled, bool isVisible)
        {
            Location = location;
            Size = size;
            IsFilled = isFilled;
            IsVisible = isVisible;
        }

        /// <summary>
        /// 図形を描画します。
        /// </summary>
        /// <param name="g">描画に使用するGraphicsオブジェクト</param>
        public abstract void Draw(Graphics g);
    }


    /// <summary>
    /// 三角形を表すクラス。
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// 三角形のインスタンスを初期化します。
        /// </summary>
        /// <param name="location">三角形の位置</param>
        /// <param name="size">三角形のサイズ</param>
        /// <param name="isFilled">三角形が塗りつぶされるかどうか</param>
        public Triangle(Point location, Size size, bool isFilled)
            : base(location, size, isFilled, true) { }

        /// <summary>
        /// 三角形を描画します。
        /// </summary>
        /// <param name="g">描画に使用するGraphicsオブジェクト</param>
        public override void Draw(Graphics g)
        {
            if (!IsVisible) return;

            Point[] points = new Point[3];
            points[0] = new Point(Location.X + Size.Width / 2, Location.Y);
            points[1] = new Point(Location.X, Location.Y + Size.Height);
            points[2] = new Point(Location.X + Size.Width, Location.Y + Size.Height);

            if (IsFilled)
                g.FillPolygon(Brushes.Black, points);
            else
                g.DrawPolygon(Pens.Black, points);
        }
    }


    /// <summary>
    /// 長方形を表すクラス。
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// 長方形のインスタンスを初期化します。
        /// </summary>
        /// <param name="location">長方形の位置</param>
        /// <param name="size">長方形のサイズ</param>
        /// <param name="isFilled">長方形が塗りつぶされるかどうか</param>
        public Rectangle(Point location, Size size, bool isFilled)
            : base(location, size, isFilled, true) { }

        /// <summary>
        /// 長方形を描画します。
        /// </summary>
        /// <param name="g">描画に使用するGraphicsオブジェクト</param>
        public override void Draw(Graphics g)
        {
            if (!IsVisible) return;

            if (IsFilled)
                g.FillRectangle(Brushes.Black, new System.Drawing.Rectangle(Location, Size));
            else
                g.DrawRectangle(Pens.Black, new System.Drawing.Rectangle(Location, Size));
        }
    }


}
