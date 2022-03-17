$current_path = Get-Location
$web_service_path = "$current_path\Backend\Centric.HumanitarianAid.API\Centric.HumanitarianAid.API"
Set-Location -Path $web_service_path
dotnet run