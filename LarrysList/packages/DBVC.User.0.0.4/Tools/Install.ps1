$SqlServer = "88.198.7.228\descartes,1984"
$SqlCatalog = "larryslist_dev"

invoke-sqlcmd -inputfile "LarrysList/SqlObjectCreate.sql" -serverinstance "88.198.7.228\Descartes,1984" -database "larryslist_dev" -username "sa" -password "MaxStirner.1"# the paramenter -databese can be omitted based on what your sql script do.

