using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https.Internal;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Home.DataCrawler
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//var cert = new X509Certificate2("homecert.csr","");
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				   //.UseKestrel((context, options) =>
				   //{
					  // options.Listen(IPAddress.Any, 5001, listenOptions =>
					  // {
						 //  listenOptions.UseHttps("", "");
						 //  listenOptions.UseConnectionLogging();
					  // });
				   //})
				   .UseUrls("http://*:5000")
				   .UseStartup<Startup>();
	}
}
