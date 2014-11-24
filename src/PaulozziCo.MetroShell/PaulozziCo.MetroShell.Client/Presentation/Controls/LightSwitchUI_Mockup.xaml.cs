using System;
using System.Windows;
using System.Windows.Controls;
using PaulozziCo.MetroShell.Model;

namespace PaulozziCo.MetroShell.Presentation.Controls
{
	public partial class LightSwitchUI_Mockup : UserControl
	{
		public LightSwitchUI_Mockup()
		{
			InitializeComponent();
            this.DataContext = this;
		}
	}
}