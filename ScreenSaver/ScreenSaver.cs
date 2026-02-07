using ScreenSaver.Properties;

namespace ScreenSaver
{
    public partial class ScreenSaver : Form
    {
        private Bitmap backgroundImg;
        private Bitmap snowflakeImg;

        public ScreenSaver()
        {
            InitializeComponent();
            backgroundImg = Resources.BackgroundImg;
            snowflakeImg = Resources.SnowflakeImg;
        }

        private void ScreenSaver_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(backgroundImg, ClientRectangle);
            e.Graphics.DrawImage(snowflakeImg, 10, 10);
        }
    }
}
