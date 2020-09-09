using Programatica.Framework.Data.Models;
using Programatica.Framework.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsDotNetCore
{
    public partial class Form2 : Form
    {
        private readonly IRepository<Audit> _auditRepository;
        private readonly IServiceProvider _services;

        public Form2(IRepository<Audit> auditRepository, IServiceProvider services)
        {
            _auditRepository = auditRepository;
            _services = services;

            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_auditRepository.GetData().Count().ToString());
        }
    }
}
