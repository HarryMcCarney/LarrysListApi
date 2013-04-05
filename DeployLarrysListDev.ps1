param([string]$env ='Dev')
Import-Module WebAdministration

$site = "LarrysList_{0}_Api" -f $env
$site
set-location "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\"

#stop sites and services 

Stop-WebSite $site
Stop-Service LarrysListMailQueue | Out-Null
Stop-Service LarrysListRankingandCompletion$env | Out-Null
Stop-Service LarrysListGoogleRank$env | Out-Null


#uninstall services
set-location "c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListServices\Ranking\"
invoke-expression "Ranking.exe uninstall"
set-location "c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListServices\RankingandCompletion\"
invoke-expression "RankingandCompletion.exe uninstall" 


set-location "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\"
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

New-Item "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\Ranking\" -type directory
copy-item "c:\hudson\jobs\LarrysList_$env\workspace\LarrysList\Ranking\bin\*" "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\Ranking\" -recurse






if ($env -eq "Live")
{
#UPDATE .configs
$connectionString = "data source=88.198.7.228\Descartes,1984;Initial Catalog=LarrysList_Live;User Id=LarrysList_user;Password=Popov2010;"
$JobconnectionString = "data source=88.198.7.228\Descartes,1984;Initial Catalog=LarrysList_Live;User Id=LarrysList_job;Password=Popov2010;"
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

#Ranking
$webConfigPath = "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\Ranking\Ranking.exe.config"
$xml = [xml](get-content $webConfigPath)
$root = $xml.get_DocumentElement();
$root.connectionStrings.add.connectionString = $JobconnectionString
$xml.Save($webConfigPath)


#RankingServiceName
$webConfigPath = "c:\inetpub\wwwroot\LarrysList\LarrysList_$env\LarrysListServices\Ranking\Ranking.exe.config"
$xml = [xml](get-content $webConfigPath)
$root = $xml.get_DocumentElement();
$root.connectionStrings.add.connectionString = $JobconnectionString
$xml.Save($webConfigPath)





}
#install services
set-location "c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListServices\Ranking\"
invoke-expression "Ranking.exe install"
set-location "c:\inetpub\wwwroot\LarrysList\LarrysList_Dev\LarrysListServices\RankingandCompletion\"
invoke-expression "RankingandCompletion.exe install" 

#start sites and services 
Start-WebSite $site
Start-Service LarrysListMailQueue
Start-Service LarrysListRankingandCompletion$env | Out-Null
Start-Service LarrysListGoogleRank$env | Out-Null






















