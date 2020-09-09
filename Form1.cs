using Microsoft.Extensions.DependencyInjection;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsDotNetCore.Models;

namespace WindowsFormsDotNetCore
{
    public partial class Form1 : Form
    {
        private readonly IRepository<User> _userRepository;
        private readonly IService<User> _userService;
        private readonly IServiceProvider _services;

        public Form1(
            IRepository<User> userRepository, 
            IServiceProvider services, 
            IService<User> userService)
        {

            _userRepository = userRepository;
            _userService = userService;
            _services = services;

            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

            var u = _userService.Create(new User { Username = "Teste", Email = "email", Password = "pass" });

            var user = _userService.Inspect(1);
            MessageBox.Show(user.Username);
            var form2 = _services.GetRequiredService<Form2>();
            form2.ShowDialog(this);
        }
    }
}
