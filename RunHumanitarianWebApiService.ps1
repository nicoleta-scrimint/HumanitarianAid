param(
[string]$web_service_path)

# $web_service_path - The full path to the backend project relative path "HumanitarianAid\Backend\Centric.HumanitarianAid.API\Centric.HumanitarianAid.API"

Set-Location -Path $web_service_path
dotnet run