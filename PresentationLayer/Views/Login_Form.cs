using ServicesLayer;
using System.Runtime.InteropServices;

namespace PresentationLayer.Views
{
    public partial class Login_Form : Form
    {
        private IServicesMesh _servicesManager;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Login_Form(IServicesMesh servicesManager)
        {
            _servicesManager = servicesManager;
            InitializeComponent();

            //For Runding Form COrners
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            _initCloseBtnProperties();
            _initForgotPassBtnProperties();
            _initSignInButtonProperties();
        }

        public void _initCloseBtnProperties()
        {
            //Init Close Form button
            btnCloseForm.Style.Border = new Pen(Color.FromArgb(242, 242, 242));
            btnCloseForm.Style.BackColor = Color.FromArgb(242, 242, 242);
            btnCloseForm.Style.ForeColor = Color.FromArgb(51, 51, 51);

            btnCloseForm.Style.FocusedBorder = new Pen(Color.FromArgb(242, 242, 242));
            btnCloseForm.Style.FocusedBackColor = Color.FromArgb(242, 242, 242);
            btnCloseForm.Style.FocusedForeColor = Color.FromArgb(51, 51, 51);

            btnCloseForm.Style.HoverBorder = new Pen(Color.FromArgb(200, 0, 0));
            btnCloseForm.Style.HoverBackColor = Color.FromArgb(200, 0, 0);
            btnCloseForm.Style.HoverForeColor = Color.FromArgb(255, 255, 255);

            btnCloseForm.Style.PressedBorder = new Pen(Color.FromArgb(180, 0, 0));
            btnCloseForm.Style.PressedBackColor = Color.FromArgb(180, 0, 0);
            btnCloseForm.Style.PressedForeColor = Color.FromArgb(255, 255, 255);

            btnCloseForm.Invalidate();
        }

        public void _initForgotPassBtnProperties()
        {
            //Init forgot Pass Properties
            btnForgotPass.Style.Border = new Pen(Color.FromArgb(242, 242, 242));
            btnForgotPass.Style.BackColor = Color.FromArgb(242, 242, 242);
            btnForgotPass.Style.ForeColor = Color.FromArgb(51, 51, 51);

            btnForgotPass.Style.FocusedBorder = new Pen(Color.FromArgb(242, 242, 242));
            btnForgotPass.Style.FocusedBackColor = Color.FromArgb(242, 242, 242);
            btnForgotPass.Style.FocusedForeColor = Color.FromArgb(51,51,51);

            btnForgotPass.Style.HoverBorder = new Pen(Color.FromArgb(242, 242, 242));
            btnForgotPass.Style.HoverBackColor = Color.FromArgb(242, 242, 242);
            btnForgotPass.Style.HoverForeColor = Color.FromArgb(255, 170, 0);

            btnForgotPass.Style.PressedBorder = new Pen(Color.FromArgb(242, 242, 242));
            btnForgotPass.Style.PressedBackColor = Color.FromArgb(242, 242, 242);
            btnForgotPass.Style.PressedForeColor = Color.FromArgb(255, 147, 0);

            btnForgotPass.Invalidate();
        }

        public void _initSignInButtonProperties()
        {
            btnSignIn.Style.FocusedBackColor = Color.FromArgb(0, 122, 225);
            btnSignIn.Style.FocusedBorder = new Pen(Color.FromArgb(0,122,225));
            btnSignIn.Style.FocusedForeColor = Color.White;

            btnSignIn.Style.HoverBorder = new Pen(Color.FromArgb(242,242,242));

            RoundedElements.rounded(btnSignIn, 10);
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
