using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading;
using SEM.Desktop.Models;

namespace SEM.Desktop
{
    public partial class AuthorizationForm : Form
    {
        private static User user { get; set; }
        private static ResponseToken token { get; set; }

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool isLoggedIn = false;
            using var client = new HttpClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var userToLogin = GetUserData();

            var loginResult = await LoginUser(userToLogin, client);

            if (loginResult.IsSuccessStatusCode)
            {
                isLoggedIn = true;
                token = loginResult.Content.ReadAsAsync<ResponseToken>().Result;
            }
            else
            {
                errorLb.Visible = true;
                errorLb.Text = @"Error: " + loginResult.Content.ReadAsStringAsync().Result + @". Try again.";
            }

            if (!isLoggedIn) return;

            var userId = token.UserId;

            var userResult = await client.GetAsync(Constants.API_URL + "users/" + userId);

            user = userResult.Content.ReadAsAsync<User>().Result;

            this.Hide();
            var mainForm = new MainForm(user);
            mainForm.Closed += (_, _) => this.Close();
            mainForm.Show();
        }

        private static async Task<HttpResponseMessage> LoginUser(LoginUser userToLogin, HttpClient client)
        {
            var json = JsonConvert.SerializeObject(userToLogin);
            var userData = new StringContent(json, Encoding.UTF8, "application/json");

            var loginResult = await client.PostAsync(Constants.API_URL + "account/login", userData);
            return loginResult;
        }

        public LoginUser GetUserData()
        {
            var email = loginTb.Text;
            var password = passwordTb.Text;

            var userToLogin = new LoginUser
            {
                Email = email,
                Password = password
            };
            return userToLogin;
        }
    }
}
