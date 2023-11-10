using System;
namespace WikiApi
{
	public class ApiConfig
	{
		public string HostName { get; set; }
		public string Project { get; set; }
		public string Language { get; set; }

		public ApiConfig(string hostName, string project, string language)
		{
			HostName = hostName;
			Project = project;
			Language = language;
		}
	}
}

