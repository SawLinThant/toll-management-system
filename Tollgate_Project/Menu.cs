using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tollgate_Project
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_amountsetting_Click(object sender, EventArgs e)
        {

            Adminpassword ast = new Adminpassword();
            ast.Show();
            this.Hide();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            Setting setting=new Setting();
            setting.Show();
            this.Hide();
        }

        private void btn_record_Click(object sender, EventArgs e)
        {
            //Record record=new Record();
            SearchCar record=new SearchCar();
            record.Show(); this.Hide();
        }

        private void btn_operation_Click(object sender, EventArgs e)
        {
            Operation operation=new Operation();
            operation.Show(); this.Hide();
        }
    }
}
