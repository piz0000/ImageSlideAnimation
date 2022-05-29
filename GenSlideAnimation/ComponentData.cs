using System;
using System.Drawing;

namespace ImageSlideAnimation
{
    public class ComponentData : ComponentImage
    {
        private int _MouseClickX;
        private int _MouseMoveX;
        private int _MouseMoveWidth;

        public Size GroundSize { get; set; }
        public Size ZoomSize { get; set; }
        public int StartX { get; set; }

        public int MouseClickX
        {
            get { return _MouseClickX; }
            set
            {
                _MouseClickX = value;
                MouseMoveWidth = value - MouseMoveX;
            }
        }
        public int MouseMoveX
        {
            get { return _MouseMoveX; }
            set
            {
                _MouseMoveX = value;
                MouseMoveWidth = MouseClickX - value;
            }
        }
        public int MouseMoveWidth
        {
            get { return _MouseMoveWidth; }
            set
            {
                _MouseMoveWidth = value;
                MouseMoveWidthABS = Math.Abs(value);
            }
        }
        public int MouseMoveWidthABS
        {
            get; set;
        }

        public int AnimationStandBar { get; set; }
        public Brush AnimationStandBarColor { get; set; }
        public Rectangle AnimationRectangle { get; set; }

        public ComponentData()
        {
            AnimationStandBar = 15;
            AnimationStandBarColor = Brushes.White;
        }

        ~ComponentData()
        {
            AnimationStandBarColor.Dispose();
        }

        public void DrawSize()
        {
            DrawZoomSize();

            DrawStartX();
        }

        private void DrawZoomSize()
        {
            int diffWidth = GroundSize.Width - Images[1].Width;
            int diffHeight = GroundSize.Height - Images[1].Height;

            //가로가 크면 세로 차이값, 세로가 크면 가로 차이값 사용
            int diffValue = diffWidth > diffHeight ? diffHeight : diffWidth;

            //차이값만큼 이미지 늘림
            ZoomSize = new Size(Images[1].Width + diffValue, Images[1].Height + diffValue);
        }

        private void DrawStartX()
        {
            if (ZoomSize.Width > GroundSize.Width)
            {
                StartX = 0;
            }

            StartX = (GroundSize.Width / 2) - (ZoomSize.Width / 2);
        }

        public void MousePointClear()
        {
            MouseClickX = 0;

            MouseMoveX = 0;
        }
    }
}
