set-location 'c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\'

#stop sites and services 
Import-Module WebAdministration
Stop-WebSite 'LarrysList_Dev_Api'
Stop-Service LarrysListMailQueue | Out-Null


#delete everything 
Remove-item c:\inetpub\wwwroot\LarrysList\LarrysList_Dev -recurse


#deploy api
New-Item c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListApi -type directory
copy-item c:\Hudson\jobs\LarrysList_Dev\workspace\LarrysList\LarrysList\bin c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListApi -recurse
copy-item c:\Hudson\jobs\LarrysList_Dev\workspace\LarrysList\LarrysList\web.config c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListApi
copy-item c:\Hudson\jobs\LarrysList_Dev\workspace\LarrysList\LarrysList\global.asax c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListApi
copy-item c:\Hudson\jobs\LarrysList_Dev\workspace\LarrysList\LarrysList\nlog.config c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListApi

#deploy services 
New-Item c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListServices -type directory
New-Item c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListServices\MailQueue\ -type directory
copy-item c:\hudson\jobs\LarrysList_Dev\workspace\LarrysList\MailQueue\bin\* c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListServices\MailQueue\ -recurse

#start sites and services 
Start-WebSite 'LarrysList_Dev_Api'
Start-Service LarrysListMailQueue






















