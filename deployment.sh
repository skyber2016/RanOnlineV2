# Step to deploy code INT for staging server:
# 1. Run script to backup current source code.
# 2. Run script copy file to server
# 3. Run script install node_modules
# 4. Run script start server

# Export static variable
export ec2_host=ubuntu@18.191.162.236
export ec2_ppk=./ran_online.ppk
export rootDirectory=source
# Echo start deployment
echo 'Start deployment for '$env' server - '$ec2_host
# remove folder ignore
plink -i $ec2_ppk $ec2_host "pm2 delete apiService"
plink -i $ec2_ppk $ec2_host "cd /home/ubuntu/source_netcore/RanOnlineV2/BE/RanOnlineCore && dotnet restore && dotnet build && pm2 start --name apiService dotnet -- run && pm2 save"
echo 'Press [Enter] key to continue...'
read