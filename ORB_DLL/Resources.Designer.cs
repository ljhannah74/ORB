using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ORB_DLL.My.Resources
{
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
	[HideModuleName]
	internal static class Resources
	{
		private static System.Resources.ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return ORB_DLL.My.Resources.Resources.resourceCulture;
			}
			set
			{
				ORB_DLL.My.Resources.Resources.resourceCulture = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static System.Resources.ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(ORB_DLL.My.Resources.Resources.resourceMan, null))
				{
					ORB_DLL.My.Resources.Resources.resourceMan = new System.Resources.ResourceManager("ORB_DLL.Resources", typeof(ORB_DLL.My.Resources.Resources).Assembly);
				}
				return ORB_DLL.My.Resources.Resources.resourceMan;
			}
		}
	}
}