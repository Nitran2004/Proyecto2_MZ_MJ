using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Proyecto2_MZ_MJ;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
