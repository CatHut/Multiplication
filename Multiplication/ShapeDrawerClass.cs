using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatHut
{
    /// <summary>
    /// 図形を描画するためのクラスです。
    /// </summary>
    public class ShapeDrawerClass
    {
        private List<Shape> shapes = new List<Shape>();

        /// <summary>
        /// 描画する図形を追加します。
        /// </summary>
        /// <param name="shape">描画する図形のオブジェクト。</param>
        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }

        /// <summary>
        /// すべての図形をクリアします。
        /// </summary>
        public void ClearShapes()
        {
            shapes.Clear();
        }

        /// <summary>
        /// 登録されているすべての図形を描画します。
        /// </summary>
        /// <param name="g">描画に使用するGraphicsオブジェクト。</param>
        public void Draw(Graphics g)
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw(g);
            }
        }

        /// <summary>
        /// 登録されている図形のリストを取得します。
        /// </summary>
        public List<Shape> Shapes => shapes;
    }
}
