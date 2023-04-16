using System.Windows;
using Panuon.WPF.UI;

namespace EzNetDisk.Login
{
    public partial class Login : WindowX
    {
        #region Fields
        private bool _isProcessing;
        #endregion

        #region Ctor
        public Login()
        {
            InitializeComponent();
            ValidatePassword();
        }
        #endregion

        #region Event Handlers

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_isProcessing)
            {
                return;
            }

            if (!ValidatePassword())
            {
                return;
            }

            _isProcessing = true;
            ButtonHelper.SetIsPending(BtnLogin, true);
            FrmPassword.ValidateResult = ValidateResult.None;
            FrmPassword.Message = null;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidatePassword();
        }
        #endregion

        #region Functions

        private bool ValidatePassword()
        {
            if (PwdPassword.Password == null || PwdPassword.Password == "")
            {
                FrmPassword.ValidateResult = ValidateResult.Info;
                FrmPassword.Message = "请输入密码";
                return false;
            } else if (PwdPassword.Password.Length < 8)
            {
                FrmPassword.ValidateResult = ValidateResult.Error;
                FrmPassword.Message = "密码长度必须高于8位数";
                return false;
            } else if (PwdPassword.Password == "12345678")
            {
                FrmPassword.ValidateResult = ValidateResult.Warning;
                FrmPassword.Message = "密码不能为12345678";
                return false;
            } else
            {
                FrmPassword.ValidateResult = ValidateResult.Success;
                FrmPassword.Message = "OK";
                return true;
            }
        }
        #endregion
    }
}