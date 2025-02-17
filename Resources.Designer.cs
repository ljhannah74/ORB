using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace WindowsApplication1
{
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
	[HideModuleName]
	internal static class Resources
	{
		private static System.Resources.ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		internal static Bitmap clipboard
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(WindowsApplication1.Resources.ResourceManager.GetObject("clipboard", WindowsApplication1.Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return WindowsApplication1.Resources.resourceCulture;
			}
			set
			{
				WindowsApplication1.Resources.resourceCulture = value;
			}
		}

		internal static Bitmap doc_icon
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(WindowsApplication1.Resources.ResourceManager.GetObject("doc-icon", WindowsApplication1.Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		internal static Bitmap ims_ORB_logo
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(WindowsApplication1.Resources.ResourceManager.GetObject("ims-ORB logo", WindowsApplication1.Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static System.Resources.ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(WindowsApplication1.Resources.resourceMan, null))
				{
					WindowsApplication1.Resources.resourceMan = new System.Resources.ResourceManager("WindowsApplication1.Resources", typeof(WindowsApplication1.Resources).Assembly);
				}
				return WindowsApplication1.Resources.resourceMan;
			}
		}

		internal static Bitmap word_logo
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(WindowsApplication1.Resources.ResourceManager.GetObject("word_logo", WindowsApplication1.Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		internal static Bitmap xls_icon
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(WindowsApplication1.Resources.ResourceManager.GetObject("xls-icon", WindowsApplication1.Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}
	}
}