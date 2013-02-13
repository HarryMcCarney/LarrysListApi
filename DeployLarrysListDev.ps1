param([string]$env ='Dev')
Import-Module WebAdministration

$site = "LarrysList_{0}_Api" -f $env
$site
set-location "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\"

#stop sites and services 

Stop-WebSite $site
Stop-Service LarrysListMailQueue | Out-Null


#delete everything 
Remove-item "c:\inetpub\wwwroot\LarrysList\LarrysList_$env" -recurse


#deploy api
New-Item "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi" -type directory
copy-item "c:\Hudson\jobs\LarrysList_$env\workspace\LarrysList\LarrysList\bin" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi" -recurse
copy-item "c:\Hudson\jobs\LarrysList_$env\workspace\LarrysList\LarrysList\web.config" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi"
copy-item "c:\Hudson\jobs\LarrysList_$env\workspace\LarrysList\LarrysList\global.asax" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi"
copy-item "c:\Hudson\jobs\LarrysList_$env\workspace\LarrysList\LarrysList\nlog.config" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi"

#deploy services 
New-Item "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices" -type directory
New-Item "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\MailQueue\" -type directory
copy-item "c:\hudson\jobs\LarrysList_$env\workspace\LarrysList\MailQueue\bin\*" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\MailQueue\" -recurse

#start sites and services 
Start-WebSite $site
Start-Service LarrysListMailQueue






















