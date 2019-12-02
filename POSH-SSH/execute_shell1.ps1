Write-Host "Please Enter your parameter to ping"
$cloud=Read-Host

#connect to controller

$nopasswd = new-object System.Security.SecureString
$Crendential= New-Object System.Management.Automation.PSCredential ("ubuntu", $nopasswd)
  
#SSH Session is created connect aws instance using private key
$ssh=New-SSHSession –ComputerName ec2-13-232-138-59.ap-south-1.compute.amazonaws.com -KeyFile 'D:\w\tom.pem' -Credential $Crendential
#Script which deployed in aws instance and which also take parameters
$command="sh new.sh $cloud"
Write-Host "Pinging....."

#This is Write the output to powershell
$result=Invoke-SSHCommand -SSHSession $ssh -Command $command | select Output -ExpandProperty Output | Out-String
Write-Host " Ping is: $result"

#End ssh session
$end_result=Remove-SSHSession -SSHSession $ssh