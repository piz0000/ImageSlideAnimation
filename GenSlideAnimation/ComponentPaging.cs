using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace ImageSlideAnimation
{
    public class ComponentPaging : ComponentData
    {
        public PictureBox DrawBox;
        private bool IsHover = false;
        private bool IsLeave = true;

        public event EventHandler AutoComplete;
        private bool IsAuto = false;
        private bool IsAutoThreadAlive = false;

        private ManualResetEvent MRE = null;

        public ComponentPaging()
        {
            MRE = new ManualResetEvent(true);

            DrawBox = new PictureBox();
            DrawBox.Dock = DockStyle.Fill;

            GroundSize = DrawBox.Size;

            DrawBox_EventAdd();
        }

        ~ComponentPaging()
        {
            DrawBox.Dispose();
        }

        #region base Method 
        public new void SelectFolder()
        {
            base.SelectFolder();

            ViewImage();
        }

        public new void ViewImage()
        {
            base.ViewImage();

            UpdateImage();

            MousePointClear();
        }

        public new void BeforePage()
        {
            base.BeforePage();

            ViewImage();
        }

        public new void NextPage()
        {
            base.NextPage();

            ViewImage();
        }
        #endregion

        #region DrawBox Event
        private void DrawBox_EventAdd()
        {
            DrawBox.MouseHover += DrawBox_MouseHover;
            DrawBox.MouseLeave += DrawBox_MouseLeave;
            DrawBox.MouseUp += DrawBox_MouseUp;
            DrawBox.MouseDown += DrawBox_MouseDown;
            DrawBox.MouseMove += DrawBox_MouseMove;
            DrawBox.SizeChanged += DrawBox_SizeChanged;
        }

        private void DrawBox_EventRemove()
        {
            DrawBox.MouseHover -= DrawBox_MouseHover;
            DrawBox.MouseLeave -= DrawBox_MouseLeave;
            DrawBox.MouseUp -= DrawBox_MouseUp;
            DrawBox.MouseDown -= DrawBox_MouseDown;
            DrawBox.MouseMove -= DrawBox_MouseMove;
            DrawBox.SizeChanged -= DrawBox_SizeChanged;
        }

        private void DrawBox_MouseHover(object sender, EventArgs e)
        {
            IsHover = true;

            IsLeave = false;
        }

        private void DrawBox_MouseLeave(object sender, EventArgs e)
        {
            IsHover = false;

            IsLeave = true;
        }

        private void DrawBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsInit == false || e.Button != MouseButtons.Left)
            {
                return;
            }

            if (e.X == MouseClickX)
            {
                if (DrawBox.Width / 2 > e.X)
                {
                    BeforePage();
                }
                else
                {
                    NextPage();
                }
            }
            else if (e.X <= MouseClickX)
            {
                NextPage();
            }
            else if (e.X > MouseClickX)
            {
                BeforePage();
            }
        }

        private void DrawBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseClickX = e.X;
            }
        }

        private void DrawBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > MouseClickX + 3 || e.X < MouseClickX - 3)
            {
                if (e.Button == MouseButtons.Left && IsHover && IsLeave == false && IsInit)
                {
                    MouseMoveX = e.X;

                    UpdateImage(true);
                }
            }
        }

        private void DrawBox_SizeChanged(object sender, EventArgs e)
        {
            GroundSize = DrawBox.Size;

            UpdateImage(false);
        }
        #endregion

        #region Auto
        public void AutoStart(int Interval = 1)
        {
            IsAuto = true;

            if (IsAutoThreadAlive == false)
            {
                IsAutoThreadAlive = true;

                System.Threading.Tasks.Task.Factory.StartNew(() => AutoUpdateImage(Interval * 1000));
            }

            DrawBox_EventRemove();
        }

        public void AutoStop()
        {
            IsAuto = false;

            DrawBox_EventAdd();
        }

        private void AutoUpdateImage(int Interval)
        {
            int BackupAnimatrionBar = AnimationStandBar;
            AnimationStandBar = 0;

            while (IsAuto)
            {
                DrawSize();

                if (StartX == 0)
                {
                    MouseClickX = GroundSize.Width;
                }
                else
                {
                    MouseClickX = StartX + ZoomSize.Width;
                }
                MouseMoveX = MouseClickX;

                while (true)
                {
                    MouseMoveX -= 3;

                    DrawBox.Invoke((MethodInvoker)delegate
                    {
                        UpdateImage(true);
                    });

                    if (MouseMoveX <= StartX)
                    {
                        MousePointClear();

                        break;
                    }
                }

                DrawBox.Invoke((MethodInvoker)delegate
                {
                    NextPage();
                });

                if (IsLastPage)
                {
                    IsAuto = false;

                    AutoComplete?.Invoke(null, EventArgs.Empty);
                }

                Thread.Sleep(Interval);
            }

            AnimationStandBar = BackupAnimatrionBar;

            AutoComplete?.Invoke(null, EventArgs.Empty);

            IsAutoThreadAlive = false;
        }
        #endregion

        #region Helper
        private void UpdateImage(bool IsNextPageAnimation = false)
        {
            if (IsInit == false)
            {
                return;
            }

            if (MRE.WaitOne(0))
            {
                MRE.Reset();

                using (BufferedGraphics bufferedgraphic = BufferedGraphicsManager.Current.Allocate(DrawBox.CreateGraphics(), new Rectangle(0, 0, DrawBox.Width, DrawBox.Height)))
                {
                    bufferedgraphic.Graphics.InterpolationMode = InterpolationMode.Low;
                    bufferedgraphic.Graphics.SmoothingMode = SmoothingMode.None;
                    bufferedgraphic.Graphics.Clear(DrawBox.BackColor);

                    DrawSize();

                    if (IsNextPageAnimation == false)
                    {
                        //before image View
                        bufferedgraphic.Graphics.DrawImage(Images[1], StartX, 0, ZoomSize.Width, ZoomSize.Height);
                    }
                    else
                    {
                        if (MouseMoveWidth > 0)
                        {
                            //Right Image Animation

                            #region 현재 올려진 이미지 끝부터 애니메이션 시작
                            //before image
                            bufferedgraphic.Graphics.DrawImage(Images[1], StartX, 0, ZoomSize.Width - MouseMoveWidthABS, ZoomSize.Height);

                            if (IsLastPage == false)
                            {
                                if (AnimationStandBar >= 1)
                                {
                                    //애니메이션 중간 3픽셀 bar
                                    bufferedgraphic.Graphics.FillRectangle(AnimationStandBarColor, StartX + ZoomSize.Width - MouseMoveWidthABS, 0, AnimationStandBar, ZoomSize.Height);
                                }

                                //next image
                                bufferedgraphic.Graphics.DrawImage(Images[2], StartX + ZoomSize.Width - MouseMoveWidthABS + AnimationStandBar, 0, MouseMoveWidthABS, ZoomSize.Height);
                            }
                            #endregion

                            #region 마우스 시작 위치부터 애니메이션 시작
                            ////before image
                            //bufferedgraphic.Graphics.DrawImage(Images[0], drawX, 0, desSize.Width - moveWidth, desSize.Height);

                            ////애니메이션 중간 3픽셀 bar
                            //bufferedgraphic.Graphics.FillRectangle(Brushes.Black, desSize.Width - moveWidth, 0, 3, desSize.Height);

                            ////next image
                            //bufferedgraphic.Graphics.DrawImage(Images[1], (desSize.Width - moveWidth) + 3, 0, moveWidth - 3, desSize.Height);
                            #endregion
                        }
                        else
                        {
                            //Left Image Animation

                            if (IsFirstPage == false)
                            {
                                #region 현재 올려진 이미지 끝부터 애니메이션 시작
                                //before image
                                bufferedgraphic.Graphics.DrawImage(Images[0], StartX, 0, MouseMoveWidthABS, ZoomSize.Height);

                                if (AnimationStandBar >= 1)
                                {
                                    //애니메이션 중간 3픽셀 bar
                                    bufferedgraphic.Graphics.FillRectangle(AnimationStandBarColor, StartX + MouseMoveWidthABS, 0, AnimationStandBar, ZoomSize.Height);
                                }

                                //Stand image
                                bufferedgraphic.Graphics.DrawImage(Images[1], StartX + MouseMoveWidthABS + AnimationStandBar, 0, ZoomSize.Width - MouseMoveWidthABS - AnimationStandBar, ZoomSize.Height);
                                #endregion

                                #region 마우스 시작 위치부터 애니메이션 시작
                                ////before image
                                //bufferedgraphic.Graphics.DrawImage(Images[0], drawX, 0, desSize.Width - moveWidth, desSize.Height);

                                ////애니메이션 중간 3픽셀 bar
                                //bufferedgraphic.Graphics.FillRectangle(Brushes.Black, desSize.Width - moveWidth, 0, 3, desSize.Height);

                                ////next image
                                //bufferedgraphic.Graphics.DrawImage(Images[1], (desSize.Width - moveWidth) + 3, 0, moveWidth - 3, desSize.Height);
                                #endregion
                            }
                            else
                            {
                                //Stand image
                                bufferedgraphic.Graphics.DrawImage(Images[1], StartX + MouseMoveWidthABS + AnimationStandBar, 0, ZoomSize.Width - MouseMoveWidthABS - AnimationStandBar, ZoomSize.Height);
                            }
                        }
                    }

                    bufferedgraphic.Render();
                }

                MRE.Set();
            }
        }
        #endregion
    }
}
