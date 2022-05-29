using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageSlideAnimation
{
    public class ComponentImage
    {
        public bool IsInit
        {
            get; private set;
        } = false;

        public bool IsFirstPage
        {
            get { return IndexStandby == 0 ? true : false; }
        }

        public bool IsLastPage
        {
            get { return IndexStandby == fileList.Length - 1 ? true : false; }
        }

        public Image[] Images;
        private string[] fileList;

        private int IndexStandby = 0;

        public ComponentImage()
        {
            Images = new Image[3];
        }

        ~ComponentImage()
        {
            Images = null;

            fileList = null;
        }

        public void SelectFolder()
        {
            using (FolderBrowserDialog FBD = new FolderBrowserDialog())
            {
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(FBD.SelectedPath);

                    FileInfo[] fileInfos = directoryInfo.GetFiles();

                    fileList = new string[fileInfos.Length];

                    int Index = 0;
                    foreach (FileInfo File in fileInfos)
                    {
                        fileList[Index++] = File.FullName;
                    }

                    IndexStandby = 0;

                    if (fileList != null && fileList.Length >= 1)
                    {
                        IsInit = true;
                    }

                    ViewImage();
                }
            }
        }

        public void ViewImage()
        {
            if (IsInit)
            {
                if (IsFirstPage)
                {
                    //첫 페이지
                    Images[0] = null;
                    Images[1] = Image.FromFile(fileList[IndexStandby]);
                    Images[2] = Image.FromFile(fileList[IndexStandby + 1]);
                }
                else if (IsLastPage)
                {
                    //마지막 페이지
                    Images[0] = Image.FromFile(fileList[IndexStandby - 1]);
                    Images[1] = Image.FromFile(fileList[IndexStandby]);
                    Images[2] = null;
                }
                else
                {
                    //중간 페이지
                    Images[0] = Image.FromFile(fileList[IndexStandby - 1]);
                    Images[1] = Image.FromFile(fileList[IndexStandby]);
                    Images[2] = Image.FromFile(fileList[IndexStandby + 1]);
                }
            }
        }

        public void BeforePage()
        {
            if (IndexStandby >= 1)
            {
                IndexStandby -= 1;
            }
        }

        public void NextPage()
        {
            if (IndexStandby < fileList.Length - 1)
            {
                IndexStandby += 1;
            }
        }

    }
}
