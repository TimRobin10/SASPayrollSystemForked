using ServicesLayer;
using ServicesLayer.Exceptions;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PresentationLayer.Views
{
    public partial class Login_Form : Form
    {
        private IServicesMesh _servicesManager;

        private System.Windows.Forms.Timer timer;
        private int targetX;
        private int speed = 15;
        private bool isSignIn = true;

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

            //Initializing Transtiion Timer
            timer = new System.Windows.Forms.Timer(); // Use Windows Forms Timer
            timer.Interval = 10; // Controls animation speed
            timer.Tick += Timer_Tick;

            //For Runding Form COrners
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            _initCloseBtnProperties();
            _initForgotPassBtnProperties();
            _initSignInButtonProperties();
            _initSignUpButtonProperties();

            //Sets default values on initial runtime instance
            _servicesManager.InitialSeeding();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (bgPanelMotion.Left < targetX)
            {
                bgPanelMotion.Left += speed;
                if (bgPanelMotion.Left >= targetX) // Stop at target position
                {
                    bgPanelMotion.Left = targetX;
                    timer.Stop();
                }
            }
            else if (bgPanelMotion.Left > targetX)
            {
                bgPanelMotion.Left -= speed;
                if (bgPanelMotion.Left <= targetX) // Stop at target position
                {
                    bgPanelMotion.Left = targetX;
                    timer.Stop();
                }
            }
        }

        public async void _initCloseBtnProperties()
        {
            //Init Close Form button 1
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

            // Init Close Form button 2
            btnCloseForm2.Style.Border = new Pen(Color.FromArgb(242, 242, 242));
            btnCloseForm2.Style.BackColor = Color.FromArgb(242, 242, 242);
            btnCloseForm2.Style.ForeColor = Color.FromArgb(51, 51, 51);

            btnCloseForm2.Style.FocusedBorder = new Pen(Color.FromArgb(242, 242, 242));
            btnCloseForm2.Style.FocusedBackColor = Color.FromArgb(242, 242, 242);
            btnCloseForm2.Style.FocusedForeColor = Color.FromArgb(51, 51, 51);

            btnCloseForm2.Style.HoverBorder = new Pen(Color.FromArgb(200, 0, 0));
            btnCloseForm2.Style.HoverBackColor = Color.FromArgb(200, 0, 0);
            btnCloseForm2.Style.HoverForeColor = Color.FromArgb(255, 255, 255);

            btnCloseForm2.Style.PressedBorder = new Pen(Color.FromArgb(180, 0, 0));
            btnCloseForm2.Style.PressedBackColor = Color.FromArgb(180, 0, 0);
            btnCloseForm2.Style.PressedForeColor = Color.FromArgb(255, 255, 255);

            btnCloseForm2.Invalidate();
        }

        public async void _initForgotPassBtnProperties()
        {
            //Init forgot Pass Properties
            btnForgotPass.Style.Border = new Pen(Color.FromArgb(242, 242, 242));
            btnForgotPass.Style.BackColor = Color.FromArgb(242, 242, 242);
            btnForgotPass.Style.ForeColor = Color.FromArgb(51, 51, 51);

            btnForgotPass.Style.FocusedBorder = new Pen(Color.FromArgb(242, 242, 242));
            btnForgotPass.Style.FocusedBackColor = Color.FromArgb(242, 242, 242);
            btnForgotPass.Style.FocusedForeColor = Color.FromArgb(51, 51, 51);

            btnForgotPass.Style.HoverBorder = new Pen(Color.FromArgb(242, 242, 242));
            btnForgotPass.Style.HoverBackColor = Color.FromArgb(242, 242, 242);
            btnForgotPass.Style.HoverForeColor = Color.FromArgb(255, 170, 0);

            btnForgotPass.Style.PressedBorder = new Pen(Color.FromArgb(242, 242, 242));
            btnForgotPass.Style.PressedBackColor = Color.FromArgb(242, 242, 242);
            btnForgotPass.Style.PressedForeColor = Color.FromArgb(255, 147, 0);

            btnForgotPass.Invalidate();
        }

        public async void _initSignInButtonProperties()
        {
            btnSignIn.Style.FocusedBackColor = Color.FromArgb(0, 122, 225);
            btnSignIn.Style.FocusedBorder = new Pen(Color.FromArgb(0, 122, 225));
            btnSignIn.Style.FocusedForeColor = Color.White;

            btnSignIn.Style.HoverBorder = new Pen(Color.FromArgb(242, 242, 242));

            RoundedElements.rounded(btnSignIn, 10);
        }

        public async void _initSignUpButtonProperties()
        {
            btnSignUpOption.Style.FocusedBackColor = Color.FromArgb(0, 122, 225);
            btnSignUpOption.Style.FocusedBorder = new Pen(Color.FromArgb(0, 122, 225));
            btnSignUpOption.Style.FocusedForeColor = Color.White;

            btnSignUpOption.Style.HoverBorder = new Pen(Color.FromArgb(242, 242, 242));

            RoundedElements.rounded(btnSignUpOption, 10);
            btnSignUpOption.Invalidate();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Async Login Example
        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                await _servicesManager.LoginUser(txtBoxUsername.Text, textBoxExt1.Text);
                MessageBox.Show("Success!");
            }

            catch (UserNotFoundException)
            {
                MessageBox.Show("User does not exist!");
            }
            catch (IncorrectPasswordException)
            {
                MessageBox.Show("Wrong password!");
            }
        }

        private async void btnSignUp_ClickAsync(object sender, EventArgs e)
        {
            if (isSignIn)
            {
                targetX = 400;
                btnSignUpOption.Text = "Sign In";
                lblSignInTitle.Text = "Already have an Account?";
                lblSignInDescription.Text = "Welcome back! We’re glad to see you again. " +
                    "Sign in to your account and continue your journey with us. " +
                    "We can’t wait to see what you’ll do next!";
                isSignIn = false;

            }
            else
            {
                targetX = 0;
                btnSignUpOption.Text = "Sign Up";
                lblSignInTitle.Text = "No Account Yet??";
                lblSignInDescription.Text = "If you don’t have an account yet, " +
                    "sign up today and become a valued member of our ever-growing " +
                    "Strategic Assistant Family! Join us and take the first step " +
                    "toward a smarter, more efficient future.";
                isSignIn = true;
            }
            timer.Start();
        }

        private void btnCloseForm2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
