using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Windows.Forms;

namespace ProyectoDarioMayenVC20
{
    public class BaseForm : Form
    {
        // Constructor vacío (soluciona el posible error)
        public BaseForm()
        {
        }

        protected void OpenWindow(Type windowType)
        {
            if (this.GetType() != windowType)
            {
                Form newWindow = (Form)Activator.CreateInstance(windowType);
                newWindow.Show();
                this.Hide();
            }
        }

        protected void ConfigureMenuStrip(MenuStrip menuStrip)
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                string formName = item.Text;
                Type formType = Type.GetType($"ProyectoDarioMayenVC20.{formName}, ProyectoDarioMayenVC20");


                if (formType != null && formType != this.GetType())
                {
                    item.Click += (sender, e) => OpenWindow(formType);
                }
                else
                {
                    item.Enabled = false;
                }
            }
        }
    }
}
