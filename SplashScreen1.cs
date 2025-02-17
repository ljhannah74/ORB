using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
	public partial class SplashScreen1 : Form
	{
		public SplashScreen1()
		{
			InitializeComponent();
		}

		private void SplashScreen1_Load(object sender, EventArgs e) 
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			this.ApplicationTitle.Text = assembly.GetName().ToString();
			this.Version.Text = assembly.GetName().Version.ToString();
			AssemblyCopyrightAttribute copyrightAttribute = AssemblyCopyrightAttribute.GetCustomAttribute(assembly, typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute;
			this.Copyright.Text = copyrightAttribute.Copyright.ToString();
			this.SendToBack();
		}
	}
}
