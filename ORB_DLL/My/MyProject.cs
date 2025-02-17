using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.MyServices.Internal;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ORB_DLL.My
{
	[GeneratedCode("MyTemplate", "8.0.0.0")]
	[HideModuleName]
	internal static class MyProject
	{
		private readonly static MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider;

		private readonly static MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider;

		private readonly static MyProject.ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User> m_UserObjectProvider;

		private readonly static MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider;

		[HelpKeyword("My.Application")]
		internal static MyApplication Application
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_AppObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.Computer")]
		internal static MyComputer Computer
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_ComputerObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.User")]
		internal static Microsoft.VisualBasic.ApplicationServices.User User
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_UserObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.WebServices")]
		internal static MyProject.MyWebServices WebServices
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyWebServicesObjectProvider.GetInstance;
			}
		}

		[DebuggerNonUserCode]
		static MyProject()
		{
			MyProject.m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();
			MyProject.m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();
			MyProject.m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User>();
			MyProject.m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		internal sealed class MyWebServices
		{
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyWebServices()
			{
			}

			[DebuggerHidden]
			private static T Create__Instance__<T>(T instance)
			where T : new()
			{
				if (instance == null)
				{
					return Activator.CreateInstance<T>();
				}
				return instance;
			}

			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			{
				instance = default(T);
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return this.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return this.GetHashCode();
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyWebServices);
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return this.ToString();
			}
		}

		[ComVisible(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal sealed class ThreadSafeObjectProvider<T>
		where T : new()
		{
			private readonly ContextValue<T> m_Context;

			internal T GetInstance
			{
				[DebuggerHidden]
				get
				{
					T value = this.m_Context.Value;
					if (value == null)
					{
						value = Activator.CreateInstance<T>();
						this.m_Context.Value = value;
					}
					return value;
				}
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ThreadSafeObjectProvider()
			{
				this.m_Context = new ContextValue<T>();
			}
		}
	}
}