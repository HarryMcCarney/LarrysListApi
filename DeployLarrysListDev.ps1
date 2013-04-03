param([string]$env ='Dev')
Import-Module WebAdministration

$site = "LarrysList_{0}_Api" -f $env
$site
set-location "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\"

#stop sites and services 

Stop-WebSite $site
Stop-Service LarrysListMailQueue | Out-Null
Stop-Service LarrysListRankingandCompletionLive | Out-Null


#delete everything 
Remove-item "c:\inetpub\wwwroot\LarrysList\LarrysList_$env" -recurse


#deploy api
New-Item "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi" -type directory
copy-item "c:\Hudson\jobs\LarrysList_$env\workspace\LarrysList\LarrysList\bin" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi" -recurse
copy-item "c:\Hudson\jobs\LarrysList_$env\workspace\LarrysList\LarrysList\web.config" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi"
copy-item "c:\Hudson\jobs\LarrysList_$env\workspace\LarrysList\LarrysList\global.asax" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi"
copy-item "c:\Hudson\jobs\LarrysList_$env\workspace\LarrysList\LarrysList\nlog.config" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi"


#deploy reports
New-Item c:\inetpub\wwwroot\LarrysList\LarrysList_$env\larrysListReports -type directory
copy-item c:\Hudson\jobs\LarrysList_$env\workspace\LarrysList\ReportPortal\* c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListReports -recurse





#deploy services 
New-Item "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices" -type directory
New-Item "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\MailQueue\" -type directory
copy-item "c:\hudson\jobs\LarrysList_$env\workspace\LarrysList\MailQueue\bin\*" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\MailQueue\" -recurse


New-Item "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\RankingandCompletion\" -type directory
copy-item "c:\hudson\jobs\LarrysList_$env\workspace\LarrysList\RankingandCompletion\bin\*" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\RankingandCompletion\" -recurse






if ($env -eq "Live")
{
#UPDATE .configs
$connectionString = "data source=88.198.7.228\Descartes,1984;Initial Catalog=LarrysList_Live;User Id=LarrysList_user;Password=Popov2010;"
#API
$webConfigPath = "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListApi\web.config"
$xml = [xml](get-content $webConfigPath)
$root = $xml.get_DocumentElement();
$root.connectionStrings.add.connectionString = $connectionString
$xml.Save($webConfigPath)
#RankingandCompletion
$webConfigPath = "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\RankingandCompletion\RankingandCompletion.exe.config"
$xml = [xml](get-content $webConfigPath)
$root = $xml.get_DocumentElement();
$root.connectionStrings.add.connectionString = $connectionString
$xml.Save($webConfigPath)





}


#start sites and services 
Start-WebSite $site
Start-Service LarrysListMailQueue
Stop-Service LarrysListRankingandCompletionLive | Out-Null






















