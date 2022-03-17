Technical prerequisites for running the backend service application:
- .Net SDK 6
	- Not needed if Visual Studio 2022 is already installed
	- Can be downloaded and installed from https://dotnet.microsoft.com/en-us/download/dotnet/6.0
		- ![](/RunBackendServiceHelpImages/InstallDotNetSdk6.png?raw=true)
- SQL Server Express 2019 LocalDB
	- If Visual Studio 2022 is installed:
		- From Visual Studio, go to menu item Tools > Get Tools and Features…
			- ![](/RunBackendServiceHelpImages/OpenToolsAndFeaturesFromVisualStudio.png?raw=true)
		- Go to “Individual components” tab
		- Search for LocalDb and from the search results, select “SQL Server Express 2019 LocalDB”. If it is already selected, this means that the LocalDb is already installed and the following step does not need to be executed
		- Click Modify, the button from the bottom right of the screen
	- If Visual Studio 2022 is not installed:
		- Based on this documentation, https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15, LocalDB is a feature you select during SQL Server Express installation, and is available when you download the media. If you download the media, either choose Express Advanced or the LocalDB package
			- ![](/RunBackendServiceHelpImages/InstallLocalDbThroughSqlExpress.png?raw=true)

Steps to run the backend service application:
- go to the root location of the GIT repository "GitRepositoryParentPath\HumanitarianAid"
- open a powershell window in this location
- execute the powershell script like: .\RunHumanitarianAidWebApiService.ps1
- if an error for execution policy occurs, run command to bypass execution policy "Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass" and choose Y and after run the upper powershell
- wait for the backend service URL-s which can be like "https://localhost:7254/" and "http://localhost:5254"
- copy the http or https URL to the browser and concatenate the swagger URL part, thus you could have the url "https://localhost:7254/swagger" for the https endpoint
- press Ctrl C in the powershell to shut down the backend web service application
- after the backend web service application is shut down, the current location remains the location of the web service. In order to run again the powershell to start the web service application, you need to start from step 1 from this document
