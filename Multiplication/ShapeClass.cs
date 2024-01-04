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
    /// 図形の向きを表す列挙型です。
    /// </summary>
    public enum TriangleDirection
    {
        /// <summary>上向きの三角形。</summary>
        Up,
        /// <summary>下向きの三角形。</summary>
        Down
    }

    /// <summary>
    /// 三角形を表すクラスで、Shapeから派生しています。
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>三角形の向きを取得または設定します。</summary>
        public TriangleDirection Direction { get; set; }

        /// <summary>
        /// Triangleクラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="location">三角形の位置を指定するPoint。</param>
        /// <param name="size">三角形のサイズを指定するSize。</param>
        /// <param name="isFilled">三角形が塗りつぶされるかどうかを指定します。</param>
        /// <param name="direction">三角形の向きを指定するTriangleDirection。</param>
        public Triangle(Point location, Size size, bool isFilled, TriangleDirection direction)
            : base(location, size, isFilled, true)
        {
            Direction = direction;
        }

        /// <summary>
        /// 三角形を描画します。
        /// </summary>
        /// <param name="g">描画に使用するGraphicsオブジェクト。</param>
        public override void Draw(Graphics g)
        {
            if (!IsVisible) return;

            // 三角形の頂点を計算
            Point[] points = Direction == TriangleDirection.Up
                ? new Point[] {
                new Point(Location.X + Size.Width / 2, Location.Y),
                new Point(Location.X, Location.Y + Size.Height),
                new Point(Location.X + Size.Width, Location.Y + Size.Height)
                }
                : new Point[] {
                new Point(Location.X, Location.Y),
                new Point(Location.X + Size.Width, Location.Y),
                new Point(Location.X + Size.Width / 2, Location.Y + Size.Height)
                };

            // 三角形の描画
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
